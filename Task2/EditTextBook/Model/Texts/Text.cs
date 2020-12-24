using EditTextBook.Model.Sentences;
using EditTextBook.Model.Words;
using EditTextBook.MySorted.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Texts
{
    internal class Text
    {
        public List<Sentence> sentences = new List<Sentence>();
        public Text() { }

        // вынести в класс "символ"
        public bool IsWordBegWithConsLetter(Word word)
        {
            List<char> consonantLetters = new List<char> { 'b', 'c', 'd', 'f', 'g', 'h', 'g', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
            if (consonantLetters.Contains(Char.ToLower(word.symbals[0])))
            {
                return true;
            }
            return false;
        }

        public void Add(Sentence sentence)
        {
            sentences.Add(sentence);
        }
        public void Delete(int position)
        {
            sentences.RemoveAt(position);
        }

        public int Length { get { return sentences.Count; } }

        public void SortedByWordCount()
        {
            sentences.Sort();
        }
        public string ToString(bool isPresenseOfLineFeed)
        {
            string text = "";
            for (int i = 0; i < Length; i++)
            {
                text += sentences[i].ToString(isPresenseOfLineFeed) + " ";
                if (!isPresenseOfLineFeed)
                {
                    text += "\r\n";
                }
            }
            return text;
        }

        //слова в вопросительном вопросе без повторов
        public void PrintWordsInInterrogativeWithoutRepetitions(StreamWriter writer, int len)
        {
            HashSet<string> hash = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < Length; i++)
            {
                if (sentences[i].type == TypeOfSentence.interrogative)
                {
                    for (int j = 0; j < sentences[i].Length; j++)
                    {
                        if (len == sentences[i].words[j].Length)
                        {
                            hash.Add(sentences[i].words[j].ToString());
                        }
                    }
                }
            }
            foreach (string str in hash)
            {
                writer.WriteLine(str);
            }
        }
        public void DeleteEmptySentences()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < sentences[i].Length; j++)
                {
                    if (sentences[i].words[j].symbals == null)
                    {
                        Delete(i);
                    }
                }
            }
        }
        //удаление слов начинающихся с согласной
        public void DeleteWordsBegWithConsonant(int len)
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < sentences[i].Length; j++)
                {
                    if (len == sentences[i].words[j].Length && IsWordBegWithConsLetter(sentences[i].words[j]))
                    {
                        sentences[i].Delete(j);
                    }
                }
            }
        }
        //замена слов подстрокой
        public void WordsReplaceWithSubstring(int numOfSentence, int len, string subStr)
        {
            for (int i = 0; i < sentences[numOfSentence - 1].Length; i++)
            {
                if (sentences[numOfSentence - 1].words[i].Length == len)
                {
                    sentences[numOfSentence - 1].words[i].symbals = subStr;
                }
            }
        }
        public void Concordance(StreamWriter writer, int numOfLines)
        {
            int currentPage = 1;
            string temp_str = "";
            SortedDictionary<string, MyValue> dictionary = new SortedDictionary<string, MyValue>();//MySortedDictionary();
            MyValue temp = new MyValue();
            int lines = numOfLines;
            for (int i = 0; i < Length; i++)
            {
                if (i > lines)
                {
                    currentPage++;
                    lines = lines + numOfLines;
                }
                for (int j = 0; j < sentences[i].Length; j++)
                {
                    temp_str = sentences[i].words[j].symbals;
                    if (dictionary.TryGetValue(temp_str.ToLower(), out temp))
                    {
                        temp.pageNumbers.Add(currentPage);
                        temp.numOfRepetitions++;
                        dictionary[temp_str.ToLower()] = temp;
                    }
                    else
                    {
                        temp = new MyValue();
                        temp.pageNumbers.Add(currentPage);
                        temp.numOfRepetitions = 1;
                        dictionary.Add(temp_str.ToLower(), temp);
                    }
                    temp_str = "";
                }
            }
            char ch, pre_ch = ' ';
            bool newLetter = false;
            foreach (var word in dictionary)
            {
                ch = word.Key[0];
                if (ch != pre_ch)
                {
                    newLetter = true;
                }
                pre_ch = ch;
                if (newLetter)
                {
                    writer.WriteLine(Char.ToUpper(word.Key[0]));
                }
                writer.Write("{0,-20}.................{1,5}: ", word.Key, word.Value.numOfRepetitions);
                foreach (int value in word.Value.pageNumbers)
                {
                    writer.Write(value + " ");
                }
                writer.WriteLine();
                newLetter = false;
            }
        }
    }
}
