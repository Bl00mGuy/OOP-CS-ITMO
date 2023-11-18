using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class ShowFile : ICommands
{
    private const int CommandPathParseIndex = 2;
    private readonly string _mode;
    private readonly string[] _tokens;

    public ShowFile(string[] tokens, string mode)
    {
        _tokens = tokens;
        _mode = mode;
    }

    public void Execute(ref string path)
    {
        if (_mode is "local")
        {
            var executeMode = new LocalModeCommandsExecution();
            var displayMode = new LocalDisplay();

            string showPath = _tokens[CommandPathParseIndex];
            string fullPath = Path.Combine(showPath, path);

            if (executeMode.Exists(showPath))
            {
                string content = executeMode.Show(fullPath);
                displayMode.DisplayShow($"🤓🤓🤓{Path.GetFileNameWithoutExtension(showPath)} CONTENT🤓🤓🤓");
                displayMode.DisplayShow(content);
                displayMode.DisplayShow("🤓🤓🤓🤓🤓🤓🤓🤓🤓🤓🤓🤓");
            }
            else
            {
                displayMode.DisplayShow($"File not found: {showPath}");
            }
        }
    }
}