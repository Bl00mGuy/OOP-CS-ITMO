using LabFive.Application.Contracts.Transactions;
using LabFive.Application.Contracts.Users;
using Spectre.Console;

namespace LabFive.Presentation.Console.Scenarios.TransactionsHistory;

public class TransactionsHistoryScenario : IScenario
{
    private readonly IAdminService _adminService;

    public TransactionsHistoryScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Transactions History";

    public void Run()
    {
        IEnumerable<Transaction> history = _adminService.GetTransactionsHistory();

        foreach (Transaction transaction in history)
        {
            System.Console.WriteLine($"TRANSACTION INFO: ID[{transaction.TransactionId}] USER ID[{transaction.UserId}] INFO[{transaction.TransactionText}]");
        }

        AnsiConsole.WriteLine("#OPERATION COMPLETED#");
    }
}