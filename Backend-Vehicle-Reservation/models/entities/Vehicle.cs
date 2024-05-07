using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VehicleReservation.Models.Entities
{
    [Table("vehicles")]
    public class Vehicle
    {
        [Key]
        [JsonIgnore]
        public int? vehicle_id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string color { get; set; }
        public string plate { get; set; }
        public int passenger_capacity { get; set; }
    }
}