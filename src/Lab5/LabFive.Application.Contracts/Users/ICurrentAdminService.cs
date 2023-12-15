using LabFive.Application.Models.Users;

namespace LabFive.Application.Contracts.Users;

public interface ICurrentAdminService
{
    Admin? Admin { get; }
}