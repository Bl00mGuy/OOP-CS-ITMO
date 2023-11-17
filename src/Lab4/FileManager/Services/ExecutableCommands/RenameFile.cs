using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class RenameFile : ICommands
{
    private const int NameOfFileIndex = 2;
    private const int NewNameOfFileIndex = 3;
    private readonly string[] _tokens;

    public RenameFile(string[] tokens)
    {
        _tokens = tokens;
    }

    public void Execute(ref string path)
    {
        string namePath = _tokens[NameOfFileIndex];
        string fullPath = Path.Combine(namePath, path);
        string newName = _tokens[NewNameOfFileIndex];

        if (File.Exists(namePath))
        {
            File.Move(fullPath, newName);
            Console.WriteLine($"Renamed file from {namePath} to {newName}");
        }
        else
        {
            Console.WriteLine($"File not found: {namePath}");
        }
    }
}