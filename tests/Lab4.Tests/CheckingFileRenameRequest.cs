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

public class CheckingFileRenameRequest
{
    public static IEnumerable<object[]> TestParameters()
    {
        yield return new object[]
        {
            "file rename 241.txt 239",
            new RenameFile("file rename 241.txt 239".Split(' '), new LocalMode()),
        };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void ShouldParseCorrectly(string request, RenameFile renameFile)
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

        var temp = (RenameFile?)parsedCommand;

        ParameterExpression keeperArg = Expression.Parameter(typeof(RenameFile), "temp");
        Expression secretAccessor = Expression.Field(keeperArg, "_tokens");
        var lambda = Expression.Lambda<Func<RenameFile, string[]>>(secretAccessor, keeperArg);
        Func<RenameFile, string[]> func = lambda.Compile();
        if (temp != null)
        {
            string[] result1 = func(temp);
            string[] result2 = func(renameFile);
            Assert.Equal(result1, result2);
        }
    }
}