namespace SDAZDGAMEpol5.SOLID.DependencyInversionPrinciple.GoodExample
{
    public class CustomerJSONRepository : IRepository<Customer>
    {
        private string FilePath { get; }

        public CustomerJSONRepository(string filePath)
        {
            FilePath = filePath;
        }

        public Customer Get(int id)
        {
            // TODO read customer object from JSON file
            return null;
        }

        public bool Exists(int id)
        {
            // TODO check whether customer object with given ID exists
            return false;
        }
    }
}