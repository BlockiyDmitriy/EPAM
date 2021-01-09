using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    internal class CallInfo
    {
        public PhoneNumber Source { get; private set; }
        public PhoneNumber Target { get; private set; }
        public DateTime Started { get; private set; }
        public TimeSpan Duration { get; private set; }

        public CallInfo(PhoneNumber source, PhoneNumber target, DateTime started, TimeSpan duration)
        {
            this.Source = source;
            this.Target = target;
            this.Started = started;
            this.Duration = duration;
        }
    }
}
