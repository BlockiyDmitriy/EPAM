using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers
{
    //класс моделирует работу терминала(телефона)
    //для работы терминала необходимо знать его номер, выдынный телефонной станцией и порт по которому он подключается.
    internal class Terminal : ITerminal
    {
        private string Number { get; set; }
        private IPort Port { get; set; }
        public Terminal(string number, IPort port)
        {
            this.Number = number;
            this.Port = port;
        }

        public string GetNumberPort() => Number;
        public IPort GetPort() => Port;
    }
}
