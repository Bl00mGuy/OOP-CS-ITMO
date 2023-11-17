using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

public class ConnectionCommandHandler : CommandHandler
{
    private const string CommandType = "connect";
    private const int CommandTypeParseIndex = 0;
    private const int DoesntContainsIndex = -1;
    private const int CommandPathParseIndex = 1;
    private const string CommandFlag = "-m";
    private const string CommandFlagParameter = "local";

    public override ICommands? HandleCommand(string command)
    {
        if (command != null)
        {
            string[] tokens = command.Split(' ');

            if (tokens[CommandTypeParseIndex] is CommandType)
            {
                if (Array.IndexOf(tokens, CommandFlag) is not DoesntContainsIndex)
                {
                    if (Array.IndexOf(tokens, CommandFlagParameter) is not DoesntContainsIndex)
                    {
                        return new Connect(tokens[CommandPathParseIndex]);
                    }
                }
            }
            else
            {
                return NextHandler?.HandleCommand(command);
            }
        }

        return null;
    }
}