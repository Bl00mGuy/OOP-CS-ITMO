using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.Render;

public class ConsoleRender : IRenderable
{
    public void Render(string data)
    {
        Console.WriteLine(data);
    }
}