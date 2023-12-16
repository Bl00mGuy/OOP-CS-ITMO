using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;

public class User : IUser, IRecipient
{
    private readonly List<IMessage> _messages;

    public User(int id, string name)
    {
        Id = id;
        Name = name;
        _messages = new List<IMessage>();
    }

    public int Id { get; }
    public string Name { get; }

    public void SendMessage(IMessage message, User user)
    {
        if (user is null) return;
        user.ReceiveMessage(message);
    }

    public MessageResultType ReadMessage(Message message)
    {
        if (message is null) return MessageResultType.MessageNotFound;
        return _messages.Contains(message) ? message.ChangeImportanceLevel(MessageImportanceLevel.Read) : MessageResultType.MessageNotFound;
    }

    public void ReceiveMessage(IMessage message)
    {
        if (message is null) return;
        {
            _messages.Add(message);
        }
    }
}