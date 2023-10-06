using BitoDesktop.Domain.Entities;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

