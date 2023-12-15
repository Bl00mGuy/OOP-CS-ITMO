using LabFive.Application.Contracts.Users;
using LabFive.Application.Models.Users;

namespace LabFive.Application.Users;

internal class CurrentAdminManager : ICurrentAdminService
{
    public Admin? Admin { get; set; }
}