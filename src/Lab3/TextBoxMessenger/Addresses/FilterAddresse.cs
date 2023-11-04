using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class FilterAddresse : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly MessageImportanceLevel _level;

    public FilterAddresse(IRecipient recipient, MessageImportanceLevel level)
    {
        _recipient = recipient;
        _level = level;
    }

    public void ReceiveMessage(IMessage message)
    {
        if (message is null) return;
        if (message.ImportanceLevel == _level)
        {
            _recipient.ReceiveMessage(message);
        }
    }
}