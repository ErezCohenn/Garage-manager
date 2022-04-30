namespace Ex03.GarageLogic
{
    class VehiclesManufacture
    {
        public enum eVehicleType
        {
            Car,
            MotorCycle,
            Truck,
        }

        public Vehicle ProduceVehicle(eVehicleType i_VehicleType)
        {
            Vehicle vehicle = null;

            if (i_VehicleType == eVehicleType.Car)
            {
                vehicle = new Car();
            }
            else if (i_VehicleType == eVehicleType.MotorCycle)
            {
                vehicle = new Motorcycle();
            }
            else if (i_VehicleType == eVehicleType.Truck)
            {
                vehicle = new Truck();
            }
            else
            {

            }

            return vehicle;


        }
    }
}
