using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Topics;

public class Topic : ITopic
{
    public Topic(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void SendMessage(IMessage message, IRecipient recipient)
    {
        if (message is null || recipient is null) return;
        recipient.ReceiveMessage(message);
    }
}