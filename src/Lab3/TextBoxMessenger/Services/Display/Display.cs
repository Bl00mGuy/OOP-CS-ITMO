using System;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Log;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Display;

public class Display : IRecipient
{
    private readonly IMessageLogger _logger;
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver driver)
    {
        _logger = new MessageLogger();
        _displayDriver = driver;
    }

    public void ReceiveMessage(IMessage message, MessageImportanceLevel filterImportanceLevel)
    {
        if (message is null) return;
        if (message.ImportanceLevel == filterImportanceLevel)
        {
            _displayDriver.ClearDisplay();
            _displayDriver.SetTextColor(ConsoleColor.Magenta);
            _logger.LogMessage(message);
        }
    }
}