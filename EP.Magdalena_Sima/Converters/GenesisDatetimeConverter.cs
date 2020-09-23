using Newtonsoft.Json.Converters;

namespace EP.Magdalena_Sima.Converters
{
    public class GenesisDateConverter : IsoDateTimeConverter
    {
        public GenesisDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fff'Z'";
        }
    }
}