using System;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Display;

public class DisplayDriver : IDisplayDriver
{
    public void ClearDisplay()
    {
        Console.Clear();
    }

    public void SetTextColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void DisplayText(IMessage data)
    {
        if (data is null) return;

        if (data.Title is not null)
        {
            Console.WriteLine(data.Title);
        }

        Console.WriteLine(data.Paragraph);
    }
}