using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    public string RegistrationNumber { get; }
    string Make { get; }
    int Odometer { get; }
    double CostKm { get; }
    VehicleTypes VehicleType { get; }
    double CostDay { get; }
    VehicleStatuses Status { get; }

    void UpdateVehicle(int odometer, VehicleStatuses status);
}
