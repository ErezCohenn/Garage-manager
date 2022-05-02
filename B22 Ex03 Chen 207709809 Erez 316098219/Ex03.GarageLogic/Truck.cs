using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        internal static class FuelConstatns
        {
            internal const FuelEnergy.eType k_FuelType = FuelEnergy.eType.Soler;
            internal const float k_MaxTankFuelCapacityInLiters = 120;

        }

        internal static class WheelConstatns
        {
            internal const float k_MaxAirPressure = 24;
            internal static readonly int sr_NumberOfWheel = 16;

        }


        public enum eDetails
        {
            CargoCapcity,
            CanCarryRefrigerated,
        }

        private float m_CargoCapcity;
        private bool m_CanCarryRefrigerated;
        private static readonly int sr_NumberOfWheel = 4;
        private static readonly string[] sr_TruckDetails = { "CargoCapcity", "CanCarryRefrigerated" };
        private const float k_MaximumAirPressure = 24;

        public Truck(EnergySource i_EnergySource, string i_LicenseNumber) : base(i_EnergySource, i_LicenseNumber, sr_NumberOfWheel, k_MaximumAirPressure)
        {
            m_CargoCapcity = 50;
            m_CanCarryRefrigerated = true;
        }

        public override Dictionary<string, string> GetVehicleDeatials()
        {
            Dictionary<string, string> deatilsToFill = base.GetVehicleDeatials();

            foreach (string detail in sr_TruckDetails)
            {
                deatilsToFill.Add(detail, string.Empty);
            }

            return deatilsToFill;
        }

        public override string ToString()
        {
            string CanCarryRefrigeratedString = m_CanCarryRefrigerated == true ? "Yes" : "No";

            return string.Concat(base.ToString(), string.Format("Truck Cargo Capcit: {0}{1}m_CanCarryRefrigerated: {2}{3}", m_CargoCapcity, Environment.NewLine, CanCarryRefrigeratedString, Environment.NewLine));
        }

        public float CargoCapcity
        {
            get
            {
                return m_CargoCapcity;
            }
            set
            {
                m_CargoCapcity = value;
            }
        }
        public bool CanCarryRefrigerated
        {
            get
            {
                return m_CanCarryRefrigerated;
            }
            set
            {
                m_CanCarryRefrigerated = value;
            }
        }

        public static int NumberOfWheels
        {
            get
            {
                return sr_NumberOfWheel;
            }
        }
    }
}
