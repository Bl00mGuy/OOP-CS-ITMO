using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class RenameFile : ICommands
{
    private const int NameOfFileIndex = 2;
    private const int NewNameOfFileIndex = 3;
    private readonly string _mode;
    private readonly string[] _tokens;

    public RenameFile(string[] tokens, string mode)
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

            string namePath = _tokens[NameOfFileIndex];
            string fullPath = Path.Combine(namePath, path);
            string newName = _tokens[NewNameOfFileIndex];

            if (executeMode.Exists(namePath))
            {
                executeMode.Rename(fullPath, newName);
                displayMode.DisplayShow($"Renamed file from {namePath} to {newName}");
            }
            else
            {
                displayMode.DisplayShow($"File not found: {namePath}");
            }
        }
    }
}