using ATS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    internal class CallInfo: ICallInfo
    {
        private PhoneNumber Source { get; set; }
        private PhoneNumber Target { get; set; }
        private DateTime Started { get; set; }
        private TimeSpan Duration { get; set; }


        public PhoneNumber GetPhoneNumber() => Source;
        public PhoneNumber GetTarget() => Target;
        public DateTime GetStarted() => Started;
        public TimeSpan GetDuration() => Duration;

        public override string ToString()
        {
            return ($"{0},{1},{2},{3}", Source, Target, Started, Duration).ToString();
        }
    }
}
