using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountWithdrawals
    {
        private BankAccount _account;
        private decimal _openingBalance;

        public BankAccountWithdrawals()
        {
            _account = new BankAccount(new DummyBonusCalculator());
            _openingBalance = _account.GetBalance();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void WithdrawingMoneyDecreasesBalance(decimal amountToWithdraw)
        {
            _account.Withdraw(amountToWithdraw);

            var expectedBalance = _openingBalance - amountToWithdraw;
            Assert.Equal(expectedBalance, _account.GetBalance());
        }


       [Fact]
       public void YouCanTakeAllYourMoney()
        {
            _account.Withdraw(_openingBalance);

            Assert.Equal(0, _account.GetBalance());
        }

    }
}
