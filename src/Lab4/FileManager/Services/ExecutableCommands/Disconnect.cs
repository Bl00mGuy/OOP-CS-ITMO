using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class Disconnect : ICommands
{
    public void Execute(ref string? path)
    {
        path = string.Empty;
        Environment.Exit(0);
    }
}