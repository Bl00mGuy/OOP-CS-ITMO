using Itmo.Dev.Platform.Postgres.Extensions;
using LabFive.Application.Abstractions.Repositories;
using LabFive.Application.Contracts.Transactions;
using LabFive.Application.Models.Users;
using Npgsql;

namespace LabFive.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    public IEnumerable<Transaction> GetTransactionsHistory()
    {
        const string sql = @"
                           SELECT transaction_id, user_id, transaction_text
                           FROM transactions";

        using var connection = new NpgsqlConnection(new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 6432,
            Username = "postgres",
            Password = "postgres",
            SslMode = SslMode.Prefer,
        }.ConnectionString);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Transaction(
                reader.GetInt64(0),
                reader.GetInt64(1),
                reader.GetString(2));
        }
    }

    public Admin? FindAdmin(string password)
    {
        const string sql = @"
                           SELECT admin_name, admin_password
                           FROM admins
                           WHERE admin_password = @admin_password;";

        using var connection = new NpgsqlConnection(new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 6432,
            Username = "postgres",
            Password = "postgres",
            SslMode = SslMode.Prefer,
        }.ConnectionString);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("admin_password", password);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false) return null;

        return new Admin(
            Name: reader.GetString(0),
            Password: reader.GetString(1));
    }
}