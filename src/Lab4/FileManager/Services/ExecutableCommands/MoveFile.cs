using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class MoveFile : ICommands
{
    private const int SourcePathOfFileIndex = 2;
    private const int DestinationPathOfFileIndex = 3;
    private readonly IExecuteMode _executeMode;
    private readonly IDisplayMode _displayMode;
    private readonly string[] _tokens;

    public MoveFile(string[] tokens, IExecuteMode mode, IDisplayMode displayMode)
    {
        _tokens = tokens;
        _executeMode = mode;
        _displayMode = displayMode;
    }

    public void Execute(ref string path)
    {
        string sourcePath = _tokens[SourcePathOfFileIndex];
        string fullPath = Path.Combine(sourcePath, path);
        string destinationPath = _tokens[DestinationPathOfFileIndex];

        if (_executeMode.Exists(sourcePath))
        {
            _executeMode.Move(fullPath, destinationPath);
            _displayMode.DisplayShow($"Moved file from {sourcePath} to {destinationPath}");
        }
        else
        {
            _displayMode.DisplayShow($"File not found: {sourcePath}");
        }
    }
}