using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

public class MessageBuilder : IMessageBuilder
{
    private string? _title;
    private string? _paragraph;
    private MessageImportanceLevel _importanceLevel;

    public IMessageBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public IMessageBuilder WithParagraph(string paragraph)
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