using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Log;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Messenger;

public class Messenger : IRecipient
{
    private readonly IMessageLogger _logger = new MessageLogger();
    public void ReceiveMessage(IMessage message, MessageImportanceLevel filterImportanceLevel)
    {
        if (message is null) return;
        _logger.LogMessage(message);
    }
}