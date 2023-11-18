using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class CopyFile : ICommands
{
    private const int SourcePathOfFileIndex = 2;
    private const int DestinationPathOfFileIndex = 3;
    private readonly string _mode;
    private readonly string[] _tokens;

    public CopyFile(string[] tokens, string mode)
    {
        _tokens = tokens;
        _mode = mode;
    }

    public void Execute(ref string path)
    {
        string sourcePath = _tokens[SourcePathOfFileIndex];
        string fullPath = Path.Combine(sourcePath, path);
        string destinationPath = _tokens[DestinationPathOfFileIndex];

        if (_mode is "local")
        {
            var executeMode = new LocalModeCommandsExecution();
            var displayMode = new LocalDisplay();

            if (executeMode.Exists(sourcePath))
            {
                string fileName = Path.GetFileNameWithoutExtension(destinationPath);
                string fileExtension = Path.GetExtension(destinationPath);

                if (executeMode.Exists(destinationPath))
                {
                    for (int i = 1; ; i++)
                    {
                        string newName = $"{fileName}_({i}){fileExtension}";
                        string newFileDestinationPath =
                            Path.Combine(Path.GetDirectoryName(destinationPath) ?? string.Empty, newName);

                        if (!executeMode.Exists(newFileDestinationPath))
                        {
                            executeMode.Copy(fullPath, newFileDestinationPath);
                        }
                    }
                }
                else
                {
                    executeMode.Copy(fullPath, destinationPath);
                }

                displayMode.DisplayShow($"Copied file from {sourcePath} to {destinationPath}");
            }
            else
            {
                displayMode.DisplayShow($"File not found: {sourcePath}");
            }
        }
    }
}