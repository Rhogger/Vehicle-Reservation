using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;
using VehicleReservation.Database;

namespace VehicleReservation.Service;

public class ReservationService : IReservationService
{
    private readonly ConnectionContext _context;
    private readonly IVehicleService _vehicleService;

    public ReservationService(ConnectionContext context, IVehicleService vehicleService)
    {
        _context = context;
        _vehicleService = vehicleService;
    }

    public List<Reservation> GetByFilter(int? vehicle_id, DateTime? startDate, DateTime? endDate)
    {
        IQueryable<Reservation> reservations = _context.Set<Reservation>();

        if (vehicle_id != null)
            reservations = reservations.Where(v => v.vehicle_id == vehicle_id);  

        if (startDate != null)
        {
            DateTime startUtc = startDate.Value.ToUniversalTime();
            reservations = reservations.Where(r => r.start_date >= startUtc || r.end_date >= startUtc);
        }

        if (endDate != null)
        {
            DateTime endUtc = endDate.Value.ToUniversalTime();
            reservations = reservations.Where(r => r.start_date <= endUtc || r.end_date <= endUtc);
        } 

        return reservations.ToList();
    }

    public void Add(Reservation reservation)
    {
        if (!_vehicleService.VehicleMin())
            throw new InvalidOperationException("There are not enough cars available to make the reservation.");        

        if (!ValidReservation(reservation))        
            throw new InvalidOperationException("There is already a reservation for this vehicle during this period.");
        
        TimeSpan difference = reservation.end_date - reservation.start_date;
        int numberOfDays = difference.Days; 
        reservation.value = numberOfDays * 150;

        _context.Reservations.Add(reservation);
        _context.SaveChanges();
    }

    public Boolean ValidReservation(Reservation reservation)
    {
        return !_context.Reservations.Any(r =>
            r.vehicle_id == reservation.vehicle_id && 
            ((reservation.start_date <= r.end_date && reservation.start_date >= r.start_date) || 
            (reservation.end_date <= r.end_date && reservation.end_date >= r.start_date )));
    }
}