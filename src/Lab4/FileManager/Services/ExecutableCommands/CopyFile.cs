using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class CopyFile : ICommands
{
    private const int SourcePathOfFileIndex = 2;
    private const int DestinationPathOfFileIndex = 3;
    private readonly IExecuteMode _executeMode;
    private readonly IDisplayMode _localDisplay;
    private readonly string[] _tokens;

    public CopyFile(string[] tokens, IExecuteMode mode, IDisplayMode localDisplay)
    {
        _tokens = tokens;
        _executeMode = mode;
        _localDisplay = localDisplay;
    }

    public void Execute(ref string path)
    {
        string sourcePath = _tokens[SourcePathOfFileIndex];
        string fullPath = Path.Combine(sourcePath, path);
        string destinationPath = _tokens[DestinationPathOfFileIndex];

        if (_executeMode.Exists(sourcePath))
        {
            string fileName = Path.GetFileNameWithoutExtension(destinationPath);
            string fileExtension = Path.GetExtension(destinationPath);

            if (_executeMode.Exists(destinationPath))
            {
                for (int i = 1; ; i++)
                {
                    string newName = $"{fileName}_({i}){fileExtension}";
                    string newFileDestinationPath = Path.Combine(Path.GetDirectoryName(destinationPath) ?? string.Empty, newName);

                    if (!_executeMode.Exists(newFileDestinationPath))
                    {
                        _executeMode.Copy(fullPath, newFileDestinationPath);
                    }
                }
            }
            else
            {
                _executeMode.Copy(fullPath, destinationPath);
            }

            _localDisplay.DisplayShow($"Copied file from {sourcePath} to {destinationPath}");
        }
        else
        {
            _localDisplay.DisplayShow($"File not found: {sourcePath}");
        }
    }
}