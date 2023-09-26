using Npgsql;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Transactions;
using System;

namespace BitoDesktop.Data.Repositories;

public delegate void TransactionExcutor(NpgsqlConnection con);

public class DBExcutor
{
	private readonly string _connectionString;

	public DBExcutor()
	{
		_connectionString = "Host=localhost;Port=5432;Database=maindb;Username=postgres;Password=password;";
	}
    
    public Task<int> ExecuteAsync(string sql, object parameters = null)
	{
		using (var connection = new NpgsqlConnection(_connectionString))
		{
            connection.Open();
			return connection.ExecuteAsync(sql, parameters);
		}
	}

    public Task<int> ExecuteAsync(NpgsqlConnection connection, string sql, object parameters = null)
    {
        return connection.ExecuteAsync(sql, parameters);
      
    }

    public Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            return connection.QueryAsync<T>(sql, parameters);
        }
    }


    public Task<T> QuerySingleOrDefaultAsync<T>(string sql, object parameters = null)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            return connection.QuerySingleOrDefaultAsync<T>(sql, parameters);
        }
    }

}
