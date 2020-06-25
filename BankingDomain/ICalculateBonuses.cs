namespace BankingDomain
{
    public interface ICalculateBonuses
    {
        decimal GetDepositBonusFor(decimal amountToDeposit, decimal currentBalance);
    }
}