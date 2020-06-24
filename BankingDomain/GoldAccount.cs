namespace BankingDomain
{
    public class GoldAccount : BankAccount
    {
        public override void Deposit(decimal amountToDeposit)
        {
            base.Deposit(amountToDeposit * 1.10M);
        }

        public void SendChristmasToaster()
        {
            // send them a toaster.
        }
    }
}