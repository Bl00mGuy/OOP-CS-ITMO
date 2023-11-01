using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;

public interface IUser
{
    int Id { get; }
    string Name { get; }
    void SendMessage(IMessage message, MessageImportanceLevel filterImportanceLevel, User user);
}