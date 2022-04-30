namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private float r_MaxAirPressureByManufacturer;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressureByManufacturer)
        {
            r_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;
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

    }
}
