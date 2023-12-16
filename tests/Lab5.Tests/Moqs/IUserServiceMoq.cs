using LabFive.Application.Contracts.Transactions;
using LabFive.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public interface IUserServiceMoq
{
    LoginResult Login(string name, string password);
    decimal? GetBalance(long userid);
    void PutMoney(long userid, decimal money);
    OperationStatus RemoveMoney(long userid, decimal money);
    void LogTransaction(long userid, string type, decimal amount);
}