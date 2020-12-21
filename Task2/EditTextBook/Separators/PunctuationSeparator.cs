using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Separators
{
    class PunctuationSeparator
    {
        private string[] repeatPunctuationSeparator = new string[] { "\"", "'" };

        private string[] endPunctuationSeparator = new string[] { "!", ".", "?", "...", "?!", "!?" };

        private string[] innerPunctuationSeparator = new string[] { ",", ";", ":" };

        private string[] openPunctuationSeparator = new string[] { "<", "(", "[", "{", "„", "«", "‘" };

        private string[] closePunctuationSeparator = new string[] { ")", ">", "]", "}", "“", "»", "’" };

        private string[] operationPunctuationSeparator = new string[] { "*", "/", "+", "=", "==", "!=", ">=", "=<" };

        public IEnumerable<string> RepeatPunctuationSeparator()
        {
            return repeatPunctuationSeparator.AsEnumerable();
        }
        public IEnumerable<string> EndPunctuationSeparator()
        {
            return endPunctuationSeparator.AsEnumerable();
        }
        public IEnumerable<string> InnerPunctuationSeparator()
        {
            return innerPunctuationSeparator.AsEnumerable();
        }
        public IEnumerable<string> OpenPunctuationSeparator()
        {
            return openPunctuationSeparator.AsEnumerable();
        }
        public IEnumerable<string> ClosePunctuationSeparator()
        {
            return closePunctuationSeparator.AsEnumerable();
        }
        public IEnumerable<string> OperationPunctuationSeparator()
        {
            return operationPunctuationSeparator.AsEnumerable();
        }
        public IEnumerable<string> All()
        {
            return repeatPunctuationSeparator.Concat(EndPunctuationSeparator())
                                             .Concat(InnerPunctuationSeparator())
                                             .Concat(OpenPunctuationSeparator())
                                             .Concat(ClosePunctuationSeparator())
                                             .Concat(OperationPunctuationSeparator());
        }
    }
}
