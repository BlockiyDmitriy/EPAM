using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Models.BillingSystem
{
    //класс моделирует работу биллинг сервиса. Получение информации о разговоре

    internal class Billing
    {
        private IEnumerable<DialogInformation> DialogInformationl { get; set; }
        public Billing(IEnumerable<DialogInformation> dialogInformation)
        {
            this.DialogInformationl = dialogInformation;
        }                

    }
}
