using ATS.Enums;
using ATS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    public class CallInfo: ICallInfo
    {
        private PhoneNumber Source { get; set; }
        private PhoneNumber Target { get; set; }
        private DateTime Started { get; set; }
        private TimeSpan Duration { get; set; }
        private CallState CallState { get; set; }
        public CallInfo() : this(null,null,DateTime.Now, TimeSpan.Zero) { }
        public CallInfo(DateTime dateTime) : this(null, null, dateTime, TimeSpan.Zero) { }
        public CallInfo(PhoneNumber source, PhoneNumber target, DateTime started, TimeSpan duration)
        {
            Source = source;
            Target = target;
            Started = started;
            Duration = duration;
        }

        public PhoneNumber GetPhoneNumber() => Source;
        public PhoneNumber GetTarget() => Target;
        public DateTime GetStarted() => Started;
        public TimeSpan GetDuration() => Duration;
        public CallState GetCallState() => CallState;

        public override string ToString()
        {
            return ($"{0},{1},{2},{3}", Source, Target, Started, Duration).ToString();
        }
    }
}
