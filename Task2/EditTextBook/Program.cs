using EditTextBook.IO.FileServices;
using EditTextBook.Model.Texts;
using EditTextBook.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string pBook = ConfigurationManager.AppSettings.Get("programmingBook");
            string ansBook = ConfigurationManager.AppSettings.Get("answerBook");
            string concBook = ConfigurationManager.AppSettings.Get("concordanceBook");
            IOF iOF = new IOF();
            string txt = iOF.ReadPBook(pBook);
            TextParser textParser = new TextParser();
            Text text = textParser.Parse(txt);
            text.DeleteEmptySentences();
            using (StreamWriter writeToAnswerTXT = new StreamWriter(ansBook))
            {
                //Вывести все предложения заданного текста в порядке возрастания количества
                //слов в каждом из них
                text.SortedByWordCount();

                int len = 5, numOfSentences = 2;
                // Во всех вопросительных предложениях текста найти и напечатать без
                //повторений слова заданной длины
                text.PrintWordsInInterrogativeWithoutRepetitions(writeToAnswerTXT, len);
                //Из текста удалить все слова заданной длины, начинающиеся на согласную букву
                text.DeleteWordsBegWithConsonant(len);
                text.DeleteEmptySentences();
                //В некотором предложении текста слова заданной длины заменить указанной
                //подстрокой, длина которойможет не совпадать с длиной слова
                string sub = "hello";
                text.WordsReplaceWithSubstring(numOfSentences, len, sub);

                writeToAnswerTXT.Close();
            };
            using (StreamWriter writeToConcordanceTXT = new StreamWriter(concBook))
            {
                //отобразить соответствие
                int countSentencePerPage = 5;
                text.Concordance(writeToConcordanceTXT, countSentencePerPage);
                writeToConcordanceTXT.Close();
            };


        }
    }
}
