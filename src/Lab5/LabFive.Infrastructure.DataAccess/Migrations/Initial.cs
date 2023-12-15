using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace LabFive.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create table users
    (
        user_id bigint primary key generated always as identity,
        user_name text not null,
        user_password text not null,
        user_balance numeric not null
    );
    
    create table transactions
    (
        transaction_id bigint primary key generated always as identity,
        user_id bigint not null,
        transaction_text text not null
    );

    create table admins
    (
        admin_name text not null,
        admin_password text not null
    );
    insert into admins (admin_name, admin_password) values ('Emin', '239');
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table transactions;
    drop table admins;
    """;
}