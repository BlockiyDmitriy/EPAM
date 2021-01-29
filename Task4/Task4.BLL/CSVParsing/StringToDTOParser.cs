using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.BLL.CSVParsing
{
    public class StringToDTOParser : IEnumerable<CSVDTO>, IDisposable
    {
        private StreamReader Reader { get; set; }

        public StringToDTOParser(StreamReader reader)
        {
            Reader = reader;
        }

        public void Dispose()
        {
            if (Reader != null)
            {
                Reader.Dispose();
                GC.SuppressFinalize(this);
                Reader = null;
            }
        }

        public IEnumerator<CSVDTO> GetEnumerator()
        {
            if (!Reader.EndOfStream)
            {
                var item = Reader
                    .ReadLine()
                    .Split(new char[] { ',', ';'})
                    .Select(x => x.Trim())
                    .ToArray();
                yield return new CSVDTO() { ClientName = item[0], DateTime = item[1], Product = item[2], Sum = item[3] };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        ~StringToDTOParser()
        {
            Dispose();
        }
    }
}
