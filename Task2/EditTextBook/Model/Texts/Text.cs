using EditTextBook.Model.Sentences;
using EditTextBook.Model.Separators;
using EditTextBook.Model.Symbols;
using EditTextBook.Model.Texts.Contract;
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
    internal class Text : IText
    {
        public List<Sentence> Sentences;
        private ConsonantSeparator consonantSeparator;

        public Text()
        {
            Sentences = new List<Sentence>();
            consonantSeparator = new ConsonantSeparator();
        }


        public void Add(Sentence sentence)
        {
            sentences.Add(sentence);
        }
        public void Delete(int position)
        {
            sentences.RemoveAt(position);
        }
        public List<Sentence> sentences 
        { 
            get { return Sentences; }
            set { Sentences = value; }
        }

        public int Length { get { return sentences.Count; } }

        public bool IsWordBegWithConsLetter(Word word)
        {
            var consonantLetters = consonantSeparator.ConsonantLattersSeparator();
            if (consonantLetters.Contains(Char.ToLower(word.symbol.Content.ToCharArray().ElementAt(0))))
            {
                return true;
            }
            return false;
        }

        public void SortedByWordCount()
        {
            sentences.Sort();
        }
        public string ToString(bool isPresenceOfLineFeed)
        {
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                text.Append(sentences.ElementAt(i).ToString(isPresenceOfLineFeed)).Append(" ");
                if (!isPresenceOfLineFeed)
                {
                    text.Append("\r\n");
                }
            }
            return text.ToString();
        }

        //слова в вопросительном без повторов
        public void PrintWordsInInterrogativeWithoutRepetitions(StreamWriter writer, int len)
        {
            HashSet<string> hash = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < Length; i++)
            {
                if (sentences[i].type == TypeOfSentence.interrogative)
                {
                    for (int j = 0; j < sentences[i].Length; j++)
                    {
                        if (len == sentences[i].words[j].length)
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
                    if (sentences[i].words[j].symbol == null)
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
                    if (len == sentences[i].words[j].length && IsWordBegWithConsLetter(sentences[i].words[j]))
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
                if (sentences[numOfSentence - 1].words[i].length == len)
                {
                    sentences[numOfSentence - 1].words[i].symbol.Content = subStr;
                }
            }
        }
        public void Concordance(StreamWriter writer, int numOfLines)
        {
            int currentPage = 1;
            string tempStr;
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
                    tempStr = sentences[i].words[j].symbol.Content;
                    if (dictionary.TryGetValue(tempStr.ToLower(), out temp))
                    {
                        temp.pageNumbers.Add(currentPage);
                        temp.numOfRepetitions++;
                        dictionary[tempStr.ToLower()] = temp;
                    }
                    else
                    {
                        temp = new MyValue();
                        temp.pageNumbers.Add(currentPage);
                        temp.numOfRepetitions = 1;
                        dictionary.Add(tempStr.ToLower(), temp);
                    }
                    tempStr = "";
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
