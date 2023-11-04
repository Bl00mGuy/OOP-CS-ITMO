using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.MessagesLogger;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class MessengerAddresse : IRecipient
{
    private readonly MessageLogger _logger;
    private readonly Messenger _messenger;

    public MessengerAddresse(MessageLogger logger)
    {
        _logger = logger;
        _messenger = new Messenger();
    }

    public void ReceiveMessage(IMessage message)
    {
        _messenger.ReceiveMessage(message);
        _logger.LogMessage(_messenger, message);
    }
}