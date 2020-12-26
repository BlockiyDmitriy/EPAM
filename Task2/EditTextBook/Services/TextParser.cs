using EditTextBook.Model.Sentences;
using EditTextBook.Model.Separators;
using EditTextBook.Model.Texts;
using EditTextBook.Model.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Services
{
    internal class TextParser
    {
        private readonly PunctuationSeparator punctuationSeparator;
        public TextParser()
        {
            punctuationSeparator = new PunctuationSeparator();
        }
        public bool IsSeparator(char temp)
        {
            var separator = punctuationSeparator.Separator();
            foreach (var item in separator)
            {
                if (temp == item)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsPunctuationMark(char temp)
        {
            var separator = punctuationSeparator.MyPunctuationSeparator();
            foreach (var item in separator)
            {
                if (temp == item)
                {
                    return true;
                }
            }
            return false;
        }

        public bool EndOfSentence(char temp)
        {
            var separator = punctuationSeparator.EndSentenceSeparator();
            foreach (var item in separator)
            {
                if (temp == item)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCodeSymbols(char temp)
        {
            var separator = punctuationSeparator.CodeSymbolSeparator();
            foreach (var item in separator)
            {
                if (temp == item)
                {
                    return true;
                }
            }
            return false;
        }

        public Text Parse(string txt)
        {
            bool newSentence = false;
            Text text = new Text();
            Sentence sentence = new Sentence();
            Word word = new Word();
            for (int i = 0; i < txt.Length; i++)
            {
                if (!IsPunctuationMark(txt[i]) && !IsSeparator(txt[i]) && !IsCodeSymbols(txt[i]))
                {
                    word.symbols += txt[i];
                }
                else if (IsPunctuationMark(txt[i]))
                {
                    if (word.symbols == null)
                    {
                        word.punctuationMarkBefore = txt[i];
                    }
                    else
                    {
                        word.punctuationMarkAfter.Add(txt[i]);
                    }

                    if (EndOfSentence(txt[i]) && word.symbols != null)
                    {
                        sentence.GetType(txt[i]);
                        newSentence = true;
                    }
                }
                else
                {
                    if (txt[i] == '\r' && word.symbols != null)
                    {
                        word.presenceOfLineFeed = true;
                        newSentence = true;
                    }
                }
                if ((IsSeparator(txt[i]) || i == (txt.Length - 1) || IsCodeSymbols(txt[i]) || txt[i] == '.') && word.symbols != null)
                {
                    sentence.Add(word);
                    if (newSentence)
                    {
                        text.Add(sentence);
                        sentence = new Sentence();
                    }
                    word = new Word();
                    newSentence = false;
                }
            }
            return text;
        }
    }
}
