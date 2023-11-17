using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

public abstract class CommandHandler : ICommandHandler
{
    protected ICommandHandler? NextHandler { get; private set;  }

    public ICommandHandler SetNextHandler(ICommandHandler handler)
    {
        NextHandler = handler;
        return this;
    }

    public abstract ICommands? HandleCommand(string command);
}