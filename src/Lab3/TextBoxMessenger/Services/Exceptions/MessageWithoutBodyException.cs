using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Exceptions;

public class MessageWithoutBodyException : Exception
{
    public MessageWithoutBodyException()
        : base("Message should contain a paragraph!")
    {
    }

    public MessageWithoutBodyException(string message)
        : base(message)
    {
    }

    public MessageWithoutBodyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}