using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MNSDotNetTrainingBatch1.Shared
{
    public static class DevCode
    {
        public static bool IsNullOrEmptyV2(this string? str)
        {
            return str != null && !string.IsNullOrEmpty(str.Trim());
        }
        public static bool IsNullOrEmptyV2(this decimal? price)
        {
            return price != null && price > 0;
        }
        public static bool IsNullOrEmptyV2(this int? quantity)
        {
            return quantity != null && quantity > 0;
        }
        public static string ToJson(this object? obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
