using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    public class PhoneNumber
    {
        private string _PhoneNumber { get; set; }

        public PhoneNumber(string phoneNumber)
        {
            _PhoneNumber = phoneNumber;
        }
        public string GetNumber() => _PhoneNumber;
        public bool Equals( PhoneNumber other)
        {
            return this._PhoneNumber == other._PhoneNumber;
        }
    }
}
