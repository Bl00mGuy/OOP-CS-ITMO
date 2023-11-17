using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.FileSecondChainHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Handlers.TreeSecondChainHandlers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CheckingTheParserForCorrectOperation
{
    public static IEnumerable<object[]> TestParameters()
    {
        const string firstRequest = "connect D://241_DATABASE/ISy26_BANNED_ACCOUNTS/cyberronin -m local";
        const string secondRequest = "file delete D://241_DATABASE/ISy26_BANNED_ACCOUNTS/cyberronin/241.txt";
        const string thirdRequest = "file rename 241.txt 239";
        const string fourthRequest = "file copy D://241_DATABASE/ISy26_BANNED_ACCOUNTS/cyberronin/241.txt D://241_DATABASE/ISy26_BANNED_ACCOUNTS/itmo_big_cock";
        const string fifthRequest = "file move ISy26_BANNED_ACCOUNTS/cyberronin/241.txt itmo_big_cock/241.txt";
        const string sixthRequest = "file show D://241_DATABASE/members.txt -m console";
        const string seventhRequest = "tree goto D://239_DATABASE";
        const string eighthRequest = "tree list -d 4";
        yield return new object[] { firstRequest, secondRequest, thirdRequest, fourthRequest, fifthRequest, sixthRequest, seventhRequest, eighthRequest };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void Test(string firstRequest, string secondRequest, string thirdRequest, string fourthRequest, string fifthRequest, string sixthRequest, string seventhRequest, string eighthRequest)
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

        var chainParsing = new CommandParser(chain);

        Assert.True(chainParsing.Parsing(firstRequest) is Connect);

        Assert.True(chainParsing.Parsing(secondRequest) is DeleteFile);

        Assert.True(chainParsing.Parsing(thirdRequest) is RenameFile);

        Assert.True(chainParsing.Parsing(fourthRequest) is CopyFile);

        Assert.True(chainParsing.Parsing(fifthRequest) is MoveFile);

        Assert.True(chainParsing.Parsing(sixthRequest) is ShowFile);

        Assert.True(chainParsing.Parsing(seventhRequest) is GotoTree);

        Assert.True(chainParsing.Parsing(eighthRequest) is ListTree);
    }
}