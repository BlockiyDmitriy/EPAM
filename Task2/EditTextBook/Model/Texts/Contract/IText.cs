using EditTextBook.Model.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Texts.Contract
{
    interface IText : ISentenceItem
    {
        ICollection<ISentenceItem> sentences { get; set; }
        void Add(ISentenceItem sentence);
        void Delete(ISentenceItem position);
    }
}
