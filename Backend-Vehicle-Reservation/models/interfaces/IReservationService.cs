using VehicleReservation.Models.Entities;

namespace VehicleReservation.Models.Interfaces;

public interface IReservationService
{
    List<Reservation> GetByFilter(int? reservation_id, int? vehicle_id, DateTime? startDate, DateTime? endDate);
    void Add(Reservation reservation);
    void Update(Reservation reservation);
    bool ValidReservation(Reservation reservation);
}