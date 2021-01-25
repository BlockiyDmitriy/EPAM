using System;
using ATS.Models;
using ATS.Models.Contracts;

namespace ATS.Services.Contracts
{
    public interface ICallService
    {
        event EventHandler<ICallInfo> Call;
        void AddCallInfo(ICallInfo callInfo);
        void CreateCallInfo();
        void RemoveCallInfo(ICallInfo callInfo);
        ICallInfo GetCallInfo(Connection connection);
    }
}
