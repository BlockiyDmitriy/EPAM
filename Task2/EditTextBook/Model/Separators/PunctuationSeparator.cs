using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Separators
{
    internal class PunctuationSeparator
    {
        private char[] separator = new char[] { ' ', '\t', '\n', '\r' };

        private char[] myPunctuationSeparator = new char[] { ':', ';', '\'', '\'', ',', '!', '?', '.'};

        private char[] endSentenceSeparator = new char[] { '!', '?', '.', ';' };

        private char[] codeSymbolSeparator = new char[] { '{', '}', ')', '(', '[', ']', '$', '=' };
        public PunctuationSeparator() { }

        public IEnumerable<char> RepeatPunctuationSeparator()
        {
            return separator.AsEnumerable();
        }
        public IEnumerable<char> MyPunctuationSeparator()
        {
            return myPunctuationSeparator.AsEnumerable();
        }
        public IEnumerable<char> EndSentenceSeparator()
        {
            return endSentenceSeparator.AsEnumerable();
        }
        public IEnumerable<char> CodeSymbolSeparator()
        {
            return codeSymbolSeparator.AsEnumerable();
        }
        public IEnumerable<char> All() => separator.Concat(MyPunctuationSeparator())
                                                   .Concat(EndSentenceSeparator())
                                                   .Concat(CodeSymbolSeparator());
    }
}
