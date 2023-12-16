using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class RenameFile : ICommands
{
    private const int NameOfFileIndex = 2;
    private const int NewNameOfFileIndex = 3;
    private readonly IMode? _mode;
    private readonly string _namePath;
    private readonly string _newName;

    public RenameFile(IReadOnlyList<string> tokens, IMode? mode)
    {
        _namePath = tokens[NameOfFileIndex];
        _newName = tokens[NewNameOfFileIndex];
        _mode = mode;
    }

    public void Execute(ref string? path)
    {
        _mode?.Rename(path, _namePath, _newName);
    }
}