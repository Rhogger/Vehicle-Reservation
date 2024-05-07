using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleReservation.Models.Entities
{
    public class Vehicle
    {
        [Key]
        public string Vehicle_Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
        public int Passenger_Capacity { get; set; }
    }
}