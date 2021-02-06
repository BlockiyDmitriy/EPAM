using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.BLL.DataSourceProvider;
using Task4.BLL.Managers;

namespace Task4.BLL.CSVParsing
{
    public class StringToDTOParser : BaseBackUpFileManager, IDataSource<CSVDTO>
    {
        private StreamReader Reader { get; set; }

        public StringToDTOParser(string fileName, string backupFolder) : base(fileName, backupFolder)
        {
            Reader = new StreamReader(fileName);
        }
        public IEnumerator<CSVDTO> GetEnumerator()
        {
            while (!Reader.EndOfStream && Reader != null)
            {
                var item = Reader
                    .ReadLine()
                    .Split(new char[] {'"', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();
                yield return new CSVDTO()
                {
                    DateTime = Convert.ToDateTime(item[0]),
                    ClientName = item[1],
                    Product = item[2],
                    Sum = Convert.ToDouble(item[3])
                };
            }
            Close();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Close()
        {
            Reader?.Close();
        }

        public override void BackUp()
        {
            base.BackUp();
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

        ~StringToDTOParser()
        {
            Dispose();
        }
    }
}
