using LabFive.Application.Abstractions.Repositories;
using LabFive.Application.Contracts.Transactions;
using LabFive.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

internal class UserServiceMoq : IUserServiceMoq
{
    private readonly IUserRepository _repository;

    public UserServiceMoq(IUserRepository repository)
    {
        _repository = repository;
    }

    public LoginResult Login(string name, string password)
    {
        LabFive.Application.Models.Users.User? user = _repository.FindUser(name, password);

        if (user is null) return LoginResult.NotFound;

        return LoginResult.Success;
    }

    public decimal? GetBalance(long userid)
    {
        return _repository.GetUserBalance(userid);
    }

    public void PutMoney(long userid, decimal money)
    {
        _repository.PutMoney(userid, money);
    }

    public OperationStatus RemoveMoney(long userid, decimal money)
    {
        _repository.RemoveMoney(userid, money);
        return OperationStatus.None;
    }

    public void LogTransaction(long userid, string type, decimal amount)
    {
        _repository.LogTransaction(userid, type, amount);
    }
}