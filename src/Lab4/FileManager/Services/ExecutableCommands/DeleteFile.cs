using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class DeleteFile : ICommands
{
    private const int FileForDeletePathIndex = 2;
    private readonly string _mode;
    private readonly string[] _tokens;

    public DeleteFile(string[] tokens, string mode)
    {
        _tokens = tokens;
        _mode = mode;
    }

    public void Execute(ref string path)
    {
        if (_mode is "local")
        {
            var executeMode = new LocalModeCommandsExecution();
            var displayMode = new LocalDisplay();

            string file = _tokens[FileForDeletePathIndex];
            string fullPath = Path.Combine(file, path);

            if (executeMode.Exists(file))
            {
                executeMode.Delete(fullPath);
                displayMode.DisplayShow($"Deleted file: {file}");
            }
            else
            {
                displayMode.DisplayShow($"File not found: {file}");
            }
        }
    }
}