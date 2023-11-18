using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;

public class LocalDisplay : IDisplayMode
{
    public void DisplayShow(string content)
    {
        Console.WriteLine(content);
    }
}