using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Moqs;

public class UserAddresseMoq
{
    private readonly LoggerMoq _logger;
    private readonly IRecipient _user;

    public UserAddresseMoq(int id, string name)
    {
        _logger = new LoggerMoq();
        _user = new User(id, name);
    }

    public void SendMessage(IMessage message, MessageImportanceLevel filterImportanceLevel, User user)
    {
        ((User)_user).SendMessage(message, filterImportanceLevel, user);
    }

    public bool ReceiveMessage(IMessage message, MessageImportanceLevel filterImportanceLevel)
    {
        if (message is null) return false;
        if (message.ImportanceLevel == filterImportanceLevel)
        {
            ((User)_user).ReceiveMessage(message, filterImportanceLevel);
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