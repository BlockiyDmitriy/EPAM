using EditTextBook.Model.Sentences;
using EditTextBook.Model.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Texts.Contract
{
    interface IText
    {
        List<Sentence> sentences { get; set; }
        void Add(Sentence sentence);
        void Delete(int position);
    }
}
