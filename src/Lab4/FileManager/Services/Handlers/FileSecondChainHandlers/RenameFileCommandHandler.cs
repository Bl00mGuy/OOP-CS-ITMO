using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.FileSecondChainHandlers;

public class RenameFileCommandHandler : CommandHandler
{
    private const string CommandType = "rename";
    private const int CommandTypeParseIndex = 1;

    public override ICommands? HandleCommand(string command, string mode)
    {
        string[] tokens = command.Split(' ');

        if (tokens[CommandTypeParseIndex] is CommandType)
        {
            return new RenameFile(tokens, mode);
        }
        else
        {
            return NextHandler?.HandleCommand(command, mode);
        }
    }
}