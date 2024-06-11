using DataModel;
using LinqToDB;
using Microsoft.Extensions.Options;
using ProductTracker.Domain.AppSetting;

namespace ProductTracker.Infrastructure.Db;

internal sealed class DatabaseQueryWrapper(IOptions<ConnectionOption> options)
{
    private readonly DataOptions _builder = new DataOptions()
            .UsePostgreSQL(options.Value.NpgsqlConnectionString);

    public async Task<T> ExecuteAsync<T>(Func<AppDataConnection, Task<T>> callback)
    {
        await using var db = GetConnection();
        return await callback(db);
    }

    public T Execute<T>(Func<AppDataConnection, T> callback)
    {
        using var db = GetConnection();
        return callback(db);
    }

    public async Task<T> ExecuteWithTransaction<T>(Func<AppDataConnection, Task<T>> callback)
    {
        await using var db = GetConnection();

        _ = await db.BeginTransactionAsync();

        try
        {
            var result = await callback(db);
            await db.CommitTransactionAsync();
            return result;
        }
        // TODO: добавить правильную обработку в зависимости от SqlState
        // должен прилетать Npgsql.PostgresException - наследуется от NpgsqlException
        // есть свойство SqlState, подробнее https://www.postgresql.org/docs/current/errcodes-appendix.html
        catch (Exception)
        {
            await db.RollbackTransactionAsync();
            throw;
        }
    }

    private AppDataConnection GetConnection()
    {
        var config = _builder
            .UseTraceLevel(System.Diagnostics.TraceLevel.Info);

        var dataOptions = new DataOptions<AppDataConnection>(config);
        return new AppDataConnection(dataOptions);
    }
}