using System;

namespace SDAZDGAMEpol5.SOLID.LiskovSubstitutionPrinciple.BadExample
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

        public virtual int WithdrawMoney(int amount)
        {
            if (Deposit >= amount)
            {
                Deposit -= amount;
                return amount;
            }
            else
            {
                // Insufficient deposit!
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}