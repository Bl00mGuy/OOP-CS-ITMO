using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

public abstract class DisconnectionCommandHandler : CommandHandler
{
    private const string CommandType = "disconnect";
    private const int CommandTypeParseIndex = 0;

    public override ICommands? HandleCommand(string command, IMode mode)
    {
        string[] tokens = command.Split(' ');

        if (tokens[CommandTypeParseIndex] is CommandType)
        {
            return new Disconnect();
        }
        else
        {
            return NextHandler?.HandleCommand(command, mode);
        }
    }
}