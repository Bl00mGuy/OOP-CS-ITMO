using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class DeleteFile : ICommands
{
    private const int FileForDeletePathIndex = 2;
    private readonly IExecuteMode _executeMode;
    private readonly IDisplayMode _displayMode;
    private readonly string[] _tokens;

    public DeleteFile(string[] tokens, IExecuteMode mode, IDisplayMode displayMode)
    {
        _tokens = tokens;
        _executeMode = mode;
        _displayMode = displayMode;
    }

    public void Execute(ref string path)
    {
        string file = _tokens[FileForDeletePathIndex];
        string fullPath = Path.Combine(file, path);

        if (_executeMode.Exists(file))
        {
            _executeMode.Delete(fullPath);
            _displayMode.DisplayShow($"Deleted file: {file}");
        }
        else
        {
            _displayMode.DisplayShow($"File not found: {file}");
        }
    }
}