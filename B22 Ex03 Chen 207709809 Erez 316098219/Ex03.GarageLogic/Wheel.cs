namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_manufacturerName;
        private float m_currentAirPressure;
        private float m_maxAirPressureByManufacturer;

        public void WheelInflation(float i_AirToAdd)
        {
            if (m_currentAirPressure + i_AirToAdd <= m_maxAirPressureByManufacturer)
            {
                m_currentAirPressure += i_AirToAdd;
            }
            // might put here exeption if  m_currentAirPressure + i_AirToAdd > m_maxAirPressureByManufacturer.
        }
    }
}
