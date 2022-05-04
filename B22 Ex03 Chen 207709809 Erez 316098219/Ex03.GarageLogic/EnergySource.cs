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
        private static readonly Dictionary<string, string> sr_EnergyDetails;

        static EnergySource()
        {
            Dictionary<string, string> energyDetails = new Dictionary<string, string>();

            energyDetails.Add(Enum.GetName(typeof(eDetails), eDetails.CurrentAmountOfEnergy), getCurrentAmountOfEnergyMessage());
            sr_EnergyDetails = energyDetails;
        }

        private static string getCurrentAmountOfEnergyMessage()
        {
            return "Please enter the current amount of energy in your vehicle:";
        }

        public EnergySource(float i_MaxEnergy, float i_CurrentAmountOfEnergy)
        {
            r_MaxEnergyCapacity = i_MaxEnergy;
            m_CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
        }

        public virtual Dictionary<string, string> GetDetails()
        {
            return sr_EnergyDetails;
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
            return string.Format("Fuel state in percent: {0}%{1}", EnergyLeftInPercentage(), System.Environment.NewLine);
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

        public virtual bool UpdateDetail(KeyValuePair<string, string> i_DetailToFill)
        {
            bool isDetailFound = false;

            if (i_DetailToFill.Key == Enum.GetName(typeof(eDetails), eDetails.CurrentAmountOfEnergy))
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
                throw new FormatException("Error: Invalid input of Energy inserted! please try again.");
            }

            FillEnergy(convertedEnergy);
        }
    }
}
