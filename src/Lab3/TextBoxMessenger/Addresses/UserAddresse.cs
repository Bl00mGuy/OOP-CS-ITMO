using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.MessagesLogger;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class UserAddresse : IRecipient
{
    private readonly MessageLogger _logger;
    private readonly User _user;
    private MessageImportanceLevel _filter;

    public UserAddresse(int id, string name, MessageLogger logger)
    {
        _logger = logger;
        _user = new User(id, name);
    }

    public void SetFilterLevel(MessageImportanceLevel level)
    {
        _filter = level;
    }

    public void SendMessage(IMessage message, User user)
    {
        _user.SendMessage(message, user);
    }

    public void ReceiveMessage(IMessage message)
    {
        if (message is null) return;
        if (message.ImportanceLevel == _filter)
        {
            _user.ReceiveMessage(message);
            _logger.LogMessage(_user, message);
        }
    }

    public MessageResultType ReadMessage(Message message)
    {
        return _user.ReadMessage(message);
    }
}