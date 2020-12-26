using EditTextBook.Model.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Sentences
{
    internal class Sentence : IComparable<Sentence>
    {       

        public List<Word> words = new List<Word>();
        public TypeOfSentence type = TypeOfSentence.declarative;

        public int Length { get { return words.Count; } }
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
        public string ToString(bool isPresenseOfLineFeed)
        {
            var sentence = string.Empty;
            for (int i = 0; i < Length; i++)
            {
                if (isPresenseOfLineFeed)
                { 
                    sentence += words[i].ToString();
                }
                else
                { 
                    sentence += words[i].symbals;
                }
                if (i != (Length - 1))
                {
                    sentence += " ";
                }
            }
            return sentence;
        }

        public int CompareTo(Sentence other)
        {
            return words.Count.CompareTo(other.words.Count);
        }
    }
}

