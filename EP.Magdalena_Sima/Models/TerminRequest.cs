using System;
using EP.Magdalena_Sima.Converters;
using Newtonsoft.Json;

namespace EP.Magdalena_Sima.Models
{
    public class TerminRequest
    {
        [JsonConverter(typeof(GenesisDateConverter))]
        public DateTime START_DT { get; set; }

        [JsonConverter(typeof(GenesisDateConverter))]
        public DateTime END_DT { get; set; }

        public string KEYWORD { get; set; }

        public bool GWDURATIONMANUAL { get; set; }
    }
}