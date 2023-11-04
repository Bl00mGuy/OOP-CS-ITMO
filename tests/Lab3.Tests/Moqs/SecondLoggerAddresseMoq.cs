using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Moqs;

public class SecondLoggerAddresseMoq
{
    private readonly IRecipient _recipient;
    private readonly LoggerMoq _logger;

    public SecondLoggerAddresseMoq(IRecipient recipient, LoggerMoq logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public bool ReceiveMessage(IMessage message)
    {
        if (_recipient is not null)
        {
            _recipient.ReceiveMessage(message);
            _logger.LogMessage(_recipient, message);
            return true;
        }

        return false;
    }

    public bool IsLoggerLogs()
    {
        if (_logger.LogVerify()) return true;
        return false;
    }
}