using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VehicleReservation.Models.Entities;

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
    [JsonConstructor]
    public Vehicle() { }

    public Vehicle(string make, string model, string year, string color, string plate, int passenger_capacity)
    {
        this.make = make;
        this.model = model;
        this.year = year;
        this.color = color;
        this.plate = plate;
        this.passenger_capacity = passenger_capacity;
    }
    public bool IsValid()
    {
        if (!IsValidMake()) return false;
        if (!IsValidModel()) return false;
        if (!IsValidYear()) return false;
        if (!IsValidColor()) return false;
        if (!IsValidPlate()) return false;
        if (!IsValidNumberOfPassengers()) return false;

        return true;
    }

    public bool IsValidMake()
    {
        bool valid = true;

        try
        {
            if (string.IsNullOrEmpty(make)) throw new ArgumentNullException("Car branch can't be null or empty string.");
        }
        catch
        {
            valid = false;
        }

        return valid;
    }

    public bool IsValidModel()
    {
        bool valid = true;

        try
        {
            if (string.IsNullOrEmpty(model)) throw new ArgumentNullException("Car model can't be null or empty string.");
        }
        catch
        {
            valid = false;
        }

        return valid;
    }

    public bool IsValidYear()
    {
        bool valid = true;

        try
        {
            if (string.IsNullOrEmpty(year)) throw new ArgumentNullException("Car year can't be null or empty string.");
        }
        catch
        {
            valid = false;
        }

        return valid;
    }

    public bool IsValidColor()
    {
        bool valid = true;

        try
        {
            if (string.IsNullOrEmpty(color)) throw new ArgumentNullException("Color of car can't be null or empty string.");
        }
        catch
        {
            valid = false;
        }

        return valid;
    }

    public bool IsValidPlate()
    {
        bool valid = true;

        try
        {
            if (string.IsNullOrEmpty(plate)) throw new ArgumentNullException("Car plate can't be null or empty string.");
        }
        catch
        {
            valid = false;
        }

        return valid;
    }

    public bool IsValidNumberOfPassengers()
    {
        bool valid = true;

        try
        {
            if (passenger_capacity < 1) throw new Exception("The number of passengers cannot be less than 1.");
        }
        catch
        {
            valid = false;
        }

        return valid;
    }
}
