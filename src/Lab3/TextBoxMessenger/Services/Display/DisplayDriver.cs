using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Display;

public class DisplayDriver : IDisplayDriver
{
    private readonly Display _display;
    private ConsoleColor _color = ConsoleColor.White;

    public DisplayDriver(Display display)
    {
        _display = display;
    }

    public void ClearDisplay()
    {
        Console.Clear();
    }

    public void SetTextColor(ConsoleColor color)
    {
        _color = color;
    }

    public void DisplayText()
    {
        _display.DisplayMessage(_color);
    }
}