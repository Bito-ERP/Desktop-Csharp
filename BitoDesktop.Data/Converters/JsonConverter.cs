using BitoDesktop.Domain.Entities.Products;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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