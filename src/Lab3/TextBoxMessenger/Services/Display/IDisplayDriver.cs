using System;
using Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Display;

public interface IDisplayDriver
{
    void ClearDisplay();
    void SetTextColor(ConsoleColor color);
    void DisplayText(IMessage data);
}