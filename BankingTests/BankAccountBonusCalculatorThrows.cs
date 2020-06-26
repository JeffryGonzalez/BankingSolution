using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountBonusCalculatorThrows
    {
        // When the bonus calculator throws ANY exceptions
        // 1. we want to not blow up.
        // 2. we want to write to an event log that this happened so we can adjust later.

        [Fact]
        public void ThrowIsSwallowed()
        {
            // Given
            var stubbedBonusCalculator = new Mock<ICalculateBonuses>();
            var bankAccount = new BankAccount(stubbedBonusCalculator.Object, null);
            stubbedBonusCalculator.Setup(m => m.GetDepositBonusFor(
                It.IsAny<decimal>(), It.IsAny<decimal>()
                )).Throws<Exception>();

            // When we do a deposit
            bankAccount.Deposit(100);

            Assert.Equal(5100, bankAccount.GetBalance());


        }
    }
}
