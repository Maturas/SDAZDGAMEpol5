namespace SDAZDGAMEpol5.SOLID.InterfaceSegregationPrinciple.GoodExample
{
    /// <summary>
    ///     This interface extends a set of smaller interfaces, which is beneficial in two ways.
    ///     First, the small interfaces are more universal and can be used in more classes.
    ///     Second, the IHuman is as convenient to use as the big interface from Bad Example.
    /// </summary>
    public interface IHuman : ISleepable, IEatable, ITalkable, IName
    {
        void GoToWork();
    }
}