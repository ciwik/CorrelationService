using Newtonsoft.Json;

namespace ApiService
{
    public class CorrelationResponse
    {
        [JsonProperty("value")]
        public double Value { get; set; }
        [JsonProperty("executionTime")]
        public long ExecutionTime { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
