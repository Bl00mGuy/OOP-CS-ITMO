using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

public class FileCommandHandler : CommandHandler
{
    private const string CommandType = "file";
    private const int CommandTypeParseIndex = 0;
    private readonly ICommandHandler _chainLink;

    public FileCommandHandler(ICommandHandler chainLink)
    {
        _chainLink = chainLink;
    }

    public override ICommands? HandleCommand(string command, IMode mode)
    {
        string[] tokens = command.Split(' ');

        if (tokens[CommandTypeParseIndex] is CommandType)
        {
            return _chainLink.HandleCommand(command, mode);
        }
        else
        {
            return NextHandler?.HandleCommand(command, mode);
        }
    }
}