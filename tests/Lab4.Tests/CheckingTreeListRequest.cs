using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.FileSecondChainHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.TreeSecondChainHandlers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CheckingTreeListRequest
{
    public static IEnumerable<object[]> TestParameters()
    {
        yield return new object[]
        {
            "tree list -d 4",
            new ListTree("tree list -d 4".Split(' '), "local"),
        };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void ShouldParseCorrectly(string request, ListTree listTree)
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

        ICommands? parsedCommand = commandParser.Parsing(request, "local");

        var temp = (ListTree?)parsedCommand;

        ParameterExpression keeperArg = Expression.Parameter(typeof(ListTree), "temp");
        Expression secretAccessor = Expression.Field(keeperArg, "_tokens");
        var lambda = Expression.Lambda<Func<ListTree, string[]>>(secretAccessor, keeperArg);
        Func<ListTree, string[]> func = lambda.Compile();
        if (temp != null)
        {
            string[] result1 = func(temp);
            string[] result2 = func(listTree);
            Assert.Equal(result1, result2);
        }
    }
}