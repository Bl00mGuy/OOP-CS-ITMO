using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class Disconnect : ICommands
{
    private readonly IMode? _mode;

    public Disconnect(IMode? mode)
    {
        _mode = mode;
    }

    public void Execute(ref string? path)
    {
        _mode?.Disconnect(ref path);
    }
}