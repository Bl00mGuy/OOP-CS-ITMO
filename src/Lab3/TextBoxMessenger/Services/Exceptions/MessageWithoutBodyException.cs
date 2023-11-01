using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextBoxMessenger.Services.Exceptions;

public class MessageWithoutBodyException : Exception
{
    public MessageWithoutBodyException()
        : base("Можешь пом»енять")
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