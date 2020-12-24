using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Separators
{
    internal class DigitSeparator
    {
        private string[] arabicSeparator = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public IEnumerable<string> ArabicSeparator()
        {
            return arabicSeparator.AsEnumerable();
        }
    }
}
