using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.FileSecondChainHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.TreeSecondChainHandlers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CheckingTreeGotoRequest
{
    public static IEnumerable<object[]> TestParameters()
    {
        yield return new object[]
        {
            "tree goto D://239_DATABASE",
            new GotoTree("D://239_DATABASE"),
        };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void ShouldParseCorrectly(string request, GotoTree gotoTree)
    {
        ICommandHandler fileCommandHandler = new FileCommandHandler(
            new CopyFileCommandHandler().SetNextHandler(
                new DeleteFileCommandHandler().SetNextHandler(
                    new MoveFileCommandHandler().SetNextHandler(
                        new RenameFileCommandHandler().SetNextHandler(
                            new ShowFileCommandHandler())))));

        ICommandHandler treeCommandHandler = new TreeCommandHandler(
            new GotoTreeCommandHandler().SetNextHandler(
                new ListTreeCommandHandler()));

        ICommandHandler chain = new ConnectionCommandHandler().SetNextHandler(fileCommandHandler.SetNextHandler(treeCommandHandler));

        var commandParser = new CommandParser(chain);

        ICommands? parsedCommand = commandParser.Parsing(request, new LocalMode());

        var temp = (GotoTree?)parsedCommand;

        ParameterExpression keeperArg = Expression.Parameter(typeof(GotoTree), "temp");
        Expression secretAccessor = Expression.Field(keeperArg, "_absolutePath");
        var lambda = Expression.Lambda<Func<GotoTree, string>>(secretAccessor, keeperArg);
        Func<GotoTree, string> func = lambda.Compile();
        if (temp != null)
        {
            string result1 = func(temp);
            string result2 = func(gotoTree);
            Assert.Equal(result1, result2);
        }
    }
}