using EditTextBook.Model.Sentences;
using EditTextBook.Model.Sentences.Contract;
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
        public bool CheckSeparator(IEnumerable<char> separator, char temp)
        {
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
                if (!CheckSeparator(punctuationSeparator.MyPunctuationSeparator(), txt[i]) &&
                    !CheckSeparator(punctuationSeparator.Separator(), txt[i]) &&
                    !CheckSeparator(punctuationSeparator.CodeSymbolSeparator(), txt[i]))
                {
                    word.symbol.Content += txt[i];
                }
                else if (!CheckSeparator(punctuationSeparator.MyPunctuationSeparator(), txt[i]))
                {
                    if (word.symbol.Content == null)
                    {
                        word.punctuationMarkBefore = txt[i];
                    }
                    else
                    {
                        word.punctuationMarkAfter.Add(txt[i]);
                    }

                    if (CheckSeparator(punctuationSeparator.EndSentenceSeparator(), txt[i]) && word.symbol.Content != null)
                    {
                        sentence.GetType(txt[i]);
                        newSentence = true;
                    }
                }
                else
                {
                    if (txt[i] == '\r' && word.symbol.Content != null)
                    {
                        word.presenceOfLineFeed = true;
                        newSentence = true;
                    }
                }
                if (((CheckSeparator(punctuationSeparator.Separator(), txt[i]) ||
                    i == (txt.Length - 1) ||
                    (CheckSeparator(punctuationSeparator.CodeSymbolSeparator(), txt[i])) ||
                    txt[i] == '.') && word.symbol.Content != null))
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
