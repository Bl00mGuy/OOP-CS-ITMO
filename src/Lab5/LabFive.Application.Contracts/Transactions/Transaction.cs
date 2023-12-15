namespace LabFive.Application.Contracts.Transactions;

public record Transaction(long TransactionId, long UserId, string TransactionText);