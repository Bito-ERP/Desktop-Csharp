using Dapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace BitoDesktop.Data.Converters;

public class StringListConverter : SqlMapper.TypeHandler<List<string>>
{
    public override List<string> Parse(object value)
    {
        return JsonConvert.DeserializeObject<List<string>>(value.ToString());
    }

    public override void SetValue(IDbDataParameter parameter, List<string> value)
    {
        parameter.Value = JsonConvert.SerializeObject(value);
    }
}

