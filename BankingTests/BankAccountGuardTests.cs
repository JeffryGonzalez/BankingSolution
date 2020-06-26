using BankingDomain;
using Moq;
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

            var mockBonusCalculator = new Mock<ICalculateBonuses>();
            var mockNarc = new Mock<INarcOnAccounts>();
            var account = new BankAccount(mockBonusCalculator.Object, mockNarc.Object);

            Assert.Throws<BadAmountException>(() => account.Deposit(badAmount));

            mockBonusCalculator.Verify(
                m => m.GetDepositBonusFor(It.IsAny<decimal>(),
                It.IsAny<decimal>()
                ), Times.Never);

            mockNarc.Verify(
                m => m.NotifyOfWithdrawal(
                    It.IsAny<BankAccount>(),
                    It.IsAny<decimal>())
                , Times.Never);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-.01)]
        [InlineData(-1)]
        public void WithdrawThrowsForBadAmounts(decimal badAmount)
        {
            var account = new BankAccount(new Mock<ICalculateBonuses>().Object, new Mock<INarcOnAccounts>().Object);

            Assert.Throws<BadAmountException>(() => account.Withdraw(badAmount));

        }
    }
}
