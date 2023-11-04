using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.MessagesLogger;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class GroupAddresse : IRecipient
{
    private readonly MessageLogger _logger;
    private readonly Group _group;

    public GroupAddresse(MessageLogger logger)
    {
        _logger = logger;
        _group = new Group();
    }

    public void ReceiveMessage(IMessage message)
    {
        _group.ReceiveMessage(message);
        _logger.LogMessage(_group, message);
    }

    public void AddRecipient(IRecipient recipient)
    {
        _group.AddRecipient(recipient);
    }
}