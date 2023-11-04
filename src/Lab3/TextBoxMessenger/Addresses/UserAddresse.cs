using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class UserAddresse : IRecipient
{
    private readonly User _user;

    public UserAddresse(int id, string name)
    {
        _user = new User(id, name);
    }

    public void SendMessage(IMessage message, User user)
    {
        _user.SendMessage(message, user);
    }

    public void ReceiveMessage(IMessage message)
    {
        _user.ReceiveMessage(message);
    }

    public MessageResultType ReadMessage(Message message)
    {
        return _user.ReadMessage(message);
    }
}