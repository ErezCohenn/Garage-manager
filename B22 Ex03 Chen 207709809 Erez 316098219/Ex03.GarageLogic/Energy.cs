namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        private float m_CurrentAmountOfEnergy;
        private readonly float r_MaxEnergy;

        public Energy(float i_AmountOfEnergy, float i_MaxEnergy)
        {
            m_CurrentAmountOfEnergy = i_AmountOfEnergy;
            r_MaxEnergy = i_MaxEnergy;
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
