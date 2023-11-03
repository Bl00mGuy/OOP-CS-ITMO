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
        MessageImportanceLevel messageImportanceLevel = MessageImportanceLevel.Low;
        int firstUserId = 334788;
        string firstUserName = "Michael Ganin";
        yield return new object[] { firstUserId, firstUserName, messageTitle, messageParagraph, messageImportanceLevel };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void Test(int firstUserId, string firstUserName, string messageTitle, string messageParagraph, MessageImportanceLevel messageImportanceLevel)
    {
        var user = new UserAddresse(firstUserId, firstUserName);
        var message = new Message(messageTitle, messageParagraph, messageImportanceLevel);

        user.ReceiveMessage(message, message.ImportanceLevel);
        user.ReadMessage(message); // the first time it was marked "Read"
        MessageResultType asset = user.ReadMessage(message); // the second time tried to mark it as "Read"

        const MessageResultType expected = MessageResultType.MessageAlreadyRead;
        Assert.Equal(expected, asset);
    }
}