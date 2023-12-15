using LabFive.Application.Contracts.Transactions;

namespace LabFive.Application.Contracts.Users;

public interface IAdminService
{
    LoginResult Login(string password);
    IEnumerable<Transaction> GetTransactionsHistory();
}