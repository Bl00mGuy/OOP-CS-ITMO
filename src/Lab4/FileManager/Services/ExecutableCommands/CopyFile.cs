using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class CopyFile : ICommands
{
    private const int SourcePathOfFileIndex = 2;
    private const int DestinationPathOfFileIndex = 3;
    private readonly IMode _mode;
    private readonly string[] _tokens;

    public CopyFile(string[] tokens, IMode mode)
    {
        _tokens = tokens;
        _mode = mode;
    }

    public void Execute(ref string path)
    {
        string sourcePath = _tokens[SourcePathOfFileIndex];
        string fullPath = Path.Combine(sourcePath, path);
        string destinationPath = _tokens[DestinationPathOfFileIndex];

        if (_mode.Exists(sourcePath))
        {
            string fileName = Path.GetFileNameWithoutExtension(destinationPath);
            string fileExtension = Path.GetExtension(destinationPath);

            if (_mode.Exists(destinationPath))
            {
                for (int i = 1; ; i++)
                {
                    string newName = $"{fileName}_({i}){fileExtension}";
                    string newFileDestinationPath =
                        Path.Combine(Path.GetDirectoryName(destinationPath) ?? string.Empty, newName);

                    if (!_mode.Exists(newFileDestinationPath))
                    {
                        _mode.Copy(fullPath, newFileDestinationPath);
                    }
                }
            }
            else
            {
                _mode.Copy(fullPath, destinationPath);
            }

            _mode.DisplayShow($"Copied file from {sourcePath} to {destinationPath}");
        }
        else
        {
            _mode.DisplayShow($"File not found: {sourcePath}");
        }
    }
}