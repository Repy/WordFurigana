using Furigana;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace WordFurigana
{
    [ComVisible(true)]
    public class Ribbon1 : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public Ribbon1()
        {
        }
        public void OnRubiButton(Office.IRibbonControl control)
        {
            var document = Globals.ThisAddIn.Application.ActiveDocument;

            if (document.ActiveWindow.Selection.Type == Microsoft.Office.Interop.Word.WdSelectionType.wdSelectionIP)
            {
                foreach (Range sentence in document.ActiveWindow.Selection.Sentences)
                {
                    rangeKana(document, sentence);
                }
            }
            else if (document.ActiveWindow.Selection.Type == Microsoft.Office.Interop.Word.WdSelectionType.wdSelectionNormal)
            {
                rangeKana(document, document.ActiveWindow.Selection.Range);
            }

        }

        static void rangeKana(Document document, Range sentence)
        {
            var parser = Globals.ThisAddIn.Parser;
            var text = sentence.Text;
            var res = parser.Parse(text);
            var ranges = new List<Range>();
            var index = 0;
            foreach (var item in res)
            {
                ranges.Add(document.Range(sentence.Start + index, sentence.Start + index + item.Kanji.Length));
                index += item.Kanji.Length;
            }
            for (int i = ranges.Count - 1; i >= 0; i--)
            {
                var range = ranges[i];
                var item = res[i];
                if (!item.Valid) continue;
                var newF = addRubyField(document, range, item);
            }
        }

        static Field addField(Document document, Range range, string code)
        {
            return document.Fields.Add(range, WdFieldType.wdFieldEmpty, code, false);
        }

        static Field addRubyField(Document document, Range range, IKanjiFuri kanjiFuri)
        {
            var size = range.FormattedText.Font.Size;
            var f = addField(document, range, "EQ \\* jc2 \\* hps" + size + " \\o(\\s\\up" + size + "(" + kanjiFuri.Furi + ")," + kanjiFuri.Kanji + "))");
            f.Code.Text = f.Code.Text.Trim();
            return f;
        }

        #region IRibbonExtensibility のメンバー

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("WordFurigana.Ribbon1.xml");
        }

        #endregion

        #region リボンのコールバック
        //ここでコールバック メソッドを作成します。コールバック メソッドの追加について詳しくは https://go.microsoft.com/fwlink/?LinkID=271226 をご覧ください

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region ヘルパー

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
