﻿using System.Collections.Generic;
using System.Linq;
using ATS.Models.Controllers.Contracts;
using ATS.Services.Contracts;

namespace ATS.Services
{
    public class TeriminalService : ITerminalService
    {
        private ICollection<ITerminal> Terminals;

        public TeriminalService()
        {
            Terminals = new List<ITerminal>();
        }
        public ICollection<ITerminal> GetTerminal() => Terminals;
        public ITerminal GetFreeTerminal()
        {
            var freeTerminal = Terminals.FirstOrDefault(x => x.GetPort().GetPortState().Equals(Enums.PortState.Free));
            return freeTerminal;
        }
        public void AddTerminal(ITerminal terminal)
        {
            Terminals.Add(terminal);
        }
    }
}
