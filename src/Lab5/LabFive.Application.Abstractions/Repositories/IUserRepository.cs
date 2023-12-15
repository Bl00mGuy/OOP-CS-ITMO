using LabFive.Application.Contracts.Users;
using LabFive.Application.Models.Users;

namespace LabFive.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUser(string name, string password);
    void CreateBill(string name, string password);
    decimal? GetUserBalance(long user);
    void PutMoney(long user, long money);
    OperationStatus RemoveMoney(long user, long money);
}