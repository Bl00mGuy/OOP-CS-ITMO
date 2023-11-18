using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.FileSecondChainHandlers;

public class CopyFileCommandHandler : CommandHandler
{
    private const string CommandType = "copy";
    private const int CommandTypeParseIndex = 1;

    public override ICommands? HandleCommand(string command, IMode mode)
    {
        string[] tokens = command.Split(' ');

        if (tokens[CommandTypeParseIndex] is CommandType)
        {
            return new CopyFile(tokens, mode);
        }
        else
        {
            return NextHandler?.HandleCommand(command, mode);
        }
    }
}