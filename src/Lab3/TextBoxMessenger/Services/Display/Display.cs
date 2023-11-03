using System;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Display;

public class Display : IRecipient
{
    private IMessage? _message;

    public void ReceiveMessage(IMessage message, MessageImportanceLevel filterImportanceLevel)
    {
        if (message is null) return;
        _message = DisplayDriver.CleanMessage();
        if (message.ImportanceLevel == filterImportanceLevel)
        {
            _message = message;
        }
    }

    public void DisplayMessage(ConsoleColor color)
    {
        if (_message is null) return;

        if (_message.Title is not null)
        {
            Console.WriteLine(_message.Title.TitleName, color);
        }

        Console.WriteLine(_message.Paragraph.Text, color);
    }
}