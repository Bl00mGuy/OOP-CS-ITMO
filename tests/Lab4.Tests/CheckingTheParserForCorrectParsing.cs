using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.FileSecondChainHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.TreeSecondChainHandlers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CheckingTheParserForCorrectParsing
{
    public static IEnumerable<object[]> TestParameters()
    {
        yield return new object[]
        {
            "connect D://241_DATABASE/ISy26_BANNED_ACCOUNTS/cyberronin -m local",
            typeof(Connect),
        };

        yield return new object[]
        {
            "file delete D://241_DATABASE/ISy26_BANNED_ACCOUNTS/cyberronin/241.txt",
            typeof(DeleteFile),
        };

        yield return new object[]
        {
            "file rename 241.txt 239",
            typeof(RenameFile),
        };

        yield return new object[]
        {
            "file copy D://241_DATABASE/ISy26_BANNED_ACCOUNTS/cyberronin/241.txt D://241_DATABASE/ISy26_BANNED_ACCOUNTS/itmo_big_cock",
            typeof(CopyFile),
        };

        yield return new object[]
        {
            "file move ISy26_BANNED_ACCOUNTS/cyberronin/241.txt itmo_big_cock/241.txt",
            typeof(MoveFile),
        };

        yield return new object[]
        {
            "file show D://241_DATABASE/members.txt -m console",
            typeof(ShowFile),
        };

        yield return new object[]
        {
            "tree goto D://239_DATABASE",
            typeof(GotoTree),
        };

        yield return new object[]
        {
            "tree list -d 4",
            typeof(ListTree),
        };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void ShouldParseCorrectly(string request, Type expectedType)
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

        Assert.IsType(expectedType, parsedCommand);
    }
}
