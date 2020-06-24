using System;

namespace BankingDomain
{
    public enum AccountType {  Standard, Gold  }
    public class BankAccount
    {
        private decimal _currentBalance = 5000;

        public AccountType AccountType = AccountType.Standard;
        public decimal GetBalance()
        {
            return _currentBalance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            if(AccountType == AccountType.Gold)
            {
                amountToDeposit *= 1.10M;
            }
            _currentBalance += amountToDeposit;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw <= _currentBalance)
            {
                _currentBalance -= amountToWithdraw;
            } else
            {
                throw new OverdraftException();
            }
        }
    }
}