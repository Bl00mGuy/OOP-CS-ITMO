using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class ShowFile : ICommands
{
    private const int CommandPathParseIndex = 2;
    private readonly IMode _mode;
    private readonly string[] _tokens;

    public ShowFile(string[] tokens, IMode mode)
    {
        _tokens = tokens;
        _mode = mode;
    }

    public void Execute(ref string? path)
    {
        if (path is null)
        {
            return;
        }

        string showPath = _tokens[CommandPathParseIndex];
        string fullPath = Path.Combine(showPath, path);

        if (_mode.Exists(showPath))
        {
            string content = _mode.Show(fullPath);
            _mode.DisplayShow($"#-----{Path.GetFileNameWithoutExtension(showPath)} CONTENT-----#");
            _mode.DisplayShow(content);
            _mode.DisplayShow("#---------------#");
        }
        else
        {
            _mode.DisplayShow($"File not found: {showPath}");
        }
    }
}