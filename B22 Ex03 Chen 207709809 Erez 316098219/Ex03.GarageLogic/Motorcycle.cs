using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {

        internal static class FuelConstatns
        {
            internal const FuelEnergy.eType k_FuelType = FuelEnergy.eType.Octan98;
            internal const float k_FuelAfterGenerate = 4;
            internal const float k_MaxTankFuelCapacityInLiters = 6.2f;

        }

        internal static class ElectricConstatns
        {
            internal const float k_BattaryAfterGenerate = 1;
            internal const float k_MaxBattaryCapacityInHours = 2.5f;

        }

        internal static class WheelConstatns
        {
            internal const float k_AirPressureAfterGenerate = 25;
            internal const float k_MaxAirPressure = 31;
            internal static readonly int sr_NumberOfWheel = 2;

        }

        public enum eLicenseType
        {
            A,
            A1,
            B1,
            BB,
        }

        public enum eDetails
        {
            LicenseType,
            EngineCapacity,
        }

        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;
        private static readonly string[] sr_MotorCycleDetails = { "LicenseType", "EngineCapacity" };

        public Motorcycle(EnergySource i_EnergySource, string i_LicenseNumber) : base(i_EnergySource, i_LicenseNumber, WheelConstatns.sr_NumberOfWheel, WheelConstatns.k_MaxAirPressure, WheelConstatns.k_AirPressureAfterGenerate)
        {
            m_LicenseType = eLicenseType.A;
            m_EngineCapacity = 50;
        }

        public override Dictionary<string, string> GetVehicleDeatials()
        {
            Dictionary<string, string> deatilsToFill = base.GetVehicleDeatials();

            foreach (string detail in sr_MotorCycleDetails)
            {
                deatilsToFill.Add(detail, string.Empty);
            }

            return deatilsToFill;
        }

        public override string ToString()
        {
            return string.Concat(base.ToString(), string.Format("MotorCycle License type: {0}{1} Engine Capacity: {2}{3}", m_LicenseType, Environment.NewLine, m_EngineCapacity, Environment.NewLine));
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }
        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                m_EngineCapacity = value;
            }
        }
    }
}
