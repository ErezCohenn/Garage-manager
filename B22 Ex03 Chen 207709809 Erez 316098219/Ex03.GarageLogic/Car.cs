using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        internal static class FuelConstatns
        {
            internal const FuelEnergy.eType k_FuelType = FuelEnergy.eType.Octan95;
            internal const float k_MaxTankFuelCapacityInLiters = 38;
        }

        internal static class ElectricConstatns
        {
            internal const float k_MaxBattaryCapacityInHours = 3.3f;
        }

        internal static class WheelConstatns
        {
            internal const float k_MaxAirPressure = 29;
            internal static readonly int sr_NumberOfWheel = 4;
        }

        public enum eColors
        {
            Red,
            White,
            Green,
            Blue,
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
        }

        public enum eDetails
        {
            Color,
            NumberOfDoors,
        }

        private eColors m_Color;
        private eNumberOfDoors m_NumberOfDoors;
        private static readonly string[] sr_CarDetails;

        static Car()
        {
            StringBuilder details = new StringBuilder();
            string[] colors = Enum.GetNames(typeof(eColors));
            string[] numOfDoors = Enum.GetNames(typeof(eNumberOfDoors));
            string[] carDetails = new string[2];

            details.Append("Color (");
            foreach (string color in colors)
            {
                details.Append(color + "/");
            }

            details.Append(")");
            carDetails[0] = details.ToString();
            details.Clear();
            details.Append("Doors (");
            foreach (string amountOfDoors in numOfDoors)
            {
                details.Append(amountOfDoors + "/");
            }

            details.Append(")");
            carDetails[1] = details.ToString();
            sr_CarDetails = carDetails;
        }
        public Car(EnergySource i_EnergySource, string i_LicenseNumber) : base(i_EnergySource, i_LicenseNumber, WheelConstatns.sr_NumberOfWheel, WheelConstatns.k_MaxAirPressure)
        {
            m_Color = eColors.White;
            m_NumberOfDoors = eNumberOfDoors.Four;
        }

        public override Dictionary<string, string> GetVehicleDetails()
        {
            Dictionary<string, string> deatilsToFill = base.GetVehicleDetails();

            foreach (string detail in sr_CarDetails)
            {
                deatilsToFill.Add(detail, string.Empty);
            }

            return deatilsToFill;
        }

        public override bool UpdateDetail(KeyValuePair<string, string> i_DetailToFill)
        {
            bool isDetailFound = false;

            if (i_DetailToFill.Key == sr_CarDetails[(int)eDetails.Color])
            {
                isDetailFound = true;
                convertAndSetColor(i_DetailToFill.Value);

            }
            else if (i_DetailToFill.Key == sr_CarDetails[(int)eDetails.NumberOfDoors])
            {
                isDetailFound = true;
                convertAndSetNumberOfDoors(i_DetailToFill.Value);
            }
            else
            {
                isDetailFound = base.UpdateDetail(i_DetailToFill);
            }

            return isDetailFound;
        }

        private void convertAndSetNumberOfDoors(string i_NumberOfDoors)
        {
            eNumberOfDoors convertedNumberOfDoors;
            bool isParseSuccssed = Enum.TryParse(i_NumberOfDoors, out convertedNumberOfDoors);

            if (!isParseSuccssed)
            {
                throw new FormatException("Error: Faild to parse from string to Number of doors");
            }

            m_NumberOfDoors = convertedNumberOfDoors;
        }

        private void convertAndSetColor(string i_Color)
        {
            eColors convertedColor;
            bool isParseSuccssed = Enum.TryParse(i_Color, out convertedColor);

            if (!isParseSuccssed)
            {
                throw new FormatException("Error: Faild to parse from string to Color");
            }

            m_Color = convertedColor;
        }

        public override string ToString()
        {
            StringBuilder carToString = new StringBuilder(string.Format("Car color: {0}{1}Number Of Doors: {2}{3}", m_Color, Environment.NewLine, m_NumberOfDoors, Environment.NewLine));

            return carToString.Append(base.ToString()).ToString();
        }

        public eColors CarColors
        {
            get
            {
                return m_Color;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
        }

        public static string GetDetail(eDetails detail)
        {
            return sr_CarDetails[(int)detail];
        }
    }
}
