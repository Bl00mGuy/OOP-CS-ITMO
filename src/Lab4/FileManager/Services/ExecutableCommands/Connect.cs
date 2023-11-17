namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class Connect : ICommands
{
    private string _absolutePath;

    public Connect(string absolutePath)
    {
        _absolutePath = absolutePath;
    }

    public void Execute(ref string path)
    {
        _absolutePath = path;
        path = _absolutePath;
    }
}