using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class PutMoneyTest
{
    public static IEnumerable<object[]> TestParameters()
    {
        const long user_id = 1;
        const string user_name = "Person";
        const string user_password = "qwerty";
        const decimal user_balance = 239239239;
        const decimal putMoney = 32452352332;
        yield return new object[] { user_id, user_name, user_password, user_balance, putMoney };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void Test(long userId, string userName, string userPassword, decimal userBalance, decimal putMoney)
    {
        var table = new TableMoq(userId, userName, userPassword, userBalance);

        var repository = new UserRepositoryMoq();

        repository.PutMoney(table, putMoney);

        Assert.NotEqual(table.UserBalance, userBalance);
    }
}