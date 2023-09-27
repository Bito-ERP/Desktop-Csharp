using Npgsql;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace BitoDesktop.Data.Repositories;

public delegate void TransactionExcutor(NpgsqlConnection con);

public class DBExcutor
{
    private readonly string _connectionString;

    public DBExcutor()
    {
        _connectionString = "Host=localhost;Port=5432;Database=maindb;Username=postgres;Password=password;";
    }

    public async Task<T> InTransaction<T>(Func<NpgsqlConnection, Task<T>> func)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var transaction = connection.BeginTransaction();
        try
        {
            var result = await func(connection);
            transaction.Commit();
            return result;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return await Task.FromException<T>(ex);
        }
    }

    public async Task<int> ExecuteAsync(string sql, object parameters = null, NpgsqlConnection connection = null)
    {
        if (connection == null)
            using (connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.ExecuteAsync(sql, parameters);
            }
        else
            return await connection.ExecuteAsync(sql, parameters);
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        Debug.WriteLine(sql);
        Debug.WriteLine(parameters);
        return await connection.QueryAsync<T>(sql, parameters);
    }


    public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object parameters = null, NpgsqlConnection connection = null)
    {
        if (connection == null)
            using (connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QuerySingleOrDefaultAsync<T>(sql, parameters);
            }
        else
            return await connection.QuerySingleOrDefaultAsync<T>(sql, parameters);
    }

}
