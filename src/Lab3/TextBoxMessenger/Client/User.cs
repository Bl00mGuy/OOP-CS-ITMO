using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;

public class User : IUser, IRecipient
{
    private readonly IList<IMessage> _messages;

    public User(int id, string name)
    {
        Id = id;
        Name = name;
        _messages = new List<IMessage>();
    }

    public int Id { get; }
    public string Name { get; }

    public MessageResultType ReadMessage(Message message)
    {
        if (message is null) return MessageResultType.MessageNotFound;
        return _messages.Contains(message) ? message.ChangeImportanceLevel(MessageImportanceLevel.Read) : MessageResultType.MessageNotFound;
    }

    public void ReceiveMessage(IMessage message)
    {
        _messages.Add(message);
    }
}