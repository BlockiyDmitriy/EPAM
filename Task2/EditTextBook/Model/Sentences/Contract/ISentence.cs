using EditTextBook.Model.Symbols;
using EditTextBook.Model.Words;
using EditTextBook.Model.Words.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Sentences.Contract
{
    internal interface ISentence
    {
        List<Word> words { get; set; }
        TypeOfSentence type { get; set; }
        int Length { get; set; }
        void Add(Word word);
        void Delete(int position);
        void GetType(char ch);
    }
}
