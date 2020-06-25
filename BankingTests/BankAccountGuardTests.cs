using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountGuardTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-.01)]
        [InlineData(-1)]
        public void DepositThrowsForBadAmounts(decimal badAmount)
        {
            var account = new BankAccount(null, null);

            Assert.Throws<BadAmountException>(() => account.Deposit(badAmount));

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-.01)]
        [InlineData(-1)]
        public void WithdrawThrowsForBadAmounts(decimal badAmount)
        {
            var account = new BankAccount(null, null);

            Assert.Throws<BadAmountException>(() => account.Withdraw(badAmount));

        }
    }
}
