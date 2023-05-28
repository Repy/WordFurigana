using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestFurigana
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var parser = new Furigana.Parser();
            var result = parser.Parse("漢字をふりがなに変換する。");
            foreach (var item in result)
            {
                Console.WriteLine(item.Kanji + " " + item.Furi);
            }
            Assert.AreEqual(7, result.Count);
            Assert.AreEqual("漢字", result[0].Kanji);
            Assert.AreEqual("かんじ", result[0].Furi);
            Assert.AreEqual("を", result[1].Kanji);
            Assert.AreEqual("", result[1].Furi);
            Assert.AreEqual("ふりがな", result[2].Kanji);
            Assert.AreEqual("", result[2].Furi);
            Assert.AreEqual("に", result[3].Kanji);
            Assert.AreEqual("", result[3].Furi);
            Assert.AreEqual("変換", result[4].Kanji);
            Assert.AreEqual("へんかん", result[4].Furi);
            Assert.AreEqual("する", result[5].Kanji);
            Assert.AreEqual("", result[5].Furi);
            Assert.AreEqual("。", result[6].Kanji);
            Assert.AreEqual("", result[6].Furi);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var parser = new Furigana.Parser();
            var result = parser.Parse("男の子が上手くフリガナにならないらしい。");
            foreach (var item in result)
            {
                Console.WriteLine(item.Kanji + " " + item.Furi);
            }
            Assert.AreEqual(12, result.Count);
            Assert.AreEqual("男", result[0].Kanji);
            Assert.AreEqual("おとこ", result[0].Furi);
            Assert.AreEqual("の", result[1].Kanji);
            Assert.AreEqual("", result[1].Furi);
            Assert.AreEqual("子", result[2].Kanji);
            Assert.AreEqual("こ", result[2].Furi);
            Assert.AreEqual("が", result[3].Kanji);
            Assert.AreEqual("", result[3].Furi);
            Assert.AreEqual("上手", result[4].Kanji);
            Assert.AreEqual("うま", result[4].Furi);
            Assert.AreEqual("く", result[5].Kanji);
            Assert.AreEqual("", result[5].Furi);
            Assert.AreEqual("フリガナ", result[6].Kanji);
            Assert.AreEqual("", result[6].Furi);
            Assert.AreEqual("に", result[7].Kanji);
            Assert.AreEqual("", result[7].Furi);
            Assert.AreEqual("なら", result[8].Kanji);
            Assert.AreEqual("", result[8].Furi);
            Assert.AreEqual("ない", result[9].Kanji);
            Assert.AreEqual("", result[9].Furi);
            Assert.AreEqual("らしい", result[10].Kanji);
            Assert.AreEqual("", result[10].Furi);
            Assert.AreEqual("。", result[11].Kanji);
            Assert.AreEqual("", result[11].Furi);

        }

        [TestMethod]
        public void TestMethod3()
        {
            var parser = new Furigana.Parser();
            var result = parser.Parse("お正月とかYahoo!Japanとかどうだろう？");
            foreach (var item in result)
            {
                Console.WriteLine(item.Kanji + " " + item.Furi);
            }
            Assert.AreEqual(11, result.Count);
            Assert.AreEqual("お", result[0].Kanji);
            Assert.AreEqual("", result[0].Furi);
            Assert.AreEqual("正月", result[1].Kanji);
            Assert.AreEqual("しょうがつ", result[1].Furi);
            Assert.AreEqual("とか", result[2].Kanji);
            Assert.AreEqual("", result[2].Furi);
            Assert.AreEqual("Yahoo", result[3].Kanji);
            Assert.AreEqual("", result[3].Furi);
            Assert.AreEqual("!", result[4].Kanji);
            Assert.AreEqual("", result[4].Furi);
            Assert.AreEqual("Japan", result[5].Kanji);
            Assert.AreEqual("", result[5].Furi);
            Assert.AreEqual("とか", result[6].Kanji);
            Assert.AreEqual("", result[6].Furi);
            Assert.AreEqual("どう", result[7].Kanji);
            Assert.AreEqual("", result[7].Furi);
            Assert.AreEqual("だろ", result[8].Kanji);
            Assert.AreEqual("", result[8].Furi);
            Assert.AreEqual("う", result[9].Kanji);
            Assert.AreEqual("", result[9].Furi);
            Assert.AreEqual("？", result[10].Kanji);
            Assert.AreEqual("", result[10].Furi);
        }


        [TestMethod]
        public void TestMethod4()
        {
            var parser = new Furigana.Parser();
            var text = "フリガナのテストをするのにいい文章を作ってみました。この文章は、小学校で習う漢字と送りがなを使っています。漢字の読み方や書き方を確認するために、ふりがなをつけてみましょう。文章の内容は、**みんなの総ルビテスト**という教材について紹介しています。この教材は、国語・算数・理科・社会の４教科全てのワークテストにふりがなを付けたもので、漢字が読めない子どもでも問題を解けるようになっています。ふりがなのテストに興味がある人は、この教材をチェックしてみてください。";
            var result = parser.Parse(text);
            foreach (var item in result)
            {
                Console.WriteLine(item.Kanji + " " + item.Furi);
            }

        }


        [TestMethod]
        public void TestMethod5()
        {
            var parser = new Furigana.Parser();
            var text = "半角スペース や改行\nの処理が 上手くいかないようだ。あと時々の々とか※や髙も気になる。";
            var result = parser.Parse(text);
            foreach (var item in result)
            {
                Console.WriteLine(item.Kanji + " " + item.Furi);
            }

        }


    }
}