namespace SDAZDGAMEpol5.SOLID.InterfaceSegregationPrinciple.BadExample
{
    /// <summary>
    ///     A massive, not very universal interface, consisting of multiple methods, is a violation of the Interface Segregation Principle
    /// </summary>
    public interface IHuman
    {
        string GetName(); // not only humans have names
        void Sleep(); // not only humans sleep
        void Eat(); // not only humans eat
        void Talk(); // not only humans talk
        void GoToWork(); // only humans go to work
    }
}