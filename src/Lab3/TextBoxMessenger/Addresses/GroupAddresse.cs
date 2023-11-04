using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class GroupAddresse : IRecipient
{
    private readonly Group _group;

    public GroupAddresse()
    {
        _group = new Group();
    }

    public void ReceiveMessage(IMessage message)
    {
        _group.ReceiveMessage(message);
    }

    public void AddRecipient(IRecipient recipient)
    {
        _group.AddRecipient(recipient);
    }
}