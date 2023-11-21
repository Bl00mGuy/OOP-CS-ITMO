using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

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

    public override ICommands? HandleCommand(Command command)
    {
        string[] tokens = command.CmdRequest.Split(' ');

        if (tokens[CommandTypeParseIndex] is CommandType)
        {
            return _chainLink.HandleCommand(command);
        }
        else
        {
            return NextHandler?.HandleCommand(command);
        }
    }
}