using EditTextBook.Model.Symbols;
using EditTextBook.Model.Words.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Words
{
    internal class Word : IWord
    {
        private IEnumerable<Symbol> symbols;

        public char punctuationMarkBefore { get; set; }
        public List<char> punctuationMarkAfter = new List<char>();
        public bool presenceOfLineFeed = false;

        public Symbol symbol
        {
            get { return symbols.First(); }
            set { symbol = value; }
        }

        public int length
        {
            get { return symbols.Count(); }
            set { length = value; }
        }

        public override string ToString()
        {
            StringBuilder word = new StringBuilder();
            if (punctuationMarkBefore != '\0')
            {
                word.Append(punctuationMarkBefore);
            }
            word.Append(symbol);
            for (int j = 0; j < punctuationMarkAfter.Count; j++)
            {
                word.Append(punctuationMarkAfter[j]);
            }
            if (presenceOfLineFeed == true)
            {
                word.Append("\r\n");
            }
            return word.ToString();
        }
    }
}
