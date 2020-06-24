using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class GoldAccountDepositsTest
    {
        [Fact]
        public void GoldAccountsGetABonusForDeposits()
        {
            var goldAccount = new BankAccount();
            var openingBalance = goldAccount.GetBalance();
            var amountToDeposit = 100M;
            goldAccount.AccountType = AccountType.Gold;

            goldAccount.Deposit(amountToDeposit);

            var expectedBalance = (amountToDeposit * 1.10M) + openingBalance;

            Assert.Equal(expectedBalance, goldAccount.GetBalance());
        }
    }
}
