using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Classes;

using System.Globalization;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<IPerson> _persons = new();
    readonly List<IVehicle> _vehicles = new();
    readonly List<IBooking> _bookings = new();

    public CollectionData() => SeedData();

    void SeedData()
    {
        _persons.Add(new Customer(12345, "Jhon", "Doe"));
        _persons.Add(new Customer(98765, "Jackie", "Chan"));
        _persons.Add(new Customer(67890, "Betty", "Boop"));
        _persons.Add(new Customer(99768, "Donald", "Duck"));

        _vehicles.Add(new Car("ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available));
        _vehicles.Add(new Car("DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100, VehicleStatuses.Booked));
        _vehicles.Add(new Car("GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100, VehicleStatuses.Booked));
        _vehicles.Add(new Car("JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300, VehicleStatuses.Available));
        _vehicles.Add(new Motorcycle("MNO234", "Yamaha", 30000, 0.5, VehicleTypes.Motorcycle, 50, VehicleStatuses.Available));

        _bookings.Add(new Booking("GHI789", _persons[0], 1000, DateTime.Parse("23/9/9")));
        _bookings.Add(new Booking("DEF456", _persons[1], 20000, DateTime.Parse("23/9/9")));
        _bookings.Add(new Booking("MN0234", _persons[2], 29900, DateTime.Parse("23/9/20"), 30000, DateTime.Parse("23/9/20"), 50, "Closed"));
        _bookings.Add(new Booking("ABC123", _persons[3],  10000,  DateTime.Parse("23/9/7"), 10000, DateTime.Parse("23/09/09"), 200, "Closed"));     
    }

    public IEnumerable<IPerson> GetPersons() => _persons;
    public IEnumerable<IBooking> GetBookings() => _bookings;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
    {
        if(status == default) return _vehicles;
        return _vehicles.Where(s => s.Status.Equals(status));
    }
}