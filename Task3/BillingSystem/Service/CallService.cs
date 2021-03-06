﻿using ATS.Enums;
using ATS.Models;
using ATS.Models.Contracts;
using BillingSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Service
{
    public class CallService
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
            callInfo.User = user;
            if (callInfo.GetCallState() == CallState.Outgoing)
            {
                callInfo.Cost = callInfo.User.Tariff.CostPerSecond * (callInfo.GetDuration().Minutes * 60 + callInfo.GetDuration().Seconds);
                callInfo.User.Money -= callInfo.Cost;
                var money -= callInfo.
            }
            else
            {
                var cost = 0;
                callInfo.Cost = 0;
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
                .Where(x => User.Equals(user) && x.GetCallState().Equals(CallState.Outgoing) && User.GetCost() <= cost);
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

        /*public void GetUserCallsByUser(IUser user, PhoneNumber number)
        {
            var userCalls = Calls
                .Where(x => User.Equals(user) && x.GetStarted().Date >= DateTime.Now.AddMonths(-1).Date && (x.From.Equals(number) || x.To.Equals(number)))
                .GroupBy(x => x.CallState);
            if (userCalls.Count() == 0)
            {
                Console.WriteLine($"No calls with this number {number}");
            }
            else
            {
                foreach (var item in userCalls)
                {
                    Console.WriteLine($"{item.Key}\n");
                    foreach (var x in item.OrderBy(x => x.DateTimeStart))
                    {
                        Console.WriteLine($"{x}\n");
                    }
                    Console.WriteLine();
                }
            }
        }*/
    }
}
