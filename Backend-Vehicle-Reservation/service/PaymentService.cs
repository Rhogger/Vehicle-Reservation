using VehicleReservation.Models.Entities;
using VehicleReservation.Models.Interfaces;
using VehicleReservation.Database;
using VehicleReservation.Enums;

namespace VehicleReservation.Service;

public class PaymentService : IPaymentService
{
    private readonly ConnectionContext _context;

    public PaymentService(ConnectionContext context)
    {
        _context = context;
    }

    public List<Payment> GetByFilter(int? reservation_id, double? value, PaymentType? type)
    {
        IQueryable<Payment> payments = _context.Set<Payment>();

        if (reservation_id != null)
            payments = payments.Where(v => v.reservation_id == reservation_id);  

        if (value != null)
        {
            payments = payments.Where(r => r.value == value);
        }

        if (type != null)
        {
            payments = payments.Where(r => r.type == type);
        } 

        return payments.ToList();
    }

    public void Add(Payment payment)
    {    
        if (!ReservationExists(payment.reservation_id))
            throw new InvalidOperationException("Invalid reservation_id. Reservation does not exist.");

        if (PaymentExistsForReservation(payment.reservation_id))    
            throw new InvalidOperationException("Payment already exists for this reservation.");    

        _context.Payments.Add(payment);
        _context.SaveChanges();
    }

    public bool ReservationExists(int reservationId)
    {
        return _context.Reservations.Any(r => r.reservation_id == reservationId);
    }   

    public bool PaymentExistsForReservation(int reservationId)
    {
        return _context.Payments.Any(p => p.reservation_id == reservationId);
    }    
}