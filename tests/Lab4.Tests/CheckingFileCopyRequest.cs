using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.DisplayMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.FileSecondChainHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.TreeSecondChainHandlers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CheckingFileCopyRequest
{
    public static IEnumerable<object[]> TestParameters()
    {
        yield return new object[]
        {
            "file copy D://241_DATABASE/ISy26_BANNED_ACCOUNTS/cyberronin/241.txt D://241_DATABASE/ISy26_BANNED_ACCOUNTS/itmo_big_cocfk",
            new CopyFile("file copy D://241_DATABASE/ISy26_BANNED_ACCOUNTS/cyberronin/241.txt D://241_DATABASE/ISy26_BANNED_ACCOUNTS/itmo_big_cock".Split(' '), new LocalModeCommandsExecution(), new LocalDisplay()),
        };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void ShouldParseCorrectly(string request, CopyFile copyFile)
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

        var temp = (CopyFile?)parsedCommand;

        ParameterExpression keeperArg = Expression.Parameter(typeof(CopyFile), "temp");
        Expression secretAccessor = Expression.Field(keeperArg, "_tokens");
        var lambda = Expression.Lambda<Func<CopyFile, string[]>>(secretAccessor, keeperArg);
        Func<CopyFile, string[]> func = lambda.Compile();
        if (temp != null)
        {
            string[] result1 = func(temp);
            string[] result2 = func(copyFile);
            Assert.Equal(result1, result2);
        }
    }
}