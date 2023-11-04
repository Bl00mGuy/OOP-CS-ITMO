using System;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Display;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.MessagesLogger;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class DisplayAddresse : IRecipient
{
    private readonly MessageLogger _logger;
    private readonly Display _display;

    public DisplayAddresse(MessageLogger logger)
    {
        _logger = logger;
        _display = new Display();
    }

    public void ReceiveMessage(IMessage message)
    {
        _display.ReceiveMessage(message);
        _logger.LogMessage(_display, message);
    }

    public void DisplayMessage(ConsoleColor color)
    {
        _display.DisplayMessage(color);
    }
}