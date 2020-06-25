using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccontNotifiedFed
    {
        [Fact]
        public void NotifiedOnwithdrawals()
        {
            // Given - I have a bank account
            var mockedFed = new Mock<INarcOnAccounts>(); // Rion: If you see john, write down whatever he says.
            var account = new BankAccount(new Mock<ICalculateBonuses>().Object, mockedFed.Object );
           

            // When - I withdraw
            account.Withdraw(108);


            // Then the fed is notified.
            mockedFed.Verify(m => m.NotifyOfWithdrawal(account, 108));
        }
    }
}
