using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager;

public class Request
{
    private readonly ICommandHandler _commandHandler;
    private string? _path;

    public Request(ICommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public void ProcessRequest()
    {
        while (!string.IsNullOrEmpty(Console.ReadLine()))
        {
            string? request = Console.ReadLine();
            ICommands? cmd;
            if (request is not null)
            {
                cmd = new CommandParser(_commandHandler).Parsing(request, new LocalMode());
                if (_path is not null) cmd?.Execute(ref _path);
            }
        }
    }
}