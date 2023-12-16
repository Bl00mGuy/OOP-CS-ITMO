using LabFive.Application.Contracts.Transactions;

namespace LabFive.Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(string name, string password);
    void CreateBill(string name, string password);
    decimal? GetBalance();
    void PutMoney(decimal money);
    OperationStatus RemoveMoney(decimal money);
    void LogTransaction(string type, decimal amount);
}