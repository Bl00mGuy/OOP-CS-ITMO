using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Paragraph;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Title;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

public class MessageBuilder : IMessageBuilder
{
    private ITitle? _title;
    private IParagraph _paragraph;
    private MessageImportanceLevel _importanceLevel;

    public IMessageBuilder WithTitle(ITitle title)
    {
        _title = title;
        return this;
    }

    public IMessageBuilder WithParagraph(IParagraph paragraph)
    {
        _paragraph = paragraph;
        return this;
    }

    public IMessageBuilder WithImportanceLevel(MessageImportanceLevel importanceLevel)
    {
        _importanceLevel = importanceLevel;
        return this;
    }

    public Message Build()
    {
        if (_paragraph is null)
        {
            throw new MessageWithoutBodyException();
        }

        return new Message(
            _title,
            _paragraph,
            _importanceLevel);
    }
}