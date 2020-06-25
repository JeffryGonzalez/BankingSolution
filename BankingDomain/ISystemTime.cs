using System;

namespace BankingDomain
{
    public interface ISystemTime
    {
        DateTime GetCurrent();
    }
}