using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Separators
{
    internal class ConsonantSeparator
    {
        private char[] consonantLettersSeparator = new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'g', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };

        public IEnumerable<char> ConsonantLattersSeparator()
        {
            return consonantLettersSeparator.AsEnumerable();
        }
    }
}
