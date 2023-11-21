using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class Connect : ICommands
{
    private readonly string _absolutePath;
    private readonly IMode? _mode;

    public Connect(string absolutePath, IMode? mode)
    {
        _absolutePath = absolutePath;
        _mode = mode;
    }

    public void Execute(ref string? path)
    {
        _mode?.Connect(ref path, _absolutePath);
    }
}