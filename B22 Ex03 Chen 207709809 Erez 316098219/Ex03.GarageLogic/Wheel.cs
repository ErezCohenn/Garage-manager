using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public enum eDetails
        {
            ManufacturerName,
            CurrentAirPressure,
        }

        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressureByManufacturer;
        private static readonly Dictionary<string, string> sr_WheelDetails;//{ "Manufacturer wheel Name", "Current Air Pressure of the wheel" };

        static Wheel()
        {
            Dictionary<string, string> wheelDetails = new Dictionary<string, string>();

            wheelDetails.Add(Enum.GetName(typeof(eDetails), eDetails.CurrentAirPressure), getCurrentAirPressureMessage());
            wheelDetails.Add(Enum.GetName(typeof(eDetails), eDetails.ManufacturerName), getManufacturerNameMessage());
            sr_WheelDetails = wheelDetails;
        }

        private static string getManufacturerNameMessage()
        {
            return "Please enter the manufacturer name of the wheels:";
        }

        private static string getCurrentAirPressureMessage()
        {
            return "Please enter the current air pressure in the wheels:";
        }

        public Wheel(float i_MaxAirPressureByManufacturer, float i_CurrentAirPressure)
        {
            m_ManufacturerName = null;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;
        }

        public virtual Dictionary<string, string> GetDetails()
        {
            return sr_WheelDetails;
        }

        public void WheelInflation(float i_AmountAirToAdd)
        {
            if (m_CurrentAirPressure + i_AmountAirToAdd > r_MaxAirPressureByManufacturer)
            {
                throw new ValueOutOfRangeException(r_MaxAirPressureByManufacturer - m_CurrentAirPressure, 0, "Air Pressure amount");
            }

            m_CurrentAirPressure += i_AmountAirToAdd;
        }

        public float AirPressureLeftInPercentage()
        {
            return (m_CurrentAirPressure / r_MaxAirPressureByManufacturer) * 100;
        }

        public bool UpdateDetail(KeyValuePair<string, string> i_DetailToFill)
        {
            bool isDetailFound = false;

            if (i_DetailToFill.Key == Enum.GetName(typeof(eDetails), eDetails.CurrentAirPressure))
            {
                isDetailFound = true;
                convertAndSetCurrentAirPressure(i_DetailToFill.Value);
            }
            else if (i_DetailToFill.Key == Enum.GetName(typeof(eDetails), eDetails.ManufacturerName))
            {
                isDetailFound = true;
                m_ManufacturerName = i_DetailToFill.Value;
            }

            return isDetailFound;
        }

        private void convertAndSetCurrentAirPressure(string i_CurrentAirPressure)
        {
            bool isParseSuccssed = false;
            float convertedAirPressure;

            isParseSuccssed = float.TryParse(i_CurrentAirPressure, out convertedAirPressure);

            if (!isParseSuccssed)
            {
                throw new FormatException("Error: Faild to parse from string to current Air Pressure");
            }

            WheelInflation(convertedAirPressure);

        }

        public override string ToString()
        {
            return string.Format("Manufacturer wheel Name: {0}{1}Wheel state in percent: {2}%{3}", m_ManufacturerName, Environment.NewLine, AirPressureLeftInPercentage(), Environment.NewLine);
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
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
