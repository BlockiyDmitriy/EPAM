using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Models.Contracts
{
    public interface IUser
    {
        Guid GetGuid();
        string GetName();
        ITerminal GetTerminal();
        double GetMoney();
        double GetTarif();
        double GetCost();
    }
}
