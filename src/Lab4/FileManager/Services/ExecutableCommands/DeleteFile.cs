using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class DeleteFile : ICommands
{
    private const int FileForDeletePathIndex = 2;
    private readonly string[] _tokens;

    public DeleteFile(string[] tokens)
    {
        _tokens = tokens;
    }

    public void Execute(ref string path)
    {
        string file = _tokens[FileForDeletePathIndex];
        string fullPath = Path.Combine(file, path);

        if (File.Exists(file))
        {
            File.Delete(fullPath);
            Console.WriteLine($"Deleted file: {file}");
        }
        else
        {
            Console.WriteLine($"File not found: {file}");
        }
    }
}