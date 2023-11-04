using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.MessagesLogger;

public class MessageLogger : IMessageLogger
{
    private readonly IList<IRecipient> _recipients;
    private readonly IList<IMessage> _messages;

    public MessageLogger()
    {
        _recipients = new List<IRecipient>();
        _messages = new List<IMessage>();
    }

    public void LogMessage(IRecipient recipient, IMessage message)
    {
        _recipients.Add(recipient);
        _messages.Add(message);
    }
}