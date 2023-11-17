using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

public class TreeCommandHandler : CommandHandler
{
    private const string CommandType = "tree";
    private const int CommandTypeParseIndex = 0;
    private readonly ICommandHandler _chainLink;

    public TreeCommandHandler(ICommandHandler chainLink)
    {
        _chainLink = chainLink;
    }

    public override ICommands? HandleCommand(string command)
    {
        if (command != null)
        {
            string[] tokens = command.Split(' ');

            if (tokens[CommandTypeParseIndex] is CommandType)
            {
                return _chainLink.HandleCommand(command);
            }
            else
            {
                return NextHandler?.HandleCommand(command);
            }
        }

        return null;
    }
}