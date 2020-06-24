using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class GoldAccountDeposits
    {

        [Fact]
        public void GoldAccountsGetABonusForDeposits()
        {
            var account = new GoldAccount();
            var openingBalance = account.GetBalance();

            account.Deposit(100M);

            var expectedBalance = 110M + openingBalance;
            Assert.Equal(expectedBalance, account.GetBalance());
        }

        [Fact]
        public void PolyMorphicStuff()
        {
            GoldAccount account = new GoldAccount();
            account.SendChristmasToaster();

            var myAccounts = new List<BankAccount> {
                new BankAccount(),
                    new BankAccount(),
                    new GoldAccount()
            };

            var total = TotalBalanceForAccounts(myAccounts,100);
            Assert.Equal(15300M, total);
        }


        public decimal TotalBalanceForAccounts(List<BankAccount> accounts, decimal amountToAdd)
        {
            foreach(var account in accounts)
            {
                if(account is GoldAccount)
                {
                    // PUKE! Horrible. You should feel bad an you are a bad person if you do this.
                    // p.s. I've done it and I will do it again. But don't be proud of it. Don't
                    // print it out and put it on your refrigerator.
                    ((GoldAccount)account).SendChristmasToaster();
                }
                        
                        
                account.Deposit(amountToAdd);
            }
            return accounts.Select(b => b.GetBalance()).Sum();
        }
    }
}
