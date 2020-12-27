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
        Symbol symbol { get; set; }
        int length { get; set; }
    }
}
