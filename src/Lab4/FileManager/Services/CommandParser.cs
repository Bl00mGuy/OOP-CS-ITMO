using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services;

public class CommandParser
{
    private readonly ICommandHandler _chainOfResponsibility;

    public CommandParser(ICommandHandler chainOfResponsibility)
    {
        _chainOfResponsibility = chainOfResponsibility;
    }

    public ICommands? Parsing(string request, string mode)
    {
        return _chainOfResponsibility.HandleCommand(request, mode);
    }
}