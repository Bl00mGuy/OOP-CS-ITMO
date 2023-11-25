using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.FileSecondChainHandlers;

public class ShowFileCommandHandler : CommandHandler
{
    private const string CommandType = "show";
    private const int CommandTypeParseIndex = 1;
    private const int DoesntContainsIndex = -1;
    private const string CommandFlag = "-m";
    private const string CommandFlagParameter = "console";

    public override ICommands? HandleCommand(Command command)
    {
        string[] tokens = command.CmdRequest.Split(' ');

        if (tokens[CommandTypeParseIndex] is CommandType)
        {
            if (Array.IndexOf(tokens, CommandFlag) is not DoesntContainsIndex)
            {
                if (Array.IndexOf(tokens, CommandFlagParameter) is not DoesntContainsIndex)
                {
                    return new ShowFile(tokens, command.Mode);
                }
            }
        }
        else
        {
            return NextHandler?.HandleCommand(command);
        }

        return null;
    }
}