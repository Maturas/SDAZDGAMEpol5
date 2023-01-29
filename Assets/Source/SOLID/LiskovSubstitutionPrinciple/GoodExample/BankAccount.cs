namespace SDAZDGAMEpol5.SOLID.LiskovSubstitutionPrinciple.GoodExample
{
    public class BankAccount
    {
        protected int Deposit { get; set; }

        public BankAccount(int deposit)
        {
            Deposit = deposit;
        }

        public virtual void DepositMoney(int amount)
        {
            Deposit += amount;
        }

        public virtual bool TryWithdrawMoney(int amount, out int withdrawnAmount)
        {
            if (Deposit >= amount)
            {
                withdrawnAmount = amount;
                return true;
            }
            else
            {
                withdrawnAmount = 0;
                return false;
            }
        }
    }
}