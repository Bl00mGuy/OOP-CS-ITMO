using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Paragraph;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Title;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

public interface IMessageBuilder
{
    IMessageBuilder WithTitle(ITitle title);
    IMessageBuilder WithParagraph(IParagraph paragraph);
    IMessageBuilder WithImportanceLevel(MessageImportanceLevel importanceLevel);
}