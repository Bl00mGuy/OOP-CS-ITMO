using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Moqs;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class WhenSendingMessageInMessengerHisRealizationMustPerformExpectedValue
{
    public static IEnumerable<object[]> TestParameters()
    {
        string firstMessageTitle = "NO WAY";
        string firstMessageParagraph = "02:39";
        MessageImportanceLevel firstMessageImportanceLevel = MessageImportanceLevel.Regular;
        yield return new object[] { firstMessageTitle, firstMessageParagraph, firstMessageImportanceLevel };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void Test(string firstMessageTitle, string firstMessageParagraph, MessageImportanceLevel firstMessageImportanceLevel)
    {
        var firstMessenger = new MessengerMoq();
        IMessageBuilder firstMessageBuilder = new MessageBuilder().WithTitle(firstMessageTitle).WithParagraph(firstMessageParagraph).WithImportanceLevel(firstMessageImportanceLevel);
        Message firstMessage = firstMessageBuilder.Build();

        firstMessenger.ReceiveMessage(firstMessage, firstMessage.ImportanceLevel);
        string act = firstMessenger.MessengerOutput;

        const string expected = "";
        Assert.NotEqual(expected, act);
    }
}