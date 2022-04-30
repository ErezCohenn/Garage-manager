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

        protected virtual void LoadEnergy(float i_AmountOfEnergyToLoad)
        {
            if (i_AmountOfEnergyToLoad + CurrentAmountOfEnergy > MaxEnergy)
            {
                // throw exception
            }

            CurrentAmountOfEnergy += i_AmountOfEnergyToLoad;
        }

        public float CurrentAmountOfEnergy
        {
            get
            {
                return m_CurrentAmountOfEnergy;
            }

            set
            {
                m_CurrentAmountOfEnergy = value;
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
