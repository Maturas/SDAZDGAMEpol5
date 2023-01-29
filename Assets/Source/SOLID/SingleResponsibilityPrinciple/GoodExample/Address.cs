namespace SDAZDGAMEpol5.SOLID.SingleResponsibilityPrinciple.GoodExample
{
    public struct Address
    {
        public int PostalCode { get; }
        public string City { get; }
        public string StreetName { get; }
        public int HouseNumber { get; }

        public Address(int postalCode, string city, string streetName, int houseNumber)
        {
            PostalCode = postalCode;
            City = city;
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
    }
}