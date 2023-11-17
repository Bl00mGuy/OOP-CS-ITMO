using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.FileSecondChainHandlers;

public class DeleteFileCommandHandler : CommandHandler
{
    private const string CommandType = "delete";
    private const int CommandTypeParseIndex = 1;

    public override ICommands? HandleCommand(string command)
    {
        if (command != null)
        {
            string[] tokens = command.Split(' ');

            if (tokens[CommandTypeParseIndex] is CommandType)
            {
                return new DeleteFile(tokens);
            }
            else
            {
                return NextHandler?.HandleCommand(command);
            }
        }

        return null;
    }
}