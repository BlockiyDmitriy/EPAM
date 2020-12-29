using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    //класс моделирует работу терминала(телефона)
    //для работы терминала необходимо знать его номер, выдынный телефонной станцией и порт по которому он подключается.
    internal class Terminal
    {
        public int Number { get; private set; }
        public int Port { get; private set; }
        public Terminal(int number, int port)
        {
            this.Number = number;
            this.Port = port;
        }
    }
}
