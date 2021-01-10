﻿using ATS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers.Contracts
{
    internal interface IPort
    {
        PortState GetPortState();
        ITerminal GetTerminal();

        event EventHandler<PhoneNumber> OutGoingCall;
        event EventHandler<PhoneNumber> InComingCall;
        event EventHandler Answer;
        event EventHandler Drop;
    }
}
