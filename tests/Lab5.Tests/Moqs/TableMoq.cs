namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public class TableMoq
{
    public TableMoq(long userId, string userName, string userPassword, decimal userBalance)
    {
        UserId = userId;
        UserName = userName;
        UserPassword = userPassword;
        UserBalance = userBalance;
    }

    public long UserId { get; }
    public string UserName { get; }
    public string UserPassword { get; }
    public decimal UserBalance { get; set; }
}