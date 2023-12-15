using LabFive.Application.Abstractions.Repositories;
using LabFive.Application.Contracts.Users;

namespace LabFive.Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(string name, string password)
    {
        Models.Users.User? user = _repository.FindUser(name, password);

        if (user is null) return LoginResult.NotFound;

        _currentUserManager.User = user;
        return LoginResult.Success;
    }

    public void CreateBill(string name, string password)
    {
        _repository.CreateBill(name, password);
    }

    public decimal? GetBalance()
    {
        if (_currentUserManager.User != null) return _repository.GetUserBalance(_currentUserManager.User.Id);
        return null;
    }

    public void PutMoney(long money)
    {
        if (_currentUserManager.User != null) _repository.PutMoney(_currentUserManager.User.Id, money);
    }

    public OperationStatus RemoveMoney(long money)
    {
        if (_currentUserManager.User != null) return _repository.RemoveMoney(_currentUserManager.User.Id, money);
        return OperationStatus.None;
    }
}