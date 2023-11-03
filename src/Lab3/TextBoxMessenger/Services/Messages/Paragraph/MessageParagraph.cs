namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Paragraph;

public class MessageParagraph : IParagraph
{
    public MessageParagraph(string paragraph)
    {
        Text = paragraph;
    }

    public string Text { get; }
}