using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class MoveFile : ICommands
{
    private const int SourcePathOfFileIndex = 2;
    private const int DestinationPathOfFileIndex = 3;
    private readonly IMode _mode;
    private readonly string[] _tokens;

    public MoveFile(string[] tokens, IMode mode)
    {
        _tokens = tokens;
        _mode = mode;
    }

    public void Execute(ref string? path)
    {
        if (path is null)
        {
            return;
        }

        string sourcePath = _tokens[SourcePathOfFileIndex];
        string fullPath = Path.Combine(sourcePath, path);
        string destinationPath = _tokens[DestinationPathOfFileIndex];

        if (_mode.Exists(sourcePath))
        {
            _mode.Move(fullPath, destinationPath);
            _mode.DisplayShow($"Moved file from {sourcePath} to {destinationPath}");
        }
        else
        {
            _mode.DisplayShow($"File not found: {sourcePath}");
        }
    }
}