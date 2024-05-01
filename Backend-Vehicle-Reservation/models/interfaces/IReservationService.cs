using VehicleReservation.Models.Entities;

namespace VehicleReservation.Models.Interfaces;

public interface IReservationService
{
    void Add(Reservation reservation);
    Boolean ValidReservation(Reservation reservation);
}