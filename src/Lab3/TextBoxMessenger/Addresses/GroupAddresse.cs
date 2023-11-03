using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Log;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class GroupAddresse : IRecipient
{
    private readonly MessageLogger _logger;
    private readonly IRecipient _group;

    public GroupAddresse()
    {
        _logger = new MessageLogger();
        _group = new GroupRecipient();
    }

    public void ReceiveMessage(IMessage message, MessageImportanceLevel filterImportanceLevel)
    {
        ((GroupRecipient)_group).ReceiveMessage(message, filterImportanceLevel);
        _logger.LogMessage(_group, message);
    }

    public void AddRecipient(IRecipient recipient)
    {
        ((GroupRecipient)_group).AddRecipient(recipient);
    }
}