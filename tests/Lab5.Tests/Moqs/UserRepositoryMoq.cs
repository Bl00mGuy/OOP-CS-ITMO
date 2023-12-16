using LabFive.Application.Contracts.Transactions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public class UserRepositoryMoq : IUserRepositoryMoq
{
    public decimal GetUserBalance(TableMoq table)
    {
        return table.UserBalance;
    }

    public void PutMoney(TableMoq table, decimal money)
    {
        table.UserBalance += money;
    }

    public OperationStatus RemoveMoney(TableMoq table, decimal money)
    {
        if (table.UserBalance > money)
        {
            table.UserBalance -= money;
            return OperationStatus.Success;
        }

        return OperationStatus.Failed;
    }
}