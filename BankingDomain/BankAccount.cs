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
            GuardAmountInRange(amountToDeposit);
            

            decimal amountOfBonus = _bonusCalculator.GetDepositBonusFor(amountToDeposit, _currentBalance);
            _currentBalance += amountToDeposit + amountOfBonus;

         
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            GuardAmountInRange(amountToWithdraw);
            GuardOverdraft(amountToWithdraw);

            _feds.NotifyOfWithdrawal(this, amountToWithdraw);
            _currentBalance -= amountToWithdraw;

        }

        private void GuardOverdraft(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _currentBalance)
            {
                throw new OverdraftException();
            }
        }

        private void GuardAmountInRange(decimal amount)
        {
            if (amount <= 0)
            {
                throw new BadAmountException();
            }
        }

    }
}