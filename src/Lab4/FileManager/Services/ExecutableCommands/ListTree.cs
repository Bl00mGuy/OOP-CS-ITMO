using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;

public class ListTree : ICommands
{
    private const int CommandTreeListDeepParseIndex = 3;
    private const int InitialDepth = 1;
    private const int StartTraversalDepth = 0;
    private readonly string _depth;
    private readonly IMode? _mode;

    public ListTree(IReadOnlyList<string> tokens, IMode? mode)
    {
        _depth = tokens[CommandTreeListDeepParseIndex];
        _mode = mode;
    }

    public void Execute(ref string? path)
    {
        _mode?.TreeList(path, _depth, InitialDepth, StartTraversalDepth);
    }
}