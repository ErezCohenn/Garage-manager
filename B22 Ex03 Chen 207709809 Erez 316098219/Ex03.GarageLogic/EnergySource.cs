using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        public enum eDetails
        {
            CurrentAmountOfEnergy,
            MaxEnergy,
        }

        private float m_CurrentAmountOfEnergy;
        private readonly float r_MaxEnergy;
        private static readonly string[] sr_EnergyDetails = { "CurrentAmountOfEnergy", "MaxEnergy" };

        public EnergySource(float i_MaxEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
            m_CurrentAmountOfEnergy = 0;
        }

        public virtual Dictionary<string, string> GetEnergyDetails()
        {
            Dictionary<string, string> deatilsToFill = new Dictionary<string, string>();

            deatilsToFill.Add(sr_EnergyDetails[(int)eDetails.CurrentAmountOfEnergy], string.Empty);
            deatilsToFill.Add(sr_EnergyDetails[(int)eDetails.MaxEnergy], string.Empty);

            return deatilsToFill;
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
