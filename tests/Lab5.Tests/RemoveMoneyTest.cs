using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;
using LabFive.Application.Contracts.Transactions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class RemoveMoneyTest
{
    public static IEnumerable<object[]> TestParameters()
    {
        const long user_id = 1;
        const string user_name = "Person";
        const string user_password = "qwerty";
        const decimal user_balance = 2335239;
        const decimal removeMoney = 314;
        yield return new object[] { user_id, user_name, user_password, user_balance, removeMoney };
    }

    [Theory]
    [MemberData(nameof(TestParameters))]
    public void Test(long userId, string userName, string userPassword, decimal userBalance, decimal removeMoney)
    {
        var table = new TableMoq(userId, userName, userPassword, userBalance);

        var repository = new UserRepositoryMoq();

        OperationStatus result = repository.RemoveMoney(table, removeMoney);

        Assert.Equal(OperationStatus.Success, result);
    }
}