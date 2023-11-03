using System;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Display;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.MessagesLogger;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class DisplayAddresse : IRecipient
{
    private readonly MessageLogger _logger;
    private readonly IRecipient _display;

    public DisplayAddresse()
    {
        _logger = new MessageLogger();
        _display = new Display();
    }

    public void ReceiveMessage(IMessage message, MessageImportanceLevel filterImportanceLevel)
    {
        ((Display)_display).ReceiveMessage(message, filterImportanceLevel);
        _logger.LogMessage(_display, message);
    }

    public void DisplayMessage(ConsoleColor color)
    {
        ((Display)_display).DisplayMessage(color);
    }
}