using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

public class ConnectionCommandHandler : CommandHandler
{
    private const string CommandType = "connect";
    private const int CommandTypeParseIndex = 0;
    private const int CommandPathParseIndex = 1;

    public override ICommands? HandleCommand(Command command)
    {
        string[] tokens = command.CmdRequest.Split(' ');

        if (tokens[CommandTypeParseIndex] is CommandType)
        {
            return new Connect(tokens[CommandPathParseIndex], command.Mode);
        }

        return NextHandler?.HandleCommand(command);
    }
}