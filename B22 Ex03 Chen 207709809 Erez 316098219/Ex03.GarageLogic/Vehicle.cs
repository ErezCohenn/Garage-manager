using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly float r_ModelName;
        private readonly string r_LicenseNumber;
        private float m_EnergyPercentageLeft;
        private readonly List<Wheel> r_VehicleWheels;

        public Vehicle(float i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft, int i_NumberOfVehicleWheels)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_EnergyPercentageLeft = i_EnergyPercentageLeft;
            r_VehicleWheels = new List<Wheel>(i_NumberOfVehicleWheels);
        }

        public float EnergyPercentageLeft
        {
            get
            {
                return m_EnergyPercentageLeft;
            }

            set
            {
                m_EnergyPercentageLeft = value;
            }
        }

        public float ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public List<Wheel> VehicleWheels
        {
            get
            {
                return r_VehicleWheels;
            }
        }
    }
}
