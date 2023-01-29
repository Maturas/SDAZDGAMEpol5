namespace SDAZDGAMEpol5.SOLID.LiskovSubstitutionPrinciple.GoodExample
{
    /// <summary>
    ///     This class obeys the Liskov Substitution Principle, as it can TRY to withdraw money, just as its base class.
    /// </summary>
    public class SavingAccount : BankAccount
    {
        public SavingAccount(int deposit) : base(deposit)
        {
        }

        public override bool TryWithdrawMoney(int amount, out int withdrawnAmount)
        {
            withdrawnAmount = 0;
            return false;
        }
    }
}