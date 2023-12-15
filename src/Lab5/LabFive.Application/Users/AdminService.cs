using LabFive.Application.Abstractions.Repositories;
using LabFive.Application.Contracts.Transactions;
using LabFive.Application.Contracts.Users;

namespace LabFive.Application.Users;

internal class AdminService : IAdminService
{
    private readonly IAdminRepository _sudoRepository;
    private readonly CurrentAdminManager _currentAdminManager;

    public AdminService(IAdminRepository repository, CurrentAdminManager currentUserManager)
    {
        _sudoRepository = repository;
        _currentAdminManager = currentUserManager;
    }

    public LoginResult Login(string password)
    {
        Models.Users.Admin? admin = _sudoRepository.FindAdmin(password);

        if (admin is null) return LoginResult.NotFound;

        _currentAdminManager.Admin = admin;
        return LoginResult.Success;
    }

    public IEnumerable<Transaction> GetTransactionsHistory()
    {
        return _sudoRepository.GetTransactionsHistory();
    }
}