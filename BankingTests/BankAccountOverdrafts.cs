using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountOverdrafts
    {
        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(openingBalance + 1);
            }
            catch (OverdraftException)
            {

               // Gulp! (I was expecting this... just keep going)
            }

            Assert.Equal(openingBalance, account.GetBalance());
        }

        [Fact]
        public void OverdraftThrowsAnException()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            Assert.Throws<OverdraftException>(() => account.Withdraw(openingBalance + 1));
        }
    }
}
