using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Client;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Paragraph;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Title;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

public class Message : IMessage
{
    public Message(ITitle title, IParagraph paragraph, MessageImportanceLevel importantLevel)
    {
        Title = title;
        Paragraph = paragraph;
        ImportantLevel = importantLevel;
    }

    public ITitle Title { get; }
    public IParagraph Paragraph { get; }
    public MessageImportanceLevel ImportantLevel { get; private set; }

    public MessageResultType ChangeImportanceLevel(MessageImportanceLevel importanceLevel)
    {
        if (ImportantLevel is not MessageImportanceLevel.Read)
        {
            ImportantLevel = importanceLevel;
            return MessageResultType.Success;
        }
        else
        {
            return MessageResultType.MessageAlreadyRead;
        }
    }
}