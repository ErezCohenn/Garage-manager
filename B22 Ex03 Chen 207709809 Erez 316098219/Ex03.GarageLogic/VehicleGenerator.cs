namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
        public enum eVehicleType
        {
            Car,
            Motorcycle,
            Truck,
        }

        public enum eEnergyType
        {
            Fuel,
            Electric,
        }


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
                energySource = new ElectricEnergy(3.3f);
            }
            else if (i_EnergyType == eEnergyType.Fuel && i_VehicleType == eVehicleType.Car)
            {
                energySource = new FuelEnergy(38, FuelEnergy.eType.Octan95);
            }
            else if (i_EnergyType == eEnergyType.Electric && i_VehicleType == eVehicleType.Motorcycle)
            {
                energySource = new ElectricEnergy(2.5f);
            }
            else if (i_EnergyType == eEnergyType.Fuel && i_VehicleType == eVehicleType.Motorcycle)
            {
                energySource = new FuelEnergy(6.2f, FuelEnergy.eType.Octan98);
            }
            else if (i_EnergyType == eEnergyType.Fuel && i_VehicleType == eVehicleType.Truck)
            {
                energySource = new FuelEnergy(120, FuelEnergy.eType.Soler);
            }

            return energySource;
        }
    }
}
