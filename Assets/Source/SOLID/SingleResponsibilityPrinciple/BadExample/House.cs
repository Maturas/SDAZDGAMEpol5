using System.Collections.Generic;

namespace SDAZDGAMEpol5.SOLID.SingleResponsibilityPrinciple.BadExample
{
    /// <summary>
    ///     This is an example of breaking the Single Responsibility Principle
    ///     This single class attempts to represent a house, its address and the people who live in it, with a single object
    /// </summary>
    public class House
    {
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        
        public string WallColor { get; set; }
        public string RoofColor { get; set; }
        public int WallInsulationThickness { get; set; }
        public int AmountOfRooms { get; set; }
        public bool HasGarage { get; set; }

        public List<string> InhabitantsFirstNames { get; set; }
        public List<string> InhabitantsLastNames { get; set; }
        public List<int> InhabitantsYearOfBirth { get; set; }

        public House(int postalCode, string city, string streetName, int houseNumber, string wallColor, string roofColor, int wallInsulationThickness, int amountOfRooms, bool hasGarage, List<string> inhabitantsFirstNames, List<string> inhabitantsLastNames, List<int> inhabitantsYearOfBirth)
        {
            PostalCode = postalCode;
            City = city;
            StreetName = streetName;
            HouseNumber = houseNumber;
            WallColor = wallColor;
            RoofColor = roofColor;
            WallInsulationThickness = wallInsulationThickness;
            AmountOfRooms = amountOfRooms;
            HasGarage = hasGarage;
            InhabitantsFirstNames = inhabitantsFirstNames;
            InhabitantsLastNames = inhabitantsLastNames;
            InhabitantsYearOfBirth = inhabitantsYearOfBirth;
        }
    }
}