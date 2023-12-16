using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Moqs;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class ChecksRecordsLogWhenReceivedMessage
{
    public static IEnumerable<object[]> TestParameters()
    {
        string firstMessageTitle = "NO WAY";
        string firstMessageParagraph = "02:39";
        MessageImportanceLevel firstMessageImportanceLevel = MessageImportanceLevel.Low;
        int firstUserId = 334770;
        string firstUserName = "Emin";
        yield return new object[] { firstUserId, firstUserName, firstMessageTitle, firstMessageParagraph, firstMessageImportanceLevel };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void Test(int firstUserId, string firstUserName, string firstMessageTitle, string firstMessageParagraph, MessageImportanceLevel firstMessageImportanceLevel)
    {
        var logger = new LoggerMoq();
        var firstUser = new LoggerAddresseMoq(new FilterAddresse(new UserAddresse(firstUserId, firstUserName), firstMessageImportanceLevel), logger);
        IMessageBuilder firstMessageBuilder = new MessageBuilder().WithTitle(firstMessageTitle).WithParagraph(firstMessageParagraph).WithImportanceLevel(firstMessageImportanceLevel);
        Message firstMessage = firstMessageBuilder.Build();

        firstUser.ReceiveMessage(firstMessage);
        bool act = firstUser.IsLoggerLogs();

        const bool expected = true;
        Assert.Equal(expected, act);
    }
}