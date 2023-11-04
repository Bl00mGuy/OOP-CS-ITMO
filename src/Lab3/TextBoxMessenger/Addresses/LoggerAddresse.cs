using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.MessagesLogger;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class LoggerAddresse : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly IMessageLogger _logger;

    public LoggerAddresse(IRecipient recipient, IMessageLogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void ReceiveMessage(IMessage message)
    {
        _recipient.ReceiveMessage(message);
        _logger.LogMessage(_recipient, message);
    }
}