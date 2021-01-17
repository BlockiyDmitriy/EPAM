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

        public Billing(IAutoTelephoneStaition station, List<PhoneNumber> phones)
        {
            this.PhoneNumbers = new Dictionary<PhoneNumber, bool>();
            this.Users = new List<IUser>();
            this.Station = station;
            CallService = new CallService();
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
                //CallService.SetAdditionalInfo(user, callInfo);
                CallService.AddCall(callInfo);
            };
        }

        private IUser GetUserByTerminal(ITerminal terminal)
        {
            return Users.FirstOrDefault(x => x.GetTerminal().Equals(terminal));
        }

        public void RegisterUser(IUser user)
        {
            var freeNumber = PhoneNumbers.FirstOrDefault(x => x.Value.Equals(true)).Key;
            PhoneNumbers[freeNumber] = false;
            var phoneNumber = freeNumber;
            var terminal = Station.GetTerminal().GetFreeTerminal();
            var tarif = Tarif;
            Users.Add(user);

        }

        public IPort GetFreePort()
        {
            return Station.GetFreePort();
        }
    }
}
