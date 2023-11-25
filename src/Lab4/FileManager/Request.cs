using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
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
        string? request;
        while (!string.IsNullOrEmpty(request = Console.ReadLine()))
        {
            ICommands? cmd;
            if (request is not null)
            {
                cmd = new CommandParser(_commandHandler).Parsing(request);
                cmd?.Execute(ref _path);
            }
        }
    }
}