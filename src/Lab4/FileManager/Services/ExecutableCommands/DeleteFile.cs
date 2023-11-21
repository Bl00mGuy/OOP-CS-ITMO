using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class DeleteFile : ICommands
{
    private const int FileForDeletePathIndex = 2;
    private readonly IMode? _mode;
    private readonly string _filePath;

    public DeleteFile(IReadOnlyList<string> tokens, IMode? mode)
    {
        _filePath = tokens[FileForDeletePathIndex];
        _mode = mode;
    }

    public void Execute(ref string? path)
    {
        _mode?.Delete(path, _filePath);
    }
}