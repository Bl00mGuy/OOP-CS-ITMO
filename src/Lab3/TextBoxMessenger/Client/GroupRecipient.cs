using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;

public class GroupRecipient : IRecipient
{
    private readonly IList<IRecipient> _recipients = new List<IRecipient>();

    public void ReceiveMessage(IMessage message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.ReceiveMessage(message);
        }
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }
}