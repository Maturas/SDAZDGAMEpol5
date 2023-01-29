namespace SDAZDGAMEpol5.SOLID.DependencyInversionPrinciple.BadExample
{
    public class CustomerJSONRepository
    {
        private string FilePath { get; }

        public CustomerJSONRepository(string filePath)
        {
            FilePath = filePath;
        }

        public Customer Get(int id)
        {
            // TODO read customer object from JSON file with given ID
            return null;
        }

        public bool Exists(int id)
        {
            // TODO check whether a customer object with given ID exists in the JSON file
            return false;
        }
    }
}