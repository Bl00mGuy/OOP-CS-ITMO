using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Paragraph;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Title;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

public interface IMessage
{
    ITitle? Title { get; }
    IParagraph Paragraph { get; }
    MessageImportanceLevel ImportanceLevel { get; }
}
