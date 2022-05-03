using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Client
    {
        private readonly string r_Name;
        private readonly string r_PhoneNumber;
        private readonly Vehicle r_Vehicle;
        private Garage.eVehicleStatus m_VehicleStatus;
        private static readonly int sr_MaxNameLength = 20;
        private static readonly int sr_PhoneNumberLength = 20;
        public Client(string i_Name, string i_PhoneNumber, Vehicle i_Vehicle, Garage.eVehicleStatus i_VehicleStatus)
        {
            r_Name = i_Name;
            r_PhoneNumber = i_PhoneNumber;
            r_Vehicle = i_Vehicle;
            m_VehicleStatus = i_VehicleStatus;
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.Append("=================================================================");
            vehicleDetails.Append(Environment.NewLine);
            vehicleDetails.Append("Vehicle Details:");
            vehicleDetails.Append(Environment.NewLine);
            vehicleDetails.Append("=================================================================");
            vehicleDetails.Append(Environment.NewLine);
            vehicleDetails.Append(string.Format("Owner: {1}{2}Phone number: {3}{4}Status in the Garage: {5}{6}", Environment.NewLine, r_Name, Environment.NewLine, r_PhoneNumber, Environment.NewLine, m_VehicleStatus, Environment.NewLine));
            vehicleDetails.Append(r_Vehicle.ToString());
            vehicleDetails.Append("=================================================================");
            vehicleDetails.Append(Environment.NewLine);

            return vehicleDetails.ToString();
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

        public Garage.eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public static int MaxNameLength
        {
            get
            {
                return sr_MaxNameLength;
            }
        }

        public static int PhoneNumberLength
        {
            get
            {
                return sr_PhoneNumberLength;
            }
        }
    }
}
