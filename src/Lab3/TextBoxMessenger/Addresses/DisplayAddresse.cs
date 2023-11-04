using System;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Display;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Addresses;

public class DisplayAddresse : IRecipient
{
    private readonly Display _display;

    public DisplayAddresse()
    {
        _display = new Display();
    }

    public void ReceiveMessage(IMessage message)
    {
        _display.ReceiveMessage(message);
    }

    public void DisplayMessage(ConsoleColor color)
    {
        _display.DisplayMessage(color);
    }
}