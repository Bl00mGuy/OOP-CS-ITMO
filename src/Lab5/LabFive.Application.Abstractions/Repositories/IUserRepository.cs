using LabFive.Application.Contracts.Users;
using LabFive.Application.Models.Users;

namespace LabFive.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUser(string name, string password);
    void CreateBill(string name, string password);
    decimal? GetUserBalance(long user);
    void PutMoney(long user, decimal money);
    OperationStatus RemoveMoney(long user, decimal money);
    void LogTransaction(long user, string type, decimal amount);
}