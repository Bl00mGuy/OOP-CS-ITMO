using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.MessagesLogger;

public interface IMessageLogger
{
    void LogMessage(IRecipient recipient, IMessage message);
}