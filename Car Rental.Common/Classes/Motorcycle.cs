using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Motorcycle : IVehicle
{
    public string RegistrationNumber { get; init; }
    public string Make { get; init; }
    public int Odometer { get; set; }
    public double CostKm { get; init; }
    public VehicleTypes VehicleType { get; init; }
    public double CostDay { get; init; }
    public VehicleStatuses Status { get; set; }

    public Motorcycle(string registrationNumber, string make, int odometer, double costKm, VehicleTypes vehicleType,
        double costDay, VehicleStatuses status) =>

       (RegistrationNumber, Make, Odometer, CostKm, VehicleType, CostDay, Status) =
            (registrationNumber, make, odometer, costKm, vehicleType, costDay, status);

    public void UpdateVehicle(int odometer, VehicleStatuses status) => (Odometer, Status) = (odometer, status);
}
    