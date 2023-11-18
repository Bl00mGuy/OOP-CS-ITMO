using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class ListTree : ICommands
{
    private const int CommandTreeListDeepParseIndex = 3;
    private const int InitialDepth = 3;
    private const int StartTraversalDepth = 0;
    private readonly string[] _tokens;
    private readonly IMode _mode;

    public ListTree(string[] tokens, IMode mode)
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

        if (int.TryParse(_tokens[CommandTreeListDeepParseIndex], out int depth))
        {
            TreeTraversal(path, depth, StartTraversalDepth);
        }
        else
        {
            TreeTraversal(path, InitialDepth, StartTraversalDepth);
        }
    }

    private void TreeTraversal(string root, int maxDepth, int currentDepth)
    {
        if (currentDepth > maxDepth)
        {
            return;
        }

        string indent = new string(' ', currentDepth * 2);
        _mode.DisplayShow($"{indent}[{Path.GetFileName(root)}]");

        foreach (string directory in Directory.GetDirectories(root))
        {
            TreeTraversal(directory, maxDepth, currentDepth + 1);
        }

        foreach (string file in Directory.GetFiles(root))
        {
            _mode.DisplayShow($"{indent}  {Path.GetFileName(file)}");
        }
    }
}