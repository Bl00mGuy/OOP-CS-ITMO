namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

public interface IMessageBuilder
{
    IMessageBuilder WithTitle(string title);
    IMessageBuilder WithParagraph(string paragraph);
    IMessageBuilder WithImportanceLevel(MessageImportanceLevel importanceLevel);
}