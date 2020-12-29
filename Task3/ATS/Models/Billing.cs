using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    //класс моделирует работу биллинг сервиса

    internal class Billing
    {
        public int Duration { get; private set; }
        public int Price { get; private set; }
        public User User { get; private set; }
        public Billing(int duration, int price, User user)
        {
            this.Duration = duration;
            this.Price = price;
            this.User = user;
        }
    }
}
