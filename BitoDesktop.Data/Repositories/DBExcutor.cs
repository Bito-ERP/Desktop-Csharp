using Npgsql;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Transactions;
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

    public NpgsqlConnection CreateConnnection() => new(_connectionString);

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

    public async Task<int> ExecuteAsync(NpgsqlConnection connection, string sql, object parameters = null)
    {
        return await connection.ExecuteAsync(sql, parameters);

    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            Debug.WriteLine(sql);
            Debug.WriteLine(parameters);
            return await connection.QueryAsync<T>(sql, parameters);
        }
    }


    public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object parameters = null)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            return await connection.QuerySingleOrDefaultAsync<T>(sql, parameters);
        }
    }

}
