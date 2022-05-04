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

        private static readonly Dictionary<string, string> sr_EnergyDetails;
        private readonly float r_MaxEnergyCapacity;
        private float m_CurrentAmountOfEnergy;

        static EnergySource()
        {
            Dictionary<string, string> energyDetails = new Dictionary<string, string>();

            energyDetails.Add(Enum.GetName(typeof(eDetails), eDetails.CurrentAmountOfEnergy), getCurrentAmountOfEnergyMessage());
            sr_EnergyDetails = energyDetails;
        }

        public EnergySource(float i_MaxEnergy, float i_CurrentAmountOfEnergy)
        {
            r_MaxEnergyCapacity = i_MaxEnergy;
            m_CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
        }

        private static string getCurrentAmountOfEnergyMessage()
        {
            return "Please enter the current amount of energy in your vehicle:";
        }

        public virtual Dictionary<string, string> GetDetails()
        {
            return sr_EnergyDetails;
        }

        protected void FillEnergy(float i_AmountOfEnergyToLoad)
        {
            if (i_AmountOfEnergyToLoad + m_CurrentAmountOfEnergy > MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(r_MaxEnergyCapacity - m_CurrentAmountOfEnergy, 0, "Energy amount to add");
            }

            m_CurrentAmountOfEnergy += i_AmountOfEnergyToLoad;
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
            float convertedEnergy;

            if (i_DetailToFill.Key == Enum.GetName(typeof(eDetails), eDetails.CurrentAmountOfEnergy))
            {
                isDetailFound = true;
                Utiles.ConvertAndSetFromStringToType<float>(i_DetailToFill.Value, out convertedEnergy, float.TryParse);
                FillEnergy(convertedEnergy);
            }

            return isDetailFound;
        }
    }
}
