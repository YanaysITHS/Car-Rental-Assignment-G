namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    string RegistrationNumber { get; }
    IPerson Customer { get; }
    int KmRented { get; }
    int? KmReturned { get; set; }
    DateTime DateRented { get; }
    DateTime? DateReturned { get;}
    double? Cost { get; }
    string Status { get; }

    void UpdateBooking(IVehicle vehicle);
}

