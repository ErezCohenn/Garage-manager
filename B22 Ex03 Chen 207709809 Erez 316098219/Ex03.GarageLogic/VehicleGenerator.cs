using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
        public enum eVehicleType
        {
            Car = 1,
            Motorcycle = 2,
            Truck = 3,
        }

        public enum eEnergyType
        {
            Fuel = 1,
            Electric = 2,
        }

        private readonly List<string> r_SupportedVehicles = new List<string>() { "Car.", "Motorcycle.", "Truck." };
        private readonly List<string> r_SupportedEnergySources = new List<string>() { "Fuel.", "Electric." };

        public Vehicle ProduceVehicle(string i_LicenseNumber, eVehicleType i_VehicleType, eEnergyType i_EnergyType)
        {
            Vehicle vehicle = null;
            EnergySource energy = produceEnergySource(i_EnergyType, i_VehicleType);

            if (i_VehicleType == eVehicleType.Car)
            {
                vehicle = new Car(energy, i_LicenseNumber);
            }
            else if (i_VehicleType == eVehicleType.Motorcycle)
            {
                vehicle = new Motorcycle(energy, i_LicenseNumber);
            }
            else if (i_VehicleType == eVehicleType.Truck)
            {
                vehicle = new Truck(energy, i_LicenseNumber);
            }

            return vehicle;
        }

        private EnergySource produceEnergySource(eEnergyType i_EnergyType, eVehicleType i_VehicleType)
        {
            EnergySource energySource = null;

            if (i_EnergyType == eEnergyType.Electric && i_VehicleType == eVehicleType.Car)
            {
                energySource = new ElectricEnergy(Car.ElectricConstatns.k_MaxBattaryCapacityInHours, Car.ElectricConstatns.k_BattaryAfterGenerate);
            }
            else if (i_EnergyType == eEnergyType.Fuel && i_VehicleType == eVehicleType.Car)
            {
                energySource = new FuelEnergy(Car.FuelConstatns.k_MaxTankFuelCapacityInLiters, Car.FuelConstatns.k_FuelAfterGenerate, Car.FuelConstatns.k_FuelType);
            }
            else if (i_EnergyType == eEnergyType.Electric && i_VehicleType == eVehicleType.Motorcycle)
            {
                energySource = new ElectricEnergy(Motorcycle.ElectricConstatns.k_MaxBattaryCapacityInHours, Motorcycle.ElectricConstatns.k_BattaryAfterGenerate);
            }
            else if (i_EnergyType == eEnergyType.Fuel && i_VehicleType == eVehicleType.Motorcycle)
            {
                energySource = new FuelEnergy(Motorcycle.FuelConstatns.k_MaxTankFuelCapacityInLiters, Motorcycle.FuelConstatns.k_FuelAfterGenerate, Motorcycle.FuelConstatns.k_FuelType);
            }
            else if (i_EnergyType == eEnergyType.Fuel && i_VehicleType == eVehicleType.Truck)
            {
                energySource = new FuelEnergy(Truck.FuelConstatns.k_MaxTankFuelCapacityInLiters, Truck.FuelConstatns.k_FuelAfterGenerate, Truck.FuelConstatns.k_FuelType);
            }

            return energySource;
        }

        public List<string> SupportedVehicles
        {
            get
            {
                return r_SupportedVehicles;
            }
        }

        public List<string> SupportedEnergySources
        {
            get
            {
                return r_SupportedEnergySources;
            }
        }
    }
}
