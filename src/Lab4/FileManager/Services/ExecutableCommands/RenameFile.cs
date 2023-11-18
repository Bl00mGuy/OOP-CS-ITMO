using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class RenameFile : ICommands
{
    private const int NameOfFileIndex = 2;
    private const int NewNameOfFileIndex = 3;
    private readonly IExecuteMode _executeMode;
    private readonly IDisplayMode _displayMode;
    private readonly string[] _tokens;

    public RenameFile(string[] tokens, IExecuteMode mode, IDisplayMode displayMode)
    {
        _tokens = tokens;
        _executeMode = mode;
        _displayMode = displayMode;
    }

    public void Execute(ref string path)
    {
        string namePath = _tokens[NameOfFileIndex];
        string fullPath = Path.Combine(namePath, path);
        string newName = _tokens[NewNameOfFileIndex];

        if (_executeMode.Exists(namePath))
        {
            _executeMode.Rename(fullPath, newName);
            _displayMode.DisplayShow($"Renamed file from {namePath} to {newName}");
        }
        else
        {
            _displayMode.DisplayShow($"File not found: {namePath}");
        }
    }
}