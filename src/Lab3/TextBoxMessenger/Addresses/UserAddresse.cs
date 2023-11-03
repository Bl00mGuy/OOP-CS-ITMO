using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Log;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class UserAddresse : IRecipient
{
    private readonly MessageLogger _logger;
    private readonly IRecipient _user;

    public UserAddresse(int id, string name)
    {
        _logger = new MessageLogger();
        _user = new User(id, name);
    }

    public void SendMessage(IMessage message, MessageImportanceLevel filterImportanceLevel, User user)
    {
        ((User)_user).SendMessage(message, filterImportanceLevel, user);
    }

    public void ReceiveMessage(IMessage message, MessageImportanceLevel filterImportanceLevel)
    {
        ((User)_user).ReceiveMessage(message, filterImportanceLevel);
        _logger.LogMessage(_user, message);
    }

    public MessageResultType ReadMessage(Message message)
    {
        return ((User)_user).ReadMessage(message);
    }
}