using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountDeposits
    {
        [Fact]
        public void DepositingMoneyIncreasesTheBalance()
        {
            // Given
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INarcOnAccounts>().Object);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 1M;

            // When
            account.Deposit(amountToDeposit);

            // Then
            var expectedBalance = openingBalance + amountToDeposit;
            Assert.Equal(expectedBalance, account.GetBalance());

        }
    }
}
