using EditTextBook.MySorted.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Services.Model
{
    internal class MySortedDictionary : SortedDictionary<string, MyValue>
    {
        public void Add(string word, int numOfRepetitions, SortedSet<int> pageNumbers)
        {
            MyValue val = new MyValue();
            val.numOfRepetitions = numOfRepetitions;
            val.pageNumbers = pageNumbers;
            Add(word.ToLower(), val);
        }
    }
}
