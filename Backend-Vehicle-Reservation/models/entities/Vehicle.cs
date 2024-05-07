using System.ComponentModel.DataAnnotations;

namespace VehicleReservation.Models.Entities
{
    public class Vehicle
    {
        [Key]
        public string? Vehicle_Id { get; set; } = "";
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
        public int Passenger_Capacity { get; set; }

        public Vehicle(string make, string model, string year, string color, string plate, int passengerCapacity)
        {
            if (string.IsNullOrEmpty(make)) throw new ArgumentNullException("Car branch can't be null or empty string.");
            Make = make;

            if (string.IsNullOrEmpty(model)) throw new ArgumentNullException("Car model can't be null or empty string.");
            Model = model;

            if (string.IsNullOrEmpty(year)) throw new ArgumentNullException("Car year can't be null or empty string.");
            Year = year;

            if (string.IsNullOrEmpty(color)) throw new ArgumentNullException("Color of car can't be null or empty string.");
            Color = color;

            if (string.IsNullOrEmpty(plate)) throw new ArgumentNullException("Car plate can't be null or empty string.");
            Plate = plate;

            if (passengerCapacity < 1) throw new Exception("The number of passengers cannot be less than 1.");
            Passenger_Capacity = passengerCapacity;
        }
    }
}