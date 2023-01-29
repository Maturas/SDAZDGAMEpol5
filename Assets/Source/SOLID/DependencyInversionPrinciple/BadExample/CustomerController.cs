namespace SDAZDGAMEpol5.SOLID.DependencyInversionPrinciple.BadExample
{
    /// <summary>
    ///     This class violates the Dependency Inversion Principle, as it relies on getting Customer data from
    ///     a concrete reference - CustomerJSONRepository - which severely limits possibilities of implementing alternative
    ///     data sources, like an SQL database for example. Also, the class initializes the Repository instead of just expecting it.
    /// </summary>
    public class CustomerController
    {
        private CustomerJSONRepository Repository { get; }

        private const string FilePath = "data.json";

        public CustomerController()
        {
            Repository = new CustomerJSONRepository(FilePath);
        }
    }
}