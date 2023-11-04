using System;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Messengers;

public class Messenger : IRecipient
{
    public void ReceiveMessage(IMessage message)
    {
        if (message is null) return;
        Console.WriteLine($"Messenger: {message.Title} : {message.Paragraph}");
    }
}