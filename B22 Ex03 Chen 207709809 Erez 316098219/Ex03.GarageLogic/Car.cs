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
        private static readonly Dictionary<string, string> sr_CarDetails;

        static Car()
        {
            Dictionary<string, string> carDetails = new Dictionary<string, string>();

            carDetails.Add(Enum.GetName(typeof(eDetails), eDetails.Color), getColorMessage());
            carDetails.Add(Enum.GetName(typeof(eDetails), eDetails.NumberOfDoors), getDoorsMessage());
            sr_CarDetails = carDetails;
        }

        private static string getDoorsMessage()
        {
            string[] doors = Enum.GetNames(typeof(eNumberOfDoors));
            StringBuilder messageToClient = new StringBuilder();

            messageToClient.Append("Please enter one of the following doors amount of the car:");
            messageToClient.Append(Environment.NewLine);
            foreach (string door in doors)
            {
                messageToClient.Append(door);
                messageToClient.Append(Environment.NewLine);
            }

            return messageToClient.ToString();
        }

        private static string getColorMessage()
        {
            string[] colors = Enum.GetNames(typeof(eColors));
            StringBuilder messageToClient = new StringBuilder();

            messageToClient.Append("Please enter one of the following colors of the car:");
            messageToClient.Append(Environment.NewLine);
            foreach (string color in colors)
            {
                messageToClient.Append(color);
                messageToClient.Append(Environment.NewLine);
            }

            return messageToClient.ToString();
        }

        public Car(EnergySource i_EnergySource, string i_LicenseNumber) : base(i_EnergySource, i_LicenseNumber, WheelConstatns.sr_NumberOfWheel, WheelConstatns.k_MaxAirPressure)
        {
            m_Color = eColors.White;
            m_NumberOfDoors = eNumberOfDoors.Four;
        }

        public override Dictionary<string, string> GetVehicleDetails()
        {
            return Utiles.ConcatDictionaries(base.GetVehicleDetails(), sr_CarDetails);
        }

        public override bool UpdateDetail(KeyValuePair<string, string> i_DetailToFill)
        {
            bool isDetailFound = false;

            if (i_DetailToFill.Key == Enum.GetName(typeof(eDetails), eDetails.Color))
            {
                isDetailFound = true;
                if (!Enum.IsDefined(typeof(eColors), i_DetailToFill.Value))
                {
                    throw new FormatException("Error: Invalid input inserted! please try again.");
                }

                Utiles.ConvertAndSetFromStringToType<eColors>(i_DetailToFill.Value, out m_Color, Enum.TryParse<eColors>);

            }
            else if (i_DetailToFill.Key == Enum.GetName(typeof(eDetails), eDetails.NumberOfDoors))
            {
                isDetailFound = true;
                if (!Enum.IsDefined(typeof(eNumberOfDoors), i_DetailToFill.Value))
                {
                    throw new FormatException("Error: Invalid input inserted! please try again.");
                }

                Utiles.ConvertAndSetFromStringToType<eNumberOfDoors>(i_DetailToFill.Value, out m_NumberOfDoors, Enum.TryParse<eNumberOfDoors>);
            }
            else
            {
                isDetailFound = base.UpdateDetail(i_DetailToFill);
            }

            return isDetailFound;
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
    }
}
