using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Paragraph;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Title;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

public class Message : IMessage
{
    public Message(string? title, string paragraph, MessageImportanceLevel importantLevel)
    {
        if (title is not null)
        {
            Title = new MessageTitle(title);
        }

        Paragraph = new MessageParagraph(paragraph);
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