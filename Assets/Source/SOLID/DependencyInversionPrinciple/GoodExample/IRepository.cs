namespace SDAZDGAMEpol5.SOLID.DependencyInversionPrinciple.GoodExample
{
    public interface IRepository<T>
    {
        T Get(int id);
        bool Exists(int id);
    }
}