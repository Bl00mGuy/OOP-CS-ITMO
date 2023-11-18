using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

public interface ICommandHandler
{
    ICommandHandler SetNextHandler(ICommandHandler handler);
    ICommands? HandleCommand(string command, string mode);
}