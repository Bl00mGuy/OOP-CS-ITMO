using Itmo.Dev.Platform.Postgres.Extensions;
using LabFive.Application.Abstractions.Repositories;
using LabFive.Application.Contracts.Transactions;
using LabFive.Application.Models.Users;
using Npgsql;

namespace LabFive.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    public User? FindUser(string name, string password)
    {
        const string sql = @"
                           SELECT user_id, user_name, user_password
                           FROM users
                           WHERE user_name = @user_name AND user_password = @user_password;";

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
        command.AddParameter("user_name", name);
        command.AddParameter("user_password", password);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false) return null;

        return new User(
            Id: reader.GetInt64(0),
            Name: reader.GetString(1),
            Password: reader.GetString(2));
    }

    public void CreateBill(string name, string password)
    {
        const string sql = @"
                INSERT INTO users (user_name, user_password, user_balance)
                VALUES (@name, @password, @balance);";

        using var connection = new NpgsqlConnection(new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 6432,
            Username = "postgres",
            Password = "postgres",
            SslMode = SslMode.Prefer,
        }.ConnectionString);
        connection.Open();
        const long balance = 0;
        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("name", name);
        command.AddParameter("password", password);
        command.AddParameter("balance", balance);
        command.ExecuteNonQuery();
    }

    public decimal? GetUserBalance(long user)
    {
        const string sql = @"
                SELECT user_balance
                FROM users
                WHERE user_id = @user;";

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
        command.AddParameter("user", user);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false) return null;

        return reader.GetDecimal(0);
    }

    public void PutMoney(long user, decimal money)
    {
        const string sql = @"
                UPDATE users
                SET user_balance = user_balance + @money
                WHERE user_id = @user;";

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
        command.AddParameter("user", user);
        command.AddParameter("money", money);
        command.ExecuteNonQuery();
    }

    public OperationStatus RemoveMoney(long user, decimal money)
    {
        const string sql = @"
                UPDATE users
                SET user_balance = user_balance - @money
                WHERE user_id = @user AND user_balance >= @money;";

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
        command.AddParameter("user", user);
        command.AddParameter("money", money);
        command.ExecuteNonQuery();

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false) return OperationStatus.Failed;
        return OperationStatus.Success;
    }

    public void LogTransaction(long user, string type, decimal amount)
    {
        const string sql = @"
                INSERT INTO transactions (user_id, transaction_type, transaction_amount)
                VALUES (@user, @type, @amount);";

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
        command.AddParameter("user", user);
        command.AddParameter("type", type);
        command.AddParameter("amount", amount);
        command.ExecuteNonQuery();
    }
}