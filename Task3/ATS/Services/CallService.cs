using ATS.Models;
using ATS.Models.Contracts;
using ATS.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Services
{
    public class CallService: ICallService
    {
        private ICollection<ICallInfo> _CallInfos { get; set; }

        public event EventHandler<ICallInfo> Call;
        public void AddCallInfo(ICallInfo callInfo)
        {
            _CallInfos.Add(callInfo);
        }
        public void CreateCallInfo()
        {
            AddCallInfo(new CallInfo());
        }
        public void RemoveCallInfo(ICallInfo callInfo)
        {
            _CallInfos.Remove(callInfo);
        }
        public ICallInfo GetCallInfo(string from, string to)
        {
            return _CallInfos.FirstOrDefault(x => x.GetPhoneNumber().Equals(from) && x.GetTarget().Equals(to));
        }

        protected virtual void OnCall(object sender, ICallInfo call)
        {
            Call?.Invoke(sender, call);
        }

    }
}
