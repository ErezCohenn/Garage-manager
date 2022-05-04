using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
        public enum eVehicleType
        {
            FuelCar = 1,
            ElectricCar = 2,
            FuelMotorcycle = 3,
            ElectricMotorcycle = 4,
            FuelTruck = 5,
        }

        private readonly List<string> r_SupportedVehicles = new List<string>() { "Fuel Car.", "Electric Car.", "Fuel Motorcycle.", "Electric Motorcycle.", "Fuel Truck." };

        public Vehicle ProduceVehicle(string i_LicenseNumber, eVehicleType i_VehicleType)
        {
            Vehicle vehicle = null;

            if (i_VehicleType == eVehicleType.FuelCar)
            {
                vehicle = new Car(new FuelEnergy(Car.FuelConstatns.k_MaxTankFuelCapacityInLiters, Car.FuelConstatns.k_FuelType), i_LicenseNumber);
            }
            else if (i_VehicleType == eVehicleType.ElectricCar)
            {
                vehicle = new Car(new ElectricEnergy(Car.ElectricConstatns.k_MaxBattaryCapacityInHours), i_LicenseNumber);
            }
            else if (i_VehicleType == eVehicleType.FuelMotorcycle)
            {
                vehicle = new Motorcycle(new FuelEnergy(Motorcycle.FuelConstatns.k_MaxTankFuelCapacityInLiters, Motorcycle.FuelConstatns.k_FuelType), i_LicenseNumber);
            }
            else if (i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                vehicle = new Motorcycle(new ElectricEnergy(Motorcycle.ElectricConstatns.k_MaxBattaryCapacityInHours), i_LicenseNumber);
            }
            else if (i_VehicleType == eVehicleType.FuelTruck)
            {
                vehicle = new Truck(new FuelEnergy(Truck.FuelConstatns.k_MaxTankFuelCapacityInLiters, Truck.FuelConstatns.k_FuelType), i_LicenseNumber);
            }

            if (vehicle == null)
            {
                throw new NullReferenceException("Error: Failed to create new vehicle!");
            }

            return vehicle;
        }

        public void AddExtraDetailsToVehicle(Vehicle i_VehicleToUpdate, KeyValuePair<string, string> i_DetailToFill)
        {
            bool isDetailFound = i_VehicleToUpdate.UpdateDetail(i_DetailToFill);

            if (!isDetailFound)
            {
                throw new ArgumentException("Error: Detail type was inserted is not found");
            }
        }

        public List<string> SupportedVehicles
        {
            get
            {
                return r_SupportedVehicles;
            }
        }
    }
}
