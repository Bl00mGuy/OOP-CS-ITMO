using LabFive.Application.Contracts.Transactions;
using LabFive.Application.Models.Users;

namespace LabFive.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    IEnumerable<Transaction> GetTransactionsHistory();
    Admin? FindAdmin(string password);
}