using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Moqs;

public class UserAddresseMoq
{
    private readonly LoggerMoq _logger;
    private readonly IRecipient _user;
    private MessageImportanceLevel _filter;

    public UserAddresseMoq(int id, string name, LoggerMoq loggerMoq)
    {
        _logger = loggerMoq;
        _user = new User(id, name);
    }

    public void SetFilterLevel(MessageImportanceLevel level)
    {
        _filter = level;
    }

    public void SendMessage(IMessage message, User user)
    {
        ((User)_user).SendMessage(message, user);
    }

    public bool ReceiveMessage(IMessage message)
    {
        if (message is null) return false;
        if (message.ImportanceLevel == _filter)
        {
            ((User)_user).ReceiveMessage(message);
            _logger.LogMessage(_user, message);
            return true;
        }

        return false;
    }

    public MessageResultType ReadMessage(Message message)
    {
        return ((User)_user).ReadMessage(message);
    }

    public bool IsLoggerLogs()
    {
        if (_logger.LogVerify() is true) return true;
        return false;
    }
}