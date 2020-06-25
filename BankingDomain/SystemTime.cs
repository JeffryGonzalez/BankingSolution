using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class SystemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now; // (the ONLY time we will use this.)
        }
    }
}
