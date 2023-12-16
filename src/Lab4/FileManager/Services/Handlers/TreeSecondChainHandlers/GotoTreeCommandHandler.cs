using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.TreeSecondChainHandlers;

public class GotoTreeCommandHandler : CommandHandler
{
    private const string CommandType = "goto";
    private const int CommandTypeParseIndex = 1;
    private const int CommandPathParseIndex = 2;

    public override ICommands? HandleCommand(Command command)
    {
        string[] tokens = command.CmdRequest.Split(' ');

        if (tokens[CommandTypeParseIndex] is CommandType)
        {
            return new GotoTree(tokens[CommandPathParseIndex], command.Mode);
        }
        else
        {
            return NextHandler?.HandleCommand(command);
        }
    }
}