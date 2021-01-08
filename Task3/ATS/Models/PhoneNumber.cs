using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    internal class PhoneNumber
    {
        private readonly string _PhoneNumber;

        public PhoneNumber(string phoneNumber)
        {
            _PhoneNumber = phoneNumber;
        }
        public string GetNumber() => _PhoneNumber;
        public bool Equals(PhoneNumber other)
        {
            return _PhoneNumber == other._PhoneNumber;
        }
    }
}
