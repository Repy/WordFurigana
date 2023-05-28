using System;
using System.Collections.Generic;
using System.Text;

namespace Furigana
{
    public interface IKanjiFuri
    {
        string Kanji { get; }
        string Furi { get; }
        bool Valid { get; }
    }
}
