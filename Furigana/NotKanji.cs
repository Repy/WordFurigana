namespace Furigana
{
    internal class NotKanji : IKanjiFuri
    {
        string kanji;
        string IKanjiFuri.Kanji => this.kanji;
        string IKanjiFuri.Furi => "";

        bool IKanjiFuri.Valid => false;

        internal NotKanji(string kanji)
        {
            this.kanji = kanji;
        }
    }
}
