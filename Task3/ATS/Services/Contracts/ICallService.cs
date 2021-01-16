using ATS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Services.Contracts
{
    public interface ICallService
    {
        void AddCallInfo(ICallInfo callInfo);
        void CreateCallInfo();
        void RemoveCallInfo(ICallInfo callInfo);
        ICallInfo GetCallInfo(string from, string to);
    }
}
