namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

public class Repository : IRepository
{
    private readonly ShopComponentsDatabase database = new ShopComponentsDatabase();

    public IComponent? FindComponent(string name)
    {
        return database.Find(name);
    }

    public void AddComponent(IComponent component)
    {
        database.Update(component);
    }
}