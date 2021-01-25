using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Enums;
using ATS.Models;
using ATS.Models.Contracts;
using BillingSystem.Models;
using BillingSystem.Models.Contracts;
using BillingSystem.Service.Contracts;

namespace BillingSystem.Service
{
    public class CallService : ICallService
    {
        private IList<ICallInfo> Calls { get; set; }
        private IUser User { get; set; }

        public CallService()
        {
            Calls = new List<ICallInfo>();
        }

        public void AddCall(ICallInfo info)
        {
            Calls.Add(info);
        }

        public void SetAdditionalInfo(IUser user, ICallInfo callInfo)
        {
            if (callInfo.GetCallState() == CallState.Outgoing)
            {
                var cost = callInfo.GetUser().GetTarif() * (callInfo.GetDuration().Minutes * 60 + callInfo.GetDuration().Seconds);
                var money = callInfo.GetUser().GetMoney() - callInfo.GetCost();
                new User(user.GetGuid(),User.GetName(), money);
                new CallInfo(callInfo.GetPhoneNumber(), callInfo.GetTarget(), callInfo.GetStarted(), callInfo.GetDuration(), user, cost);
            }
            else
            {
                var cost = 0;
                new CallInfo(callInfo.GetPhoneNumber(), callInfo.GetTarget(), callInfo.GetStarted(), callInfo.GetDuration(), user, cost);
            }
        }

        public void GetUserCallsPerMonth(IUser user)
        {
            var userCalls = Calls
                .Where(x => User.Equals(user) && x.GetStarted().Date >= DateTime.Now.AddMonths(-1).Date)
                .GroupBy(x => x.GetCallState());
            foreach (var item in userCalls)
            {
                Console.WriteLine($"{item.Key}\n");
                foreach (var x in item.OrderBy(x => x.GetStarted()))
                {
                    Console.WriteLine($"{x}\n");
                }
                Console.WriteLine();
            }
        }

        public void GetUserCallsByCallStatePerMonth(IUser user, CallState callState)
        {
            var userCalls = Calls
                .Where(x => User.Equals(user) && x.GetStarted().Date >= DateTime.Now.AddMonths(-1).Date && x.GetCallState().Equals(callState));
            if (userCalls.Count() == 0)
            {
                Console.WriteLine($"No {callState} calls");
            }
            else
            {
                Console.WriteLine($"{callState} calls");
                foreach (var item in userCalls.OrderBy(x => x.GetStarted()))
                {
                    Console.WriteLine($"{item}\n");
                }
            }
        }

        public void GetUserCallsByDate(IUser user, int days)
        {
            days = days <= 0 ? days = 7 : days > 30 ? days = 30 : days;
            var userCalls = Calls
                .Where(x => User.Equals(user) && x.GetStarted().Date >= DateTime.Now.AddDays(-days).Date)
                .GroupBy(x => x.GetCallState());
            if (userCalls.Count() == 0)
            {
                Console.WriteLine($"No calls between {DateTime.Now.AddDays(-days):d} and {DateTime.Now:d}");
            }
            else
            {
                foreach (var item in userCalls)
                {
                    Console.WriteLine($"{item.Key}\n");
                    foreach (var x in item.OrderBy(x => x.GetStarted()))
                    {
                        Console.WriteLine($"{x}\n");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void GetUserCallsByDuration(IUser user, int minutes, int seconds)
        {
            minutes = minutes < 0 ? 0 : minutes >= 60 ? 59 : minutes;
            seconds = seconds < 0 ? 1 : seconds >= 60 ? 59 : seconds;
            var userCalls = Calls
                .Where(x => User.Equals(user) && x.GetStarted().Date >= DateTime.Now.AddMonths(-1).Date && x.GetDuration() <= TimeSpan.ParseExact($"{minutes}:{seconds}", "m\\:s", null))
                .GroupBy(x => x.GetCallState());
            if (userCalls.Count() == 0)
            {
                Console.WriteLine($"No calls up to {TimeSpan.ParseExact($"{minutes}:{seconds}", "m\\:s", null):mm\\:ss}");
            }
            else
            {
                foreach (var item in userCalls)
                {
                    Console.WriteLine($"{item.Key}\n");
                    foreach (var x in item.OrderBy(x => x.GetDuration()))
                    {
                        Console.WriteLine($"{x}\n");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void GetUserCallsByCost(IUser user, double cost)
        {
            cost = cost <= 0 ? 0.15 : cost;
            var userCalls = Calls
                .Where(x => User.Equals(user) && x.GetCallState().Equals(CallState.Outgoing) && x.GetCost() <= cost);
            if (userCalls.Count() == 0)
            {
                Console.WriteLine($"No calls up to {cost}$");
            }
            else
            {
                Console.WriteLine($"Calls up to {cost}$");
                foreach (var item in userCalls.OrderBy(x => x.GetStarted()))
                {
                    Console.WriteLine($"{item}\n");
                }
            }
        }

        public void GetUserCallsByUser(IUser user, PhoneNumber number)
        {
            var userCalls = Calls
                .Where(x => User.Equals(user) && x.GetStarted().Date >= DateTime.Now.AddMonths(-1).Date && (x.GetPhoneNumber().Equals(number) || x.GetTarget().Equals(number)))
                .GroupBy(x => x.GetCallState());
            if (userCalls.Count() == 0)
            {
                Console.WriteLine($"No calls with this number {number}");
            }
            else
            {
                foreach (var item in userCalls)
                {
                    Console.WriteLine($"{item.Key}\n");
                    foreach (var x in item.OrderBy(x => x.GetStarted()))
                    {
                        Console.WriteLine($"{x}\n");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
