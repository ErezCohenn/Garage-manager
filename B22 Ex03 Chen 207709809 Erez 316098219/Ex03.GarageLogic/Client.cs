namespace Ex03.GarageLogic
{
    public class Client
    {
        private readonly string r_Name;
        private readonly string r_PhoneNumber;
        private readonly Vehicle r_Vehicle;
        private readonly eVehicleStatus r_VehicleStatus;

        public Client(string i_Name, string i_PhoneNumber, Vehicle i_Vehicle, eVehicleStatus i_VehicleStatus)
        {
            r_Name = i_Name;
            r_PhoneNumber = i_PhoneNumber;
            r_Vehicle = i_Vehicle;
            r_VehicleStatus = i_VehicleStatus;
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return r_PhoneNumber;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return r_VehicleStatus;
            }
        }
    }
}
