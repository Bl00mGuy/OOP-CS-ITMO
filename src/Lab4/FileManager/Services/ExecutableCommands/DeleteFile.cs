using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class DeleteFile : ICommands
{
    private const int FileForDeletePathIndex = 2;
    private readonly IMode _mode;
    private readonly string[] _tokens;

    public DeleteFile(string[] tokens, IMode mode)
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

        string file = _tokens[FileForDeletePathIndex];
        string fullPath = Path.Combine(file, path);

        if (_mode.Exists(file))
        {
            _mode.Delete(fullPath);
            _mode.DisplayShow($"Deleted file: {file}");
        }
        else
        {
            _mode.DisplayShow($"File not found: {file}");
        }
    }
}