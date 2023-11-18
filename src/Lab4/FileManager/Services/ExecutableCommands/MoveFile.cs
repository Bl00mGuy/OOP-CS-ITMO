using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class MoveFile : ICommands
{
    private const int SourcePathOfFileIndex = 2;
    private const int DestinationPathOfFileIndex = 3;
    private readonly string _mode;
    private readonly string[] _tokens;

    public MoveFile(string[] tokens, string mode)
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

            string sourcePath = _tokens[SourcePathOfFileIndex];
            string fullPath = Path.Combine(sourcePath, path);
            string destinationPath = _tokens[DestinationPathOfFileIndex];

            if (executeMode.Exists(sourcePath))
            {
                executeMode.Move(fullPath, destinationPath);
                displayMode.DisplayShow($"Moved file from {sourcePath} to {destinationPath}");
            }
            else
            {
                displayMode.DisplayShow($"File not found: {sourcePath}");
            }
        }
    }
}