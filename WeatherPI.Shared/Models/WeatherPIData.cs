using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherPI.Shared.Models
{
    [DataContract]
    public class WeatherPIData
    {
        [Key]
        [DataMember]
        public long? Id { get; set; }

        [DataMember]
        public long? StationId { get; set; }

        [DataMember]
        public string? Name { get; set; }

        [DataMember]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal? Latitude { get; set; }

        [DataMember]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal? Longitude { get; set; }

        [DataMember]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal? Temperature { get; set; }

        [DataMember]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal? RelativeHumidity { get; set; }

        [DataMember]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal? BarometricPressure { get; set; }

        [DataMember]
        public DateTime? DateTime { get; set; }
    }
}
