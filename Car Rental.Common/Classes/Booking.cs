using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public string RegistrationNumber { get; init; }
    public IPerson Customer { get; init; }
    public int KmRented { get; init; }
    public int? KmReturned { get; set; }
    public DateTime DateRented { get; init; }
    public DateTime? DateReturned { get; private set; }
    public double? Cost { get; private set; } = null;
    public string Status { get; private set; }

    public Booking(string registrationNumber, IPerson customer, int kmRented, DateTime dateRented, int? kmReturned = null, DateTime? dateReturned = null,
         double? cost = null, string status = "Open")=>
    (RegistrationNumber, Customer, KmRented, DateRented, KmReturned, DateReturned, Cost, Status) =
        (registrationNumber, customer, kmRented, dateRented, kmReturned, dateReturned, cost, status);

    public void UpdateBooking(IVehicle vehicle)
    {
        var cost = (KmReturned - KmRented) * vehicle.CostKm + (DateTime.Now - DateRented).Days * vehicle.CostDay;
        if (cost is null || cost < 0) return;
        (DateReturned,Cost, Status) = (DateTime.Now, cost, "Closed");
    }
}

