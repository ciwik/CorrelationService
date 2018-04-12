using Core;
using Core.Correlation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiService
{
    public class CorrelationRequestNumeric
    {
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty("type")]
        public CorrelationType Type { get; set; }
        [JsonProperty("function1")]
        public Function Function1 { get; set; }
        [JsonProperty("function2")]
        public Function Function2 { get; set; }        
    }
}
