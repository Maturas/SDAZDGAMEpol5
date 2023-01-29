using System.Collections.Generic;

namespace SDAZDGAMEpol5.SOLID.SingleResponsibilityPrinciple.GoodExample
{
    /// <summary>
    ///     This is an example of abiding by the Single Responsibility Principle
    ///     There are separate classes for representing separate objects - House, Person, Address
    /// </summary>
    public class House
    {
        public Address Address { get; }
        public List<Person> Inhabitants { get; }
        
        public string WallColor { get; set; }
        public string RoofColor { get; set; }
        public int WallInsulationThickness { get; set; }
        public int AmountOfRooms { get; set; }
        public bool HasGarage { get; set; }

        public House(Address address, List<Person> inhabitants, string wallColor, string roofColor, int wallInsulationThickness, int amountOfRooms, bool hasGarage)
        {
            Address = address;
            Inhabitants = inhabitants;
            WallColor = wallColor;
            RoofColor = roofColor;
            WallInsulationThickness = wallInsulationThickness;
            AmountOfRooms = amountOfRooms;
            HasGarage = hasGarage;
        }
    }
}