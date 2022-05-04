using System;
using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    class Tractor : Vehicle
    {
        internal static class FuelConstatns
        {
            internal const FuelEnergy.eType k_FuelType = FuelEnergy.eType.Soler;
            internal const float k_MaxTankFuelCapacityInLiters = 140;
        }

        internal static class WheelConstatns
        {
            internal const float k_MaxAirPressure = 32;
            internal static readonly int sr_NumberOfWheel = 4;
        }
        public enum eDetails
        {
            MaxCarringWeight,
            NumberOfGears,
        }


        private float m_MaxCarringWeight;
        private int m_NumberOfGears;
        private static readonly int sr_NumberOfWheel = 4;
        private static readonly string[] sr_TractorDetails = { "Max carring weight", "Number of gears" };

        public Tractor(EnergySource i_EnergySource, string i_LicenseNumber) : base(i_EnergySource, i_LicenseNumber, sr_NumberOfWheel, WheelConstatns.k_MaxAirPressure)
        {
            m_MaxCarringWeight = 90;
            m_NumberOfGears = 12;
        }
        public override Dictionary<string, string> GetVehicleDetails()
        {
            Dictionary<string, string> deatilsToFill = base.GetVehicleDetails();


            foreach (string detail in sr_TractorDetails)
            {
                deatilsToFill.Add(detail, string.Empty);
            }

            return deatilsToFill;
        }

        public override bool UpdateDetail(KeyValuePair<string, string> i_DetailToFill)
        {
            bool isDetailFound = false;

            if (i_DetailToFill.Key == sr_TractorDetails[(int)eDetails.MaxCarringWeight])
            {
                isDetailFound = true;
                convertAndSetNumberOfGears(i_DetailToFill.Value);

            }
            else if (i_DetailToFill.Key == sr_TractorDetails[(int)eDetails.NumberOfGears])
            {
                isDetailFound = true;
                convertAndSetMaxCarringWeight(i_DetailToFill.Value);
            }
            else
            {
                isDetailFound = base.UpdateDetail(i_DetailToFill);
            }

            return isDetailFound;
        }

        private void convertAndSetMaxCarringWeight(string i_MaxCarringWeight)
        {
            float convertedMaxCarringWeight;
            bool isParseSuccssed = float.TryParse(i_MaxCarringWeight, out convertedMaxCarringWeight);

            if (!isParseSuccssed)
            {
                throw new FormatException("Error: Faild to parse from string to Max Carring Weight.");
            }

            m_MaxCarringWeight = convertedMaxCarringWeight;
        }

        private void convertAndSetNumberOfGears(string i_NumberOfGears)
        {
            int convertedNumberOfGears;
            bool isParseSuccssed = int.TryParse(i_NumberOfGears, out convertedNumberOfGears);

            if (!isParseSuccssed)
            {
                throw new FormatException("Error: Faild to parse from string to Number Of Gears.");
            }

            m_NumberOfGears = convertedNumberOfGears;
        }

        public override string ToString()
        {
            string truckToString = string.Format("Tractor max carring weight: {0}{1}Tractor number of gears: {2}{3}", m_MaxCarringWeight, Environment.NewLine, m_NumberOfGears, Environment.NewLine);

            return string.Concat(base.ToString(), truckToString);
        }

        public int NumberOfGears
        {
            get
            {
                return m_NumberOfGears;
            }
        }
        public float MaxCarringWeight
        {
            get
            {
                return m_MaxCarringWeight;
            }
        }

        public static int NumberOfWheels
        {
            get
            {
                return sr_NumberOfWheel;
            }
        }

        public static string GetDetail(eDetails detail)
        {
            return sr_TractorDetails[(int)detail];
        }
    }
}
