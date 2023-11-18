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

public class CheckingFileMoveRequest
{
    public static IEnumerable<object[]> TestParameters()
    {
        yield return new object[]
        {
            "file move ISy26_BANNED_ACCOUNTS/cyberronin/241.txt itmo_big_cock/241.txt",
            new MoveFile("file move ISy26_BANNED_ACCOUNTS/cyberronin/241.txt itmo_big_cock/241.txt".Split(' '), new LocalMode()),
        };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void ShouldParseCorrectly(string request, MoveFile moveFile)
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

        var temp = (MoveFile?)parsedCommand;

        ParameterExpression keeperArg = Expression.Parameter(typeof(MoveFile), "temp");
        Expression secretAccessor = Expression.Field(keeperArg, "_tokens");
        var lambda = Expression.Lambda<Func<MoveFile, string[]>>(secretAccessor, keeperArg);
        Func<MoveFile, string[]> func = lambda.Compile();
        if (temp != null)
        {
            string[] result1 = func(temp);
            string[] result2 = func(moveFile);
            Assert.Equal(result1, result2);
        }
    }
}