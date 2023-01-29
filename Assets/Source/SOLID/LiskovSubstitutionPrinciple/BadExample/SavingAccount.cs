using System;

namespace SDAZDGAMEpol5.SOLID.LiskovSubstitutionPrinciple.BadExample
{
    /// <summary>
    ///     This class violates the Liskov Substitution Principle, as it doesn't have all the functionalities
    ///     of its base type - you cannot withdraw money from it, it will cause an exception.
    /// </summary>
    public class SavingAccount : BankAccount
    {
        public SavingAccount(int deposit) : base(deposit)
        {
        }

        public override int WithdrawMoney(int amount)
        {
            throw new NotSupportedException();
        }
    }
}