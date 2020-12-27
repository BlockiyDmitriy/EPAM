using EditTextBook.Model.Sentences.Contract;
using EditTextBook.Model.Symbols;
using EditTextBook.Model.Words;
using EditTextBook.Model.Words.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Sentences
{
    internal class Sentence : ISentence, IComparable<Sentence>
    {

        public List<Word> words { get; set; }
        public TypeOfSentence type { get; set; }

        public Sentence()
        {
            words = new List<Word>();
            type = TypeOfSentence.declarative;
        }
        public int Length 
        { 
            get { return words.Count; }
            set { Length = value; }
        }
        public void Add(Word word)
        {
            words.Add(word);
        }
        public void Delete(int position)
        {
            words.RemoveAt(position);
        }
        public void GetType(char ch)
        {
            if (ch == '?')
            {
                type = TypeOfSentence.interrogative;
                return;
            }
            if (ch == '!')
            {
                type = TypeOfSentence.exclamatory;
                return;
            }
            else
            {
                type = TypeOfSentence.declarative;
                return;
            }
        }
        public string ToString(bool isPresenceOfLineFeed)
        {
            StringBuilder sentence = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                if (isPresenceOfLineFeed)
                {
                    sentence.Append(words.ElementAt(i).ToString());
                }
                else
                {
                    //sentence.Append(words.ElementAt(i));
                    //sentence += words[i].symbol;
                }
                if (i != (Length - 1))
                {
                    sentence.Append(" ");
                }
            }
            return sentence.ToString();
        }
        public int CompareTo(Sentence other)
        {
            return words.Count.CompareTo(other.words.Count);
        }
    }
}

