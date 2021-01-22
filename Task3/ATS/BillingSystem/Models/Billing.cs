using ATS.Models;
using ATS.Models.Controllers.Contracts;
using ATS.Services.Contracts;
using BillingSystem.Models.Contracts;
using BillingSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Models.BillingSystem
{

    public class Billing : IBilling
    {
        private IDictionary<PhoneNumber, bool> PhoneNumbers { get; set; }
        private IList<IUser> Users { get; set; }
        private IAutoTelephoneStaition Station { get; set; }
        private CallService CallService { get; set; }
        private double Tarif { get; set; }
        public IUser GetUser(IUser user) => Users.Where(x => x.GetGuid() == user.GetGuid()).FirstOrDefault();
        public Billing(IAutoTelephoneStaition station, List<PhoneNumber> phones)
        {
            this.PhoneNumbers = new Dictionary<PhoneNumber, bool>();
            this.Users = new List<IUser>();
            this.Station = station;
            this.CallService = new CallService();
            this.Tarif = 0.9;
            foreach (var item in phones)
            {
                PhoneNumbers.Add(item, true);
            }
            RegisterHandlerForStation(station);
        }
        private void RegisterHandlerForStation(IAutoTelephoneStaition station)
        {
            station.GetCall().Call += (sender, callInfo) =>
            {
                var user = GetUserByTerminal(sender as Terminal);
                CallService.SetAdditionalInfo(user, callInfo);
                CallService.AddCall(callInfo);
            };
        }

        private IUser GetUserByTerminal(ITerminal terminal)
        {
            return Users.FirstOrDefault(x => x.GetTerminal().Equals(terminal));
        }

        public void RegisterUser(IUser user)
        {
            PhoneNumber freeNumber = PhoneNumbers.FirstOrDefault(x => x.Value.Equals(true)).Key;
            PhoneNumbers[freeNumber] = false;
            var terminal = Station.GetTerminal().GetFreeTerminal();
            terminal = new Terminal(freeNumber);
            user = new User(user.GetGuid(), user.GetName(), user.GetMoney(),terminal, Tarif);

            Users.Add(user);
        }

        public IPort GetFreePort()
        {
            return Station.GetFreePort();
        }
    }
}
