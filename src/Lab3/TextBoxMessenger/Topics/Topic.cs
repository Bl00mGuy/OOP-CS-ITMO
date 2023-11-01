using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Topics;

public class Topic : ITopic
{
    private readonly IRecipient _recipient;

    public Topic(string name, IRecipient recipient)
    {
        Name = name;
        _recipient = recipient;
    }

    public string Name { get; }

    public void SendMessage(IMessage message)
    {
        _recipient.ReceiveMessage(message);
    }
}