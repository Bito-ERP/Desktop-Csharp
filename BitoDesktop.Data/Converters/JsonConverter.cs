using Dapper;
using Newtonsoft.Json;
using System.Data;

namespace BitoDesktop.Data.Converters;


public class JsonConverter<T> : SqlMapper.TypeHandler<T>
{
    public override T Parse(object value)
    {
        return JsonConvert.DeserializeObject<T>(value.ToString());
    }

    public override void SetValue(IDbDataParameter parameter, T value)
    {
        parameter.Value = JsonConvert.SerializeObject(value);
    }
}