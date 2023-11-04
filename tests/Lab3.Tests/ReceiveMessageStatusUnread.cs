using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.MessagesLogger;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class ReceiveMessageStatusUnread
{
    public static IEnumerable<object[]> TestParameters()
    {
        string messageTitle = "NO WAY";
        string messageParagraph = "02:39";
        MessageImportanceLevel messageImportanceLevel = MessageImportanceLevel.High;
        int firstUserId = 367967;
        string firstUserName = "Dmitry Vasilkov";
        yield return new object[] { firstUserId, firstUserName, messageTitle, messageParagraph, messageImportanceLevel };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void Test(int firstUserId, string firstUserName, string firstMessageTitle, string firstMessageParagraph, MessageImportanceLevel firstMessageImportanceLevel)
    {
        var logger = new MessageLogger();
        var user = new UserAddresse(firstUserId, firstUserName, logger);
        IMessageBuilder firstMessageBuilder = new MessageBuilder().WithTitle(firstMessageTitle).WithParagraph(firstMessageParagraph).WithImportanceLevel(firstMessageImportanceLevel);
        Message firstMessage = firstMessageBuilder.Build();
        user.SetFilterLevel(firstMessage.ImportanceLevel);

        user.ReceiveMessage(firstMessage);
        MessageResultType act = user.ReadMessage(firstMessage);

        const MessageResultType expected = MessageResultType.Success;
        Assert.Equal(expected, act);
    }
}