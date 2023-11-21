using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services;

public class Command
{
    public Command(string cmd)
    {
        CmdRequest = cmd;
    }

    public string CmdRequest { get; }
    public IMode? Mode { get; private set; }

    public void SetMode(IMode? mode)
    {
        Mode = mode;
    }
}