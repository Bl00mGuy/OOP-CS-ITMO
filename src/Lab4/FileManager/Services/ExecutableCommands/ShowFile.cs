using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class ShowFile : ICommands
{
    private const int CommandPathParseIndex = 2;
    private readonly IExecuteMode _executeMode;
    private readonly IDisplayMode _displayMode;
    private readonly string[] _tokens;

    public ShowFile(string[] tokens, IExecuteMode mode, IDisplayMode displayMode)
    {
        _tokens = tokens;
        _executeMode = mode;
        _displayMode = displayMode;
    }

    public void Execute(ref string path)
    {
        string showPath = _tokens[CommandPathParseIndex];
        string fullPath = Path.Combine(showPath, path);

        if (_executeMode.Exists(showPath))
        {
            string content = _executeMode.Show(fullPath);
            _displayMode.DisplayShow($"🤓🤓🤓{Path.GetFileNameWithoutExtension(showPath)} CONTENT🤓🤓🤓");
            _displayMode.DisplayShow(content);
            _displayMode.DisplayShow("🤓🤓🤓🤓🤓🤓🤓🤓🤓🤓🤓🤓");
        }
        else
        {
            _displayMode.DisplayShow($"File not found: {showPath}");
        }
    }
}