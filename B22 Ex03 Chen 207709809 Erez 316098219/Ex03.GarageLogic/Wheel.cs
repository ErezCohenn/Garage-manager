using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public enum eDetails
        {
            CurrentAirPressure,
            ManufacturerName,
        }

        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private float r_MaxAirPressureByManufacturer;
        private static readonly string[] sr_EnergyDetails = { "CurrentAirPressure", "ManufacturerName" };

        public Wheel(float i_MaxAirPressureByManufacturer)
        {
            r_ManufacturerName = null;
            m_CurrentAirPressure = 0;
            r_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;
        }

        public virtual Dictionary<string, string> GetEnergyDeatials()
        {
            Dictionary<string, string> deatilsToFill = new Dictionary<string, string>();

            deatilsToFill.Add(sr_EnergyDetails[(int)eDetails.CurrentAirPressure], string.Empty);
            deatilsToFill.Add(sr_EnergyDetails[(int)eDetails.ManufacturerName], string.Empty);

            return deatilsToFill;
        }

        public void WheelInflation(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd <= r_MaxAirPressureByManufacturer)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            // might put here exeption if  m_currentAirPressure + i_AirToAdd > m_maxAirPressureByManufacturer.
        }

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }
        public float EnergyPercentageLeft
        {
            get
            {
                return r_MaxAirPressureByManufacturer;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressureByManufacturer;
            }
        }


    }
}
