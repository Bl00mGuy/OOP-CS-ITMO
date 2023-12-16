using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class CopyFile : ICommands
{
    private const int SourcePathOfFileIndex = 2;
    private const int DestinationPathOfFileIndex = 3;
    private readonly IMode? _mode;
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public CopyFile(IReadOnlyList<string> tokens, IMode? mode)
    {
        _sourcePath = tokens[SourcePathOfFileIndex];
        _destinationPath = tokens[DestinationPathOfFileIndex];
        _mode = mode;
    }

    public void Execute(ref string? path)
    {
        _mode?.Copy(path, _sourcePath, _destinationPath);
    }
}