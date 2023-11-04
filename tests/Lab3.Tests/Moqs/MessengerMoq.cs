using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Moqs;

public class MessengerMoq : IRecipient
{
    public string MessengerOutput { get; private set; } = string.Empty;
    public void ReceiveMessage(IMessage message)
    {
        if (message is null) return;
        MessengerOutput = $"Messenger: {message.Title} : {message.Paragraph}";
    }
}