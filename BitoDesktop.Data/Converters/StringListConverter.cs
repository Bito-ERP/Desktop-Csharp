using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace BitoDesktop.Data.Converters;

public class StringListConverter : JsonConverter<List<string>> { }

