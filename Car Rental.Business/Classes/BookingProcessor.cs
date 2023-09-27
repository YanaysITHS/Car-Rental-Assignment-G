using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;

    public BookingProcessor(IData db) => _db = db;

    public IEnumerable<IPerson> GetCustomers() => _db.GetPersons();

    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _db.GetVehicles(status);

    public IEnumerable<IBooking> GetBookings() => _db.GetBookings();

    public void CloseBooking(IBooking booking)
    {
        if (booking.KmReturned is null || booking.KmReturned < booking.KmRented || booking.DateReturned < booking.DateRented) return;

        var vehicle = GetVehicles(VehicleStatuses.Booked).SingleOrDefault(v => v.RegistrationNumber.Equals(booking.RegistrationNumber));
        
        if (vehicle is null) return;

        booking.UpdateBooking(vehicle);

        vehicle.UpdateVehicle((int)booking.KmReturned, VehicleStatuses.Available);
    }
}