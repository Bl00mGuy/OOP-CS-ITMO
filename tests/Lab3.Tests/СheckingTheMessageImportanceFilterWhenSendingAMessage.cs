using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Moqs;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class СheckingTheMessageImportanceFilterWhenSendingAMessage
{
    public static IEnumerable<object[]> TestParameters()
    {
        string firstMessageTitle = "NO WAY";
        string firstMessageParagraph = "02:41";
        MessageImportanceLevel firstMessageImportanceLevel = MessageImportanceLevel.Low;
        int firstUserId = 334770;
        string firstUserName = "cyberronin";

        MessageImportanceLevel filter = MessageImportanceLevel.High;

        yield return new object[] { filter, firstUserId, firstUserName, firstMessageTitle, firstMessageParagraph, firstMessageImportanceLevel };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void Test(MessageImportanceLevel filter, int firstUserId, string firstUserName, string firstMessageTitle, string firstMessageParagraph, MessageImportanceLevel firstMessageImportanceLevel)
    {
        var firstUser = new UserAddresseMoq(firstUserId, firstUserName);
        IMessageBuilder firstMessageBuilder = new MessageBuilder().WithTitle(firstMessageTitle).WithParagraph(firstMessageParagraph).WithImportanceLevel(firstMessageImportanceLevel);
        Message firstMessage = firstMessageBuilder.Build();

        bool act = firstUser.ReceiveMessage(firstMessage, filter);

        const bool expected = false;
        Assert.Equal(expected, act);
    }
}