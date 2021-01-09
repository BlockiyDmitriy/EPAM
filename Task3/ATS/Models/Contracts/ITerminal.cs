using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers.Contracts
{
    internal interface ITerminal
    {
        PhoneNumber GetNumber();
        IPort GetPort();

        event EventHandler<ITerminal> OutGoingCall;
        event EventHandler InComingCall;
        event EventHandler Answer;
        event EventHandler Drop;
    }
}
