using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class MoveFile : ICommands
{
    private const int SourcePathOfFileIndex = 2;
    private const int DestinationPathOfFileIndex = 3;
    private readonly string[] _tokens;

    public MoveFile(string[] tokens)
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
            File.Move(fullPath, destinationPath, true);
            Console.WriteLine($"Moved file from {sourcePath} to {destinationPath}");
        }
        else
        {
            Console.WriteLine($"File not found: {sourcePath}");
        }
    }
}