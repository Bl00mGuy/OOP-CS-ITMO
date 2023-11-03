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

    public void SendMessage(IMessage message, MessageImportanceLevel filterImportanceLevel, IRecipient recipient)
    {
        if (message is null || recipient is null) return;
        if (message.ImportanceLevel == filterImportanceLevel)
        {
            recipient.ReceiveMessage(message, filterImportanceLevel);
        }
    }
}