using NMeCab.Specialized;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;

namespace Furigana
{

    public class Parser
    {
        private MeCabIpaDicTagger tagger;
        public Parser()
        {
            var myAssembly = Assembly.GetExecutingAssembly();
            var dicPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "IpaDic");
            if (!Directory.Exists(dicPath))
            {
                using (var s = myAssembly.GetManifestResourceStream("Furigana.IpaDic.zip"))
                {
                    using (var archive = new ZipArchive(s, ZipArchiveMode.Read))
                    {
                        Directory.CreateDirectory(dicPath);
                        archive.ExtractToDirectory(dicPath);
                    }
                }
            }
            tagger = MeCabIpaDicTagger.Create(dicPath);
        }

        public KanjiYomiResult Parse(string text)
        {
            return Parse(new string[] { text });
        }

        public KanjiYomiResult Parse(string[] text)
        {
            if (text.Length == 0) return new KanjiYomiResult();

            var nodes = tagger.Parse(string.Join(" ", text));
            var result = new KanjiYomiResult();

            foreach (var node in nodes)
            {
                var kanji = node.Surface;
                var yomi = toHiragana(node.Reading);
                // 漢字のみ
                if (onlyKanji(kanji))
                {
                    result.Add(new KanjiFuri(kanji, yomi));
                    continue;
                }
                // 漢字を含まない
                if (!hasKanji(kanji))
                {
                    result.Add(new NotKanji(kanji));
                    continue;
                }

                //漢字とひらがなが切り替わる
                var split = splitKanjiHiragana(kanji);

                //漢字とひらがなが1回だけ切り替わる時
                if (split.Length == 2)
                {
                    // 先にひらがなの時
                    if (kanji[0] == yomi[0])
                    {
                        for (int i = 0; i < kanji.Length; i++)
                        {
                            if (kanji[i] == yomi[i]) continue;
                            result.Add(new NotKanji(kanji.Substring(0, i)));
                            result.Add(new KanjiFuri(kanji.Substring(i), yomi.Substring(i)));
                            break;
                        }
                        continue;
                    }

                    // 後にひらがなの時
                    if (kanji[kanji.Length - 1] == yomi[yomi.Length - 1])
                    {
                        for (int i = 0; i < kanji.Length; i++)
                        {
                            if (kanji[kanji.Length - i - 1] == yomi[yomi.Length - i - 1]) continue;
                            result.Add(new KanjiFuri(kanji.Substring(0, kanji.Length - i), yomi.Substring(0, yomi.Length - i)));
                            result.Add(new NotKanji(kanji.Substring(kanji.Length - i)));
                            break;
                        }
                        continue;
                    }

                    // エラー
                    result.Add(new NotKanji(kanji));
                    continue;
                }

                // それ以外は強制的に分割モードでもう一度実施
                kanji = "";
                foreach (var s in split)
                {
                    if (isKanji(s[0]))
                    {
                        kanji = s;
                    }
                    else
                    {
                        result.AddRange(Parse(kanji + s));
                        kanji = "";
                    }
                }
                result.AddRange(Parse(kanji));
            }

            // 入力値と一致させる処理
            var output = new KanjiYomiResult();
            var jointext = string.Join("", text);
            foreach (var r in result)
            {
                var index = jointext.IndexOf(r.Kanji);
                if (index < 0)
                {
                    continue;
                }
                if (index > 0)
                {
                    output.Add(new NotKanji(jointext.Substring(0, index)));
                }
                output.Add(r);
                jointext = jointext.Substring(index + r.Kanji.Length);
            }
            if (jointext.Length > 0)
            {
                output.Add(new NotKanji(jointext));
            }

            return output;
        }


        //漢字とひらがなが切り替わるところで分割する
        private string[] splitKanjiHiragana(string text)
        {
            var result = new List<string>();

            bool kanji = isKanji(text[0]);

            var sb = new StringBuilder();
            foreach (var c in text)
            {
                if (kanji != isKanji(c))
                {
                    result.Add(sb.ToString());
                    sb.Clear();
                    kanji = !kanji;
                }
                sb.Append(c);
            }
            result.Add(sb.ToString());
            return result.ToArray();
        }


        private bool isKanji(char c)
        {
            //文字コードが漢字の範囲内かどうか
            if (c >= 0x4E00 && c <= 0x9FFF)
            {
                return true;
            }
            if (c >= 0x3400 && c <= 0x4DBF)
            {
                return true;
            }
            // 々
            if (c == 0x3005)
            {
                return true;
            }
            return false;
        }

        private bool onlyKanji(string text)
        {
            //文字が漢字のみか
            foreach (var c in text)
            {
                if (!isKanji(c))
                {
                    return false;
                }
            }
            return true;
        }

        private bool hasKanji(string text)
        {
            //文字が漢字があるか
            foreach (var c in text)
            {
                if (isKanji(c))
                {
                    return true;
                }
            }
            return false;
        }


        private char toHiragana(char c)
        {
            if (c >= 0x30A1 && c <= 0x30F3)
            {
                return (char)(c - 0x60);
            }
            return c;
        }

        private string toHiragana(string text)
        {
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = toHiragana(chars[i]);
            }
            return new string(chars);
        }
    }
}
