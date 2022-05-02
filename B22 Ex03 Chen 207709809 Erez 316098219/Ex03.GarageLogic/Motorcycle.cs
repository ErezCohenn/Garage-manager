using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {

        internal static class FuelConstatns
        {
            internal const FuelEnergy.eType k_FuelType = FuelEnergy.eType.Octan98;
            internal const float k_MaxTankFuelCapacityInLiters = 6.2f;
        }

        internal static class ElectricConstatns
        {
            internal const float k_MaxBattaryCapacityInHours = 2.5f;
        }

        internal static class WheelConstatns
        {
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

        private readonly eLicenseType m_LicenseType;
        private readonly int m_EngineCapacity;
        private static readonly string[] sr_MotorCycleDetails = { "Motorcylce License Type", "Motorcycle Engine Capacity" };

        public Motorcycle(EnergySource i_EnergySource, string i_LicenseNumber) : base(i_EnergySource, i_LicenseNumber, WheelConstatns.sr_NumberOfWheel, WheelConstatns.k_MaxAirPressure)
        {
            m_LicenseType = eLicenseType.A;
            m_EngineCapacity = 50;
        }


        public override Dictionary<string, string> GetVehicleDetails()
        {
            Dictionary<string, string> deatilsToFill = base.GetVehicleDetails();
            foreach (string detail in sr_MotorCycleDetails)
            {
                deatilsToFill.Add(detail, string.Empty);
            }

            return deatilsToFill;
        }

        public override string ToString()
        {
            string motorCycleToString = string.Format("MotorCycle License type: {0}{1}Engine Capacity: {2}{3}", m_LicenseType, Environment.NewLine, m_EngineCapacity, Environment.NewLine);

            return string.Concat(base.ToString(), motorCycleToString);
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }
        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }
    }
}
