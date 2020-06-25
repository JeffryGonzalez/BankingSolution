using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _currentBalance = 5000;
        private ICalculateBonuses _bonusCalculator;
        private INarcOnAccounts _feds;

        public BankAccount(ICalculateBonuses bonusCalculator, INarcOnAccounts feds)
        {
            _bonusCalculator = bonusCalculator;
            _feds = feds;
        }

        public decimal GetBalance()
        {
            return _currentBalance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            // the amount to deposit, the current balance
            // WTCYWYH

             decimal amountOfBonus = _bonusCalculator.GetDepositBonusFor(amountToDeposit, _currentBalance);
            _currentBalance += amountToDeposit + amountOfBonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw <= _currentBalance)
            {
               _feds.NotifyOfWithdrawal(this, amountToWithdraw);
                _currentBalance -= amountToWithdraw;
            } else
            {
                throw new OverdraftException();
            }
        }
    }
}