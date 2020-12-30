using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.BillingSystem
{
    //класс для отслеживания текущего разговора
    internal class DialogInformation
    {
        private Dictionary<User, User> UserDialog { get; set; }
        private User Client { get; set; }
        private User Subscriber { get; set; }
        private int ClientNumber { get; set; }
        private int SubscriberNumber { get; set; }
        private int Price { get; set; }
        private int Duration { get; set; }
        public DialogInformation(User user, User subscriber, int price, int duration)
        {
            this.Client = user;
            this.Subscriber = subscriber;
            this.Price = price;
            this.Duration = duration;
            UserDialog = new Dictionary<User, User>(1);
        }
        public void AddUsersInDialog()
        {
            UserDialog.Add(Client, Subscriber);
        }
        public Dictionary<User, User>.ValueCollection GetUsersInDialog() => UserDialog.Values;
        public int GetClientNumber() => ClientNumber;
        public int GetSubscriberNumber() => SubscriberNumber;
        public int GetPrice() => Price;
        public int GetDuration => Duration;
    }
}
