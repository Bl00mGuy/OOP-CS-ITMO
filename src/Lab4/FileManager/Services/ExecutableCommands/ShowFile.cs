using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class ShowFile : ICommands
{
    private const int CommandPathParseIndex = 2;
    private readonly IMode? _mode;
    private readonly string _showPath;

    public ShowFile(IReadOnlyList<string> tokens, IMode? mode)
    {
        _showPath = tokens[CommandPathParseIndex];
        _mode = mode;
    }

    public void Execute(ref string? path)
    {
        _mode?.Show(path, _showPath);
    }
}