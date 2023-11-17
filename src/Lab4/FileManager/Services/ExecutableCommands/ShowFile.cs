using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class ShowFile : ICommands
{
    private const int CommandPathParseIndex = 2;
    private readonly string[] _tokens;

    public ShowFile(string[] tokens)
    {
        _tokens = tokens;
    }

    public void Execute(ref string path)
    {
        string showPath = _tokens[CommandPathParseIndex];
        string fullPath = Path.Combine(showPath, path);

        if (File.Exists(showPath))
        {
            string content = File.ReadAllText(fullPath);
            Console.WriteLine($"🤓🤓🤓{Path.GetFileNameWithoutExtension(showPath)} CONTENT🤓🤓🤓");
            Console.WriteLine(content);
            Console.WriteLine("🤓🤓🤓🤓🤓🤓🤓🤓🤓🤓🤓🤓");
        }
        else
        {
            Console.WriteLine($"File not found: {showPath}");
        }
    }
}