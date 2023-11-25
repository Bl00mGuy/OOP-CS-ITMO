using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;

public class TypeOfConnectionHandler : CommandHandler
{
    private const int CommandTypeParseIndex = 0;
    private readonly string _accesableType = "local";
    private readonly ICommandHandler _chainLink;

    public TypeOfConnectionHandler(ICommandHandler chainLink)
    {
        _chainLink = chainLink;
    }

    public string? Mode { get; private set; }

    public override ICommands? HandleCommand(Command command)
    {
        string[] tokens = command.CmdRequest.Split(' ');
        if (tokens[CommandTypeParseIndex] is "connect")
        {
            int indexOfMOption = Array.IndexOf(tokens, "-m");
            if (indexOfMOption != -1 && indexOfMOption < tokens.Length - 1)
            {
                int indexOfConnectionType = indexOfMOption + 1;
                Mode = tokens[indexOfConnectionType];
            }
        }

        if (Mode is not null)
        {
            if (Mode.Equals(_accesableType, StringComparison.Ordinal))
            {
                command.SetMode(new LocalMode());
                return _chainLink.HandleCommand(command);
            }
        }
        else
        {
            return NextHandler?.HandleCommand(command);
        }

        return null;
    }
}