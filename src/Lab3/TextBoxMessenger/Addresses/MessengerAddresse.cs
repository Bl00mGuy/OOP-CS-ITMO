using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.MessagesLogger;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class MessengerAddresse : IRecipient
{
    private readonly MessageLogger _logger;
    private readonly IRecipient _messenger;

    public MessengerAddresse()
    {
        _logger = new MessageLogger();
        _messenger = new Messenger();
    }

    public void ReceiveMessage(IMessage message, MessageImportanceLevel filterImportanceLevel)
    {
        ((Messenger)_messenger).ReceiveMessage(message, filterImportanceLevel);
        _logger.LogMessage(_messenger, message);
    }
}