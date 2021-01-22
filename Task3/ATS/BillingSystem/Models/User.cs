using ATS.Models;
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

        public User(Guid id, string name, double money, ITerminal terminal, double tarif)
        {
            this.Id = id;
            this.Name = name;
            this.Money = money;
            this.Terminal = terminal;
            this.Tarif = tarif;
        }
        public User(Guid id, string name, double money) : this(id, name, money, null, 0) { }
        public Guid GetGuid() => Id;
        public string GetName() => Name;
        public ITerminal GetTerminal() => Terminal;
        public double GetMoney() => Money;
        public double GetTarif() => Tarif;
        public override string ToString() => $"{Id} {Name} has {Terminal}, money: {Money}";
    }
}
