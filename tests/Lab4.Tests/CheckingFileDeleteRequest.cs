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

public class CheckingFileDeleteRequest
{
    public static IEnumerable<object[]> TestParameters()
    {
        yield return new object[]
        {
            "connect D://241_DATABASE/ISy26_BANNED_ACCOUNTS/cyberronin -m local",
            "file delete D://241_DATABASE/ISy26_BANNED_ACCOUNTS/cyberronin/241.txt",
            new DeleteFile("file delete D://241_DATABASE/ISy26_BANNED_ACCOUNTS/cyberronin/241.txt".Split(' '), new LocalMode()),
        };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void ShouldParseCorrectly(string connectRequest, string deleteRequest, DeleteFile deleteFile)
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

        ICommandHandler chain = new TypeOfConnectionHandler(new ConnectionCommandHandler().SetNextHandler(fileCommandHandler.SetNextHandler(treeCommandHandler)));

        var commandParser = new CommandParser(chain);

        commandParser.Parsing(connectRequest);
        ICommands? parsedCommand = commandParser.Parsing(deleteRequest);

        var temp = (DeleteFile?)parsedCommand;

        ParameterExpression keeperArg = Expression.Parameter(typeof(DeleteFile), "temp");
        Expression secretAccessor = Expression.Field(keeperArg, "_filePath");
        var lambda = Expression.Lambda<Func<DeleteFile, string>>(secretAccessor, keeperArg);
        Func<DeleteFile, string> func = lambda.Compile();
        if (temp != null)
        {
            string result1 = func(temp);
            string result2 = func(deleteFile);
            Assert.Equal(result1, result2);
        }
    }
}