using System;
using ATS.Models.Controllers.Contracts;

namespace BillingSystem.Models.Contracts
{
    public interface IUser
    {
        Guid GetGuid();
        string GetName();
        ITerminal GetTerminal();
        double GetMoney();
        double GetTarif();
    }
}
