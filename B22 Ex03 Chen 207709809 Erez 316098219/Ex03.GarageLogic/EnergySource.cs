namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private float m_CurrentAmountOfEnergy;
        private readonly float r_MaxEnergy;

        public EnergySource(float i_AmountOfEnergy, float i_MaxEnergy)
        {
            m_CurrentAmountOfEnergy = i_AmountOfEnergy;
            r_MaxEnergy = i_MaxEnergy;
        }

        protected void FillEnergy(float i_AmountEnergyToLoad)
        {
            if (i_AmountEnergyToLoad + m_CurrentAmountOfEnergy > MaxEnergy)
            {
                // throw exception
            }

            m_CurrentAmountOfEnergy += i_AmountEnergyToLoad;
        }

        public float EnergyLeftInPercentage()
        {
            return (m_CurrentAmountOfEnergy / r_MaxEnergy) * 100;
        }

        public float CurrentAmountOfEnergy
        {
            get
            {
                return m_CurrentAmountOfEnergy;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }
    }
}
