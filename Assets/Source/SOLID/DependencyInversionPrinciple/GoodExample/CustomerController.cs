namespace SDAZDGAMEpol5.SOLID.DependencyInversionPrinciple.GoodExample
{
    /// <summary>
    ///     This class obeys the Dependency Inversion Principle, as it relies on getting Customer data from an interface,
    ///     not a concrete implementation, which allows for usage of various sources of data (JSON, CSV, SQL, noSQL, etc.).
    ///     Also, it doesn't initialize the Repository by itself, instead it expects it as its constructor's parameter.
    /// </summary>
    public class CustomerController
    {
        private IRepository<Customer> Repository { get; }

        public CustomerController(IRepository<Customer> repository)
        {
            Repository = repository;
        }
    }
}