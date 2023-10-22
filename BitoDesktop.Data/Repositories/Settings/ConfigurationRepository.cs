using Npgsql;
using System;
using System.Threading.Tasks;

namespace BitoDesktop.Data.Repositories.Settings
{
    public class ConfigurationRepository
    {

        private const string ConfigurationColumns = "Key, Value";
        private const string ConfigurationValues = "@Key, @Value";
        private const string ConfigurationUpdate = "Value = @Value";

        public class Editor
        {
            private readonly NpgsqlConnection connection;
            public Editor(NpgsqlConnection connection)
            {
                this.connection = connection;
            }

            private async Task<int> PutValue(string key, string value)
            {
                return await DBExcutor.ExecuteAsync(
                    "INSERT INTO configuration(" + ConfigurationColumns + ") VALUES(" + ConfigurationValues + ") " +
                    "ON CONFLICT (Key) " +
                    "DO UPDATE SET " + ConfigurationUpdate, new { Key = key, Value = value }, connection
                  );
            }

            public async Task<int> PutBoolean(string key, Boolean? value)
            {
                return await PutValue(key, value?.ToString());
            }

            public async Task<int> PutFloat(string key, float? value)
            {
                return await PutValue(key, value?.ToString());
            }

            public async Task<int> PutDouble(string key, double? value)
            {
                return await PutValue(key, value?.ToString());
            }

            public async Task<int> PutInt(string key, int? value)
            {
                return await PutValue(key, value?.ToString());
            }

            public async Task<int> PutLong(string key, long? value)
            {
                return await PutValue(key, value?.ToString());
            }

            public async Task<int> PutString(string key, string value)
            {
                return await PutValue(key, value);
            }

            public async Task<int> Remove(string key)
            {
                return await DBExcutor.ExecuteAsync("DELETE FROM configuration WHERE Key = @key", new { key }, connection);
            }
        }


        // Edit in transaction
        public async Task<int> Edit(Func<Editor, Task<int>> editor)
        {
            return await DBExcutor.InTransaction(connection =>
            {
                return editor(new Editor(connection));
            });
        }

        public async Task<Boolean> Contains(string key)
        {
            return await DBExcutor.QuerySingleOrDefaultAsync<Boolean>("SELECT EXISTS(SELECT Key FROM configuration WHERE Key = @key)", new { key });
        }


        private async Task<string> GetValue(string key)
        {
            return await DBExcutor.QuerySingleOrDefaultAsync<string>("SELECT Value FROM configuration WHERE Key = @key", new { key });
        }

        public async Task<Boolean?> GetBoolean(string key, Boolean? defValue = null)
        {
            var value = await GetValue(key);
            return value == null ? defValue : Boolean.Parse(value);
        }

        public async Task<float?> GetFloat(string key, float? defValue = null)
        {
            var value = await GetValue(key);
            return value == null ? defValue : float.Parse(value);
        }

        public async Task<double?> GetDouble(string key, double? defValue = null)
        {
            var value = await GetValue(key);
            return value == null ? defValue : double.Parse(value);
        }

        public async Task<int?> GetInt(string key, int? defValue = null)
        {
            var value = await GetValue(key);
            return value == null ? defValue : int.Parse(value);
        }

        public async Task<long?> GetLong(string key, long? defValue = null)
        {
            var value = await GetValue(key);
            return value == null ? defValue : long.Parse(value);
        }

        public async Task<string> GetString(string key, string defValue = null)
        {
            var value = await GetValue(key);
            return value ?? defValue;
        }

        private async Task<int> PutValue(string key, string value)
        {
            return await DBExcutor.UseConnection(async connection =>
            {
                return await (new Editor(connection)).PutString(key, value);
            });
        }

        public async Task<int> PutBoolean(string key, Boolean? value)
        {
            return await PutValue(key, value?.ToString());
        }

        public async Task<int> PutFloat(string key, float? value)
        {
            return await PutValue(key, value?.ToString());
        }

        public async Task<int> PutDouble(string key, double? value)
        {
            return await PutValue(key, value?.ToString());
        }

        public async Task<int> PutInt(string key, int? value)
        {
            return await PutValue(key, value?.ToString());
        }

        public async Task<int> PutLong(string key, long? value)
        {
            return await PutValue(key, value?.ToString());
        }

        public async Task<int> PutString(string key, string value)
        {
            return await PutValue(key, value);
        }

        public async Task<int> Remove(string key)
        {
            return await DBExcutor.ExecuteAsync("DELETE FROM configuration WHERE Key = @key", new { key });
        }

    }
}
