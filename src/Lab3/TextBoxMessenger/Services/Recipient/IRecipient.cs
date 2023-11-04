using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

public interface IRecipient
{
    void ReceiveMessage(IMessage message);
}