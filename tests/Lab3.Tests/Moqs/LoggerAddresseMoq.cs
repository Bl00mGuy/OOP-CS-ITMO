using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Moqs;

public class LoggerAddresseMoq : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly LoggerMoq _logger;

    public LoggerAddresseMoq(IRecipient recipient, LoggerMoq logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void ReceiveMessage(IMessage message)
    {
        _recipient.ReceiveMessage(message);
        _logger.LogMessage(_recipient, message);
    }

    public bool IsLoggerLogs()
    {
        if (_logger.LogVerify()) return true;
        return false;
    }
}