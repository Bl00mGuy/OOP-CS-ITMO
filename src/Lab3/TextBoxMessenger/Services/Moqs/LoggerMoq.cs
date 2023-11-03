using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Log;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Moqs;

public class LoggerMoq : IMessageLogger
{
    private readonly IList<IRecipient> _recipients = new List<IRecipient>();
    private readonly IList<IMessage> _messages = new List<IMessage>();

    public void LogMessage(IRecipient recipient, IMessage message)
    {
        _recipients.Add(recipient);
        _messages.Add(message);
    }

    public bool LogVerify()
    {
        if (_recipients.Count > 0 || _messages.Count > 0) return true;
        return false;
    }
}