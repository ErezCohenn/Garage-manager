using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        public enum eDetails
        {
            CurrentAmountOfEnergy,
        }

        private float m_CurrentAmountOfEnergy;
        private readonly float r_MaxEnergyCapacity;
        private static readonly string[] sr_EnergyDetails = { "Current Amount Of Energy" };

        public EnergySource(float i_MaxEnergy, float i_CurrentAmountOfEnergy)
        {
            r_MaxEnergyCapacity = i_MaxEnergy;
            m_CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
        }

        public virtual Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> deatilsToFill = new Dictionary<string, string>();

            foreach (string detail in sr_EnergyDetails)
            {
                deatilsToFill.Add(detail, string.Empty);
            }

            return deatilsToFill;
        }

        protected void FillEnergy(float i_AmountEnergyToLoad)
        {
            if (i_AmountEnergyToLoad + m_CurrentAmountOfEnergy > MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(r_MaxEnergyCapacity - m_CurrentAmountOfEnergy, 0, "Energy amount to add");
            }

            m_CurrentAmountOfEnergy += i_AmountEnergyToLoad;
        }

        public float EnergyLeftInPercentage()
        {
            return (m_CurrentAmountOfEnergy / r_MaxEnergyCapacity) * 100;
        }

        public override string ToString()
        {
            return string.Format("Fuel state in percent: {0}{1}", EnergyLeftInPercentage(), System.Environment.NewLine);
        }

        public float CurrentAmountOfEnergy
        {
            get
            {
                return m_CurrentAmountOfEnergy;
            }
        }

        public float MaxEnergyCapacity
        {
            get
            {
                return r_MaxEnergyCapacity;
            }
        }

        public static string GetDetail(eDetails detail)
        {
            return sr_EnergyDetails[(int)detail];
        }

        public virtual bool UpdateDetail(KeyValuePair<string, string> i_DetailToFill)
        {
            bool isDetailFound = false;

            if (i_DetailToFill.Key == sr_EnergyDetails[(int)eDetails.CurrentAmountOfEnergy])
            {
                isDetailFound = true;
                convertAndSetCurrentAmountOfEnergy(i_DetailToFill.Value);
            }

            return isDetailFound;
        }

        private void convertAndSetCurrentAmountOfEnergy(string i_CurrentAmountOfEnergy)
        {
            bool isParseSuccssed = false;
            float convertedEnergy;

            isParseSuccssed = float.TryParse(i_CurrentAmountOfEnergy, out convertedEnergy);
            if (!isParseSuccssed)
            {
                throw new FormatException("Error: Faild to parse from string to current Amount Of Energy");
            }

            FillEnergy(convertedEnergy);
        }
    }
}
