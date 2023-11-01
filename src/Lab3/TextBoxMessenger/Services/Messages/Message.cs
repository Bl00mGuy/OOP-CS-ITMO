using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Paragraph;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Title;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

public class Message : IMessage
{
    public Message(ITitle? title, IParagraph paragraph, MessageImportanceLevel importantLevel)
    {
        Title = title;
        Paragraph = paragraph;
        ImportanceLevel = importantLevel;
    }

    public ITitle? Title { get; }
    public IParagraph Paragraph { get; }
    public MessageImportanceLevel ImportanceLevel { get; private set; }

    public MessageResultType ChangeImportanceLevel(MessageImportanceLevel importanceLevel)
    {
        if (ImportanceLevel is not MessageImportanceLevel.Read)
        {
            ImportanceLevel = importanceLevel;
            return MessageResultType.Success;
        }
        else
        {
            return MessageResultType.MessageAlreadyRead;
        }
    }
}