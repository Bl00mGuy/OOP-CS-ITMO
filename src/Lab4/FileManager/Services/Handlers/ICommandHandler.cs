using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

public interface ICommandHandler
{
    ICommandHandler SetNextHandler(ICommandHandler handler);
    ICommands? HandleCommand(string command, IMode mode);
}