using ATS.Models.Controllers;
using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Controllers.Services
{
    internal class ATSService
    {
        public void OnATS(object sender, IAutoTelephoneStaition autoTelephoneStaition)
        {
            Connect();
        }
        private void Connect()
        {
            Console.WriteLine("Port connect to ATS");
        }
    }
}
