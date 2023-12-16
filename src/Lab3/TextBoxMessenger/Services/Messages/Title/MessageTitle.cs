namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages.Title;

public class MessageTitle : ITitle
{
    public MessageTitle(string titleName)
    {
        TitleName = titleName;
    }

    public string TitleName { get; }
}