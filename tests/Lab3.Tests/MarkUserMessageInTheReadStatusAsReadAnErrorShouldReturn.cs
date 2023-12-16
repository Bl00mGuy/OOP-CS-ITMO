using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MarkUserMessageInTheReadStatusAsReadAnErrorShouldReturn
{
    public static IEnumerable<object[]> TestParameters()
    {
        string messageTitle = "NO WAY";
        string messageParagraph = "02:39";
        MessageImportanceLevel messageImportanceLevel = MessageImportanceLevel.High;
        int firstUserId = 334788;
        string firstUserName = "Michael Ganin";
        yield return new object[] { firstUserId, firstUserName, messageTitle, messageParagraph, messageImportanceLevel };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void Test(int firstUserId, string firstUserName, string firstMessageTitle, string firstMessageParagraph, MessageImportanceLevel firstMessageImportanceLevel)
    {
        var firstUser = new UserAddresse(firstUserId, firstUserName);
        IMessageBuilder firstMessageBuilder = new MessageBuilder().WithTitle(firstMessageTitle).WithParagraph(firstMessageParagraph).WithImportanceLevel(firstMessageImportanceLevel);
        Message firstMessage = firstMessageBuilder.Build();

        firstUser.ReceiveMessage(firstMessage);
        firstUser.ReadMessage(firstMessage); // the first time it was marked "Read"
        MessageResultType act = firstUser.ReadMessage(firstMessage); // the second time tried to mark it as "Read"

        const MessageResultType expected = MessageResultType.MessageAlreadyRead;
        Assert.Equal(expected, act);
    }
}