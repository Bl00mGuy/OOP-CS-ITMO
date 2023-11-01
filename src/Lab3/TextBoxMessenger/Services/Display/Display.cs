using System;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Display;

public class Display : IRecipient
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver driver)
    {
        _displayDriver = driver;
    }

    public void ReceiveMessage(IMessage message)
    {
        _displayDriver.ClearDisplay();
        _displayDriver.SetTextColor(ConsoleColor.Magenta);
        _displayDriver.DisplayText(message);
    }
}