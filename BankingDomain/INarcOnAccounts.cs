namespace BankingDomain
{
    public interface INarcOnAccounts
    {
        void NotifyOfWithdrawal(BankAccount bankAccount, decimal amountToWithdraw);
    }
}