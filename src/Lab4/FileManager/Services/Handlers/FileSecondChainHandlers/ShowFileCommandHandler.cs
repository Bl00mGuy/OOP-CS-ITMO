using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.FileSecondChainHandlers;

public class ShowFileCommandHandler : CommandHandler
{
    private const string CommandType = "show";
    private const int CommandTypeParseIndex = 1;
    private const int DoesntContainsIndex = -1;
    private const string CommandFlag = "-m";
    private const string CommandFlagParameter = "console";

    public override ICommands? HandleCommand(string command, IMode mode)
    {
        string[] tokens = command.Split(' ');

        if (tokens[CommandTypeParseIndex] is CommandType)
        {
            if (Array.IndexOf(tokens, CommandFlag) is not DoesntContainsIndex)
            {
                if (Array.IndexOf(tokens, CommandFlagParameter) is not DoesntContainsIndex)
                {
                    return new ShowFile(tokens, mode);
                }
            }
        }

        return NextHandler?.HandleCommand(command, mode);
    }
}