using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.BillingSystem
{
    //класс моделирует работу биллинг сервиса. Получение информации о разговоре

    internal class Billing
    {
        private int Duration { get; set; }
        private int Price { get; set; }
        private User User { get; set; }
        public Billing(int duration, int price, User user)
        {
            this.Duration = duration;
            this.Price = price;
            this.User = user;
        }
        public int GetDuration() => Duration;
        public int GetPrice() => Price;
        public User GetUser() => User;
    }
}
