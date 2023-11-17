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

public class CheckingFileShowRequest
{
    public static IEnumerable<object[]> TestParameters()
    {
        yield return new object[]
        {
            "file show D://241_DATABASE/members.txt -m console",
            new ShowFile("file show D://241_DATABASE/members.txt -m console".Split(' ')),
        };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void ShouldParseCorrectly(string request, ShowFile showFile)
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

        ICommands? parsedCommand = commandParser.Parsing(request);

        var temp = (ShowFile?)parsedCommand;

        ParameterExpression keeperArg = Expression.Parameter(typeof(ShowFile), "temp");
        Expression secretAccessor = Expression.Field(keeperArg, "_tokens");
        var lambda = Expression.Lambda<Func<ShowFile, string[]>>(secretAccessor, keeperArg);
        Func<ShowFile, string[]> func = lambda.Compile();
        if (temp != null)
        {
            string[] result1 = func(temp);
            string[] result2 = func(showFile);
            Assert.Equal(result1, result2);
        }
    }
}