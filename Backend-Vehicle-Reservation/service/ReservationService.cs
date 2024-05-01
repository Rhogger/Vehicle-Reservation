using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;

namespace VehicleReservation.Service;

public class ReservationService : IReservationService
{
    private readonly List<Reservation> _reservations = new List<Reservation>();
    private readonly VehicleService _vehicleService;

    public void Add(Reservation reservation)
    {
        if (_vehicleService.VehicleMin())
        {
            if (ValidReservation(reservation))
            {
                TimeSpan difference = reservation.EndDate.Subtract(reservation.StartDate);
                int numberOfDays = difference.Days;
                reservation.Value = numberOfDays * 150; 
                _reservations.Add(reservation);
            }
            // else
            // dar um aviso que já tem reserva para esse carro nessa data                    
        } 
        // else
        // dar um aivso que não tem 5 carro vrum vrum
    }

    public Boolean ValidReservation(Reservation reservation)
    {
        Boolean result = true;
        foreach (var existingReservation in _reservations)
        {
            if (existingReservation.SelectedVehicle == reservation.SelectedVehicle)
            {
                if (reservation.StartDate < existingReservation.EndDate && reservation.EndDate > existingReservation.StartDate)
                    result = false;        
            }
        }
        return result;
    }
}