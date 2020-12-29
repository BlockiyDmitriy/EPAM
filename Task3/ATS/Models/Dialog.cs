using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    //класс для отслеживания текущего разговора
    internal class Dialog
    {
        private Dictionary<User, User> UserDialog { get; set; }
        private User Client { get; set; }
        private User Subscriber { get; set; }
        public int Price { get; private set; }
        public int Duration { get; private set; }
        public Dialog(User user, User subscriber, int price, int duration)
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
        public Dictionary<User,User>.ValueCollection GetUsersInDialog()
        {
            return UserDialog.Values;
        }
    }
}
