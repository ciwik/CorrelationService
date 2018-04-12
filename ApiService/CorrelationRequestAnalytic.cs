using Core.Correlation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiService
{
    public class CorrelationRequestAnalytic
    {
        [JsonConverter(typeof(StringEnumConverter)), JsonProperty("type")]
        public CorrelationType Type { get; set; }
        [JsonProperty("function1")]
        public string Function1 { get; set; }
        [JsonProperty("function2")]
        public string Function2 { get; set; }
        [JsonProperty("leftBorder")]
        public double LeftBorder { get; set; }
        [JsonProperty("rightBorder")]
        public double RightBorder { get; set; }
        [JsonProperty("pointsCount")]
        public int PointsCount { get; set; }
    }
}
