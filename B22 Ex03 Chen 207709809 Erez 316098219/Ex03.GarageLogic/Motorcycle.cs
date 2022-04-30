using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private readonly string r_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorcycle(string i_LicenseType, int i_EngineCapacity, float i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft, int i_NumberOfVehicleWheels) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageLeft, i_NumberOfVehicleWheels)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public string LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }
        public int EngineCapacity
        {
            get
            {
                return r_EngineCapacity;
            }
        }
    }
}
