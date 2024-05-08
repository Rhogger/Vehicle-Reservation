using VehicleReservation.Models.Entities;

namespace VehicleReservation.Models.Interfaces;

public interface IReservationService
{
    List<Reservation> GetByFilter(int? vehicle_id, DateTime? startDate, DateTime? endDate);
    void Add(Reservation reservation);
    Boolean ValidReservation(Reservation reservation);
}