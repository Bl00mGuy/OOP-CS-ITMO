using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.FileSecondChainHandlers;

public class DeleteFileCommandHandler : CommandHandler
{
    private const string CommandType = "delete";
    private const int CommandTypeParseIndex = 1;

    public override ICommands? HandleCommand(string command)
    {
        string[] tokens = command.Split(' ');

        if (tokens[CommandTypeParseIndex] is CommandType)
        {
            return new DeleteFile(tokens, new LocalModeCommandsExecution(), new LocalDisplay());
        }
        else
        {
            return NextHandler?.HandleCommand(command);
        }
    }
}