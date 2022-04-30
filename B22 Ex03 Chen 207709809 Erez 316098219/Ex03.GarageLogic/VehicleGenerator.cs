namespace Ex03.GarageLogic
{
    class VehicleGenerator
    {
        public enum eVehicleType
        {
            FuelCar,
            FuelMotorcycle,
            ElectricCar,
            ElectricMotorcycle,
            Truck,
        }

        public Vehicle ProduceVehicle(eVehicleType i_VehicleType)
        {
            Vehicle vehicle = null;
            EnergySource energy = null;

            if (i_VehicleType == eVehicleType.ElectricCar || i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                energy = new ElectricEnergy();
            }
            else
            {
                energy = new FuelEnergy();
            }

            if (i_VehicleType == eVehicleType.ElectricCar || i_VehicleType == eVehicleType.FuelCar)
            {
                vehicle = new Car();
            }
            else if (i_VehicleType == eVehicleType.ElectricMotorcycle || i_VehicleType == eVehicleType.FuelMotorcycle)
            {
                vehicle = new Motorcycle();
            }
            else if (i_VehicleType == eVehicleType.Truck)
            {
                vehicle = new Truck();
            }

            return vehicle;
        }
    }
}
