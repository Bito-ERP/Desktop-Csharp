using Dapper;
using System.Data;
using System.Text.Json;

namespace BitoDesktop.Data.Converters;


public class JsonConverter<T> : SqlMapper.TypeHandler<T>
{
    public override T Parse(object value)
    {
        return value is null ? default : JsonSerializer.Deserialize<T>(value.ToString());
    }

    public override void SetValue(IDbDataParameter parameter, T value)
    {
        parameter.Value = value is null ? null : JsonSerializer.Serialize(value);
    }
}