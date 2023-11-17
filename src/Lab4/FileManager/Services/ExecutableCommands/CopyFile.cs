using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class CopyFile : ICommands
{
    private const int SourcePathOfFileIndex = 2;
    private const int DestinationPathOfFileIndex = 3;
    private readonly string[] _tokens;

    public CopyFile(string[] tokens)
    {
        _tokens = tokens;
    }

    public void Execute(ref string path)
    {
        string sourcePath = _tokens[SourcePathOfFileIndex];
        string fullPath = Path.Combine(sourcePath, path);
        string destinationPath = _tokens[DestinationPathOfFileIndex];

        if (File.Exists(sourcePath))
        {
            string fileName = Path.GetFileNameWithoutExtension(destinationPath);
            string fileExtension = Path.GetExtension(destinationPath);

            if (File.Exists(destinationPath))
            {
                for (int i = 1; ; i++)
                {
                    string newName = $"{fileName}_({i}){fileExtension}";
                    string newFileDestinationPath = Path.Combine(Path.GetDirectoryName(destinationPath) ?? string.Empty, newName);

                    if (!File.Exists(newFileDestinationPath))
                    {
                        File.Copy(fullPath, newFileDestinationPath);
                    }
                }
            }
            else
            {
                File.Copy(fullPath, destinationPath);
            }

            Console.WriteLine($"Copied file from {sourcePath} to {destinationPath}");
        }
        else
        {
            Console.WriteLine($"File not found: {sourcePath}");
        }
    }
}