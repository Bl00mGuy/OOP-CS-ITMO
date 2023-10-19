namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

public class Repository
{
    private ShopComponentsDatabase database = new ShopComponentsDatabase();

    public IComponent? FindComponent(string name)
    {
        return database.Find(name);
    }

    public void AddComponent(IComponent component)
    {
        database.Update(component);
    }
}