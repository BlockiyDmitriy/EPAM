using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Words
{
    internal class Word
    {
        public string symbals;
        public char punctuationMarkBefore;
        public List<char> punctuationMarkAfter = new List<char>();
        public bool PresenceOfLineFeed = false;
        public Word() { }
        public int Length { get { return symbals.Length; } }

        public override string ToString()
        {
            var word = string.Empty;
            if (punctuationMarkBefore != '\0')
                word += punctuationMarkBefore;
            word += symbals;
            for (int j = 0; j < punctuationMarkAfter.Count; j++)
            {
                word += punctuationMarkAfter[j];
            }
            if (PresenceOfLineFeed == true)
                word += "\r\n";
            return word;
        }
    }
}
