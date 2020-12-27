using EditTextBook.Model.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Words.Contract
{
    internal interface IWord : ISentenceItem
    {
        char punctuationMarkBefore { get; set; }
        List<char> punctuationMarkAfter { get; set; }
        bool presenceOfLineFeed { get; set; }
        Symbol symbol { get; set; }
        int length { get; set; }
    }
}
