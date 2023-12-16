namespace Itmo.ObjectOrientedProgramming.Lab2.PersonalComputer.Services;

public interface IRepository
{
    IComponent? FindComponent(string name);
    void AddComponent(IComponent component);
}