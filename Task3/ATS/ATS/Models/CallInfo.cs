using System;
using ATS.Enums;
using ATS.Models.Contracts;
using BillingSystem.Models.Contracts;

namespace ATS.Models
{
    public class CallInfo : ICallInfo
    {
        private PhoneNumber Source { get; set; }
        private PhoneNumber Target { get; set; }
        private DateTime Started { get; set; }
        private TimeSpan Duration { get; set; }
        private CallState CallState { get; set; }
        private IUser User { get; set; }
        private double Cost { get; set; }
        public CallInfo() : this(null, null, DateTime.Now, TimeSpan.Zero, null, 0) { }        
        public CallInfo(PhoneNumber source, PhoneNumber target, DateTime started, TimeSpan duration, IUser user, double cost)
        {
            Source = source;
            Target = target;
            Started = started;
            Duration = duration;
            User = user;
            Cost = cost;
        }

        public PhoneNumber GetPhoneNumber() => Source;
        public PhoneNumber GetTarget() => Target;
        public DateTime GetStarted() => Started;
        public TimeSpan GetDuration() => Duration;
        public CallState GetCallState() => CallState;
        public IUser GetUser() => User;
        public double GetCost() => Cost;

        public override string ToString()
        {
            return ($"{0},{1},{2},{3}", Source, Target, Started, Duration).ToString();
        }
    }
}
