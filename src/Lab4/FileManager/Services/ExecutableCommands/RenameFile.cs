using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class RenameFile : ICommands
{
    private const int NameOfFileIndex = 2;
    private const int NewNameOfFileIndex = 3;
    private readonly IMode _mode;
    private readonly string[] _tokens;

    public RenameFile(string[] tokens, IMode mode)
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

        string namePath = _tokens[NameOfFileIndex];
        string fullPath = Path.Combine(namePath, path);
        string newName = _tokens[NewNameOfFileIndex];

        if (_mode.Exists(namePath))
        {
            _mode.Rename(fullPath, newName);
            _mode.DisplayShow($"Renamed file from {namePath} to {newName}");
        }
        else
        {
            _mode.DisplayShow($"File not found: {namePath}");
        }
    }
}