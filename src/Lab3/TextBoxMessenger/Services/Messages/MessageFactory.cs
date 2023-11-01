using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Paragraph;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Title;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

public class MessageFactory : IMessageFactory
{
    public IMessage CreateMessage(ITitle title, IParagraph paragraph, MessageImportanceLevel importantLevel)
    {
        return new Messages.Message(title, paragraph, importantLevel);
    }
}