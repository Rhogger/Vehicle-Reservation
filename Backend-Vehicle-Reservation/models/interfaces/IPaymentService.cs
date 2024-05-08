using VehicleReservation.Models.Entities;

namespace VehicleReservation.Models.Interfaces;

public interface IPaymentService
{
    List<Payment> GetByFilter(int? reservation_id, double? value, string? type);
    void Add(Payment payment);
    bool ReservationExists(int reservationId);
    bool PaymentExistsForReservation(int reservationId);
}