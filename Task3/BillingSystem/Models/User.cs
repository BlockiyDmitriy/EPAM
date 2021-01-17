using ATS.Models.Controllers.Contracts;
using BillingSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Models
{
    public class User : IUser
    {
        private Guid Id { get; set; }
        private string Name { get; set; }
        private ITerminal Terminal { get; set; }
        private double Money { get; set; }
        private double Tarif { get; set; }
        private double Cost { get; set; }
        public User(string name, double money)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Money = money;
        }
        public override string ToString() => $"{Id} {Name} has {Terminal}, money: {Money}";
        public Guid GetGuid() => Id;
        public string GetName() => Name;
        public ITerminal GetTerminal() => Terminal;
        public double GetMoney() => Money;
        public double GetTarif() => Tarif;
        public double GetCost() => Cost;
    }
}
