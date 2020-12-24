using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Separators
{
    internal class CyrillicsSeparator
    {
        private string[] russianSeparator = new string[]{ "а", "у", "о", "ы", "и", "э", "я", "ю", "ё", "е" };

        public IEnumerable<string> RussianSeparator()
        {
            return russianSeparator.AsEnumerable();
        }
    }
}
