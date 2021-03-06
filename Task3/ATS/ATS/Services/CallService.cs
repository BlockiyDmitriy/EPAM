﻿using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Models;
using ATS.Models.Contracts;
using ATS.Services.Contracts;

namespace ATS.Services
{
    public class CallService : ICallService
    {
        private ICollection<ICallInfo> _CallInfos { get; set; }

        public event EventHandler<ICallInfo> Call;

        public CallService()
        {
            this._CallInfos = new List<ICallInfo>();
        }

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
        public ICallInfo GetCallInfo(Connection connection)
        {
            return _CallInfos.FirstOrDefault();
        }

        protected virtual void OnCall(object sender, ICallInfo call)
        {
            Call?.Invoke(sender, call);
        }

    }
}
