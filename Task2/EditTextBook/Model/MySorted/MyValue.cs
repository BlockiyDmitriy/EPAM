using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.MySorted.Model
{
    internal class MyValue
    {
        public int numOfRepetitions;
        public SortedSet<int> pageNumbers = new SortedSet<int>();
    }
}
