namespace Furigana
{
    internal class KanjiFuri : IKanjiFuri
    {
        string kanji;
        string IKanjiFuri.Kanji => this.kanji;

        string yomi;
        string IKanjiFuri.Furi => this.yomi;

        bool IKanjiFuri.Valid => this.yomi.Length > 0;

        internal KanjiFuri (string kanji, string yomi)
        {
            this.kanji = kanji;
            this.yomi = yomi;
        }
    }
}
