using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.IO.FileServices
{
    internal class IOF
    {
        public void TextOutput(StreamWriter writer, string txt)
        {
            for (int i = 0; i < txt.Length; i++)
            {
                if (i == 0 || (!((txt[i] == ' ' || txt[i] == '\t') && (txt[i - 1] == ' ' || txt[i - 1] == '\t'))))
                {
                    if (txt[i] == '\t')
                        writer.Write(' ');
                    else
                        writer.Write(txt[i]);
                }
            }
        }
        public string ReadPBook(string pBook)
        {
            StreamReader reader = new StreamReader(pBook);
            string txt = reader.ReadToEnd();
            reader.Close();
            using (StreamWriter writer = new StreamWriter(pBook))
            {
                TextOutput(writer, txt);
            }
            return txt;
        }
    }
}
