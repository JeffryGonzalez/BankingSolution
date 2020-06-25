using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountBonusCalculation
    {

        [Fact]
        public void BonusCalculatorIsUsedProperly()
        {

            // 1. the correct amount is passed to the bonus calculator.
            // 2. the correct balance is passed to the bonus calculator.
            // 3. WHATEVER the bonus calculator returns is added to the balance.
            var fakeBonusCalculator = new Mock<ICalculateBonuses>();
            var account = new BankAccount(fakeBonusCalculator.Object, new Mock<INarcOnAccounts>().Object);
            fakeBonusCalculator.Setup(m => m.GetDepositBonusFor(100, account.GetBalance())).Returns(42);


            account.Deposit(100);

            Assert.Equal(5142, account.GetBalance());
        }
    }

    public class StubbedBonusCalculator : ICalculateBonuses
    {
        public decimal GetDepositBonusFor(decimal amountToDeposit, decimal currentBalance)
        {
            // I want this to return some random number (maybe 42?) if the right
            // amount and balance are passed, otherwise, just return zero.
            if(amountToDeposit == 100 && currentBalance == 5000)
            {
                return 42;
            } else
            {
                return 0;
            }
        }
    }
}
