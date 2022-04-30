using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
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
        private static readonly int sr_NumberOfWheel = 2;
        private static readonly string[] sr_CarDetails = { "LicenseType", "EngineCapacity" };
        private const float k_MaximumAirPressure = 29;

        public Motorcycle(EnergySource i_EnergySource, string i_LicenseNumber) : base(i_EnergySource, i_LicenseNumber, sr_NumberOfWheel, k_MaximumAirPressure)
        {
            m_LicenseType = eLicenseType.A;
            m_EngineCapacity = 50;
        }

        public override Dictionary<string, string> GetVehicleDeatials()
        {
            Dictionary<string, string> deatilsToFill = base.GetVehicleDeatials();

            deatilsToFill.Add(sr_CarDetails[(int)eDetails.LicenseType], string.Empty);
            deatilsToFill.Add(sr_CarDetails[(int)eDetails.EngineCapacity], string.Empty);

            return deatilsToFill;
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

        public static int NumberOfWheels
        {
            get
            {
                return sr_NumberOfWheel;
            }
        }
    }
}
