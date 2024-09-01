using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherPI.Shared.Models
{
    [DataContract]
    public class WeatherPIData
    {
        private decimal? _latitude;
        private decimal? _longitude;
        private decimal? _temperature;
        private decimal? _relativeHumidity;
        private decimal? _barometricPressure;

        [Key]
        [DataMember]
        public long? Id { get; set; }

        [DataMember]
        public long? StationId { get; set; }

        [DataMember]
        public string? Name { get; set; }

        [DataMember]
        public decimal? Latitude
        {
            get => _latitude;
            set => _latitude = value.HasValue ? Math.Round(value.Value, 2) : (decimal?)null;
        }

        [DataMember]
        public decimal? Longitude
        {
            get => _longitude;
            set => _longitude = value.HasValue ? Math.Round(value.Value, 2) : (decimal?)null;
        }

        [DataMember]
        public decimal? Temperature
        {
            get => _temperature;
            set => _temperature = value.HasValue ? Math.Round(value.Value, 2) : (decimal?)null;
        }

        [DataMember]
        public decimal? RelativeHumidity
        {
            get => _relativeHumidity;
            set => _relativeHumidity = value.HasValue ? Math.Round(value.Value, 2) : (decimal?)null;
        }

        [DataMember]
        public decimal? BarometricPressure
        {
            get => _barometricPressure;
            set => _barometricPressure = value.HasValue ? Math.Round(value.Value, 2) : (decimal?)null;
        }

        [DataMember]
        public DateTime? DateTime { get; set; }
    }
}
