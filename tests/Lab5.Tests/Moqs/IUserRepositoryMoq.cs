using LabFive.Application.Contracts.Transactions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public interface IUserRepositoryMoq
{
    decimal GetUserBalance(TableMoq table);
    void PutMoney(TableMoq table, decimal money);
    OperationStatus RemoveMoney(TableMoq table, decimal money);
}