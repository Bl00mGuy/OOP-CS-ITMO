using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

public abstract class DisconnectionCommandHandler : CommandHandler
{
    private const string CommandType = "disconnect";
    private const int CommandTypeParseIndex = 0;

    public override ICommands? HandleCommand(Command command)
    {
        string[] tokens = command.CmdRequest.Split(' ');

        if (tokens[CommandTypeParseIndex] is CommandType)
        {
            return new Disconnect(command.Mode);
        }
        else
        {
            return NextHandler?.HandleCommand(command);
        }
    }
}