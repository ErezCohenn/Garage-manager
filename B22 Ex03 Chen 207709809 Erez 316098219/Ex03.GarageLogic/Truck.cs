using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        internal static class FuelConstatns
        {
            internal const FuelEnergy.eType k_FuelType = FuelEnergy.eType.Soler;
            internal const float k_MaxTankFuelCapacityInLiters = 120;
        }

        internal static class WheelConstatns
        {
            internal const float k_MaxAirPressure = 24;
            internal static readonly int sr_NumberOfWheel = 16;
        }

        public enum eDetails
        {
            CargoCapcity,
            CanCarryRefrigerated,
        }

        private float m_CargoCapcity;
        private bool m_CanCarryRefrigerated;
        private static readonly int sr_NumberOfWheel = 4;
        private static readonly Dictionary<string, string> sr_TruckDetails;//{ "Cargo Capcity", "if the truck can carry refrigerated (Yes/No)" };

        static Truck()
        {
            Dictionary<string, string> truckDetails = new Dictionary<string, string>();

            truckDetails.Add(Enum.GetName(typeof(eDetails), eDetails.CanCarryRefrigerated), getIfTruckCanCarryRefrigeratedMessage());
            truckDetails.Add(Enum.GetName(typeof(eDetails), eDetails.CargoCapcity), getCargoCapcityMessage());
            sr_TruckDetails = truckDetails;
        }

        private static string getCargoCapcityMessage()
        {
            return "Please enter the crago capacity of the truck):";
        }

        private static string getIfTruckCanCarryRefrigeratedMessage()
        {
            return "Please enter if the truck can carry refrigerated (Yes/ No):";
        }

        public Truck(EnergySource i_EnergySource, string i_LicenseNumber) : base(i_EnergySource, i_LicenseNumber, sr_NumberOfWheel, WheelConstatns.k_MaxAirPressure)
        {
            m_CargoCapcity = 50;
            m_CanCarryRefrigerated = true;
        }
        public override Dictionary<string, string> GetVehicleDetails()
        {
            return base.concatDetails(base.GetVehicleDetails(), sr_TruckDetails);
        }

        public override bool UpdateDetail(KeyValuePair<string, string> i_DetailToFill)
        {
            bool isDetailFound = false;

            if (i_DetailToFill.Key == Enum.GetName(typeof(eDetails), eDetails.CanCarryRefrigerated))
            {
                isDetailFound = true;
                convertAndSetCanCarryRefrigerated(i_DetailToFill.Value);

            }
            else if (i_DetailToFill.Key == Enum.GetName(typeof(eDetails), eDetails.CargoCapcity))
            {
                isDetailFound = true;
                convertAndSetCargoCapcity(i_DetailToFill.Value);
            }
            else
            {
                isDetailFound = base.UpdateDetail(i_DetailToFill);
            }

            return isDetailFound;
        }

        private void convertAndSetCargoCapcity(string i_CargoCapcity)
        {
            float convertedCargoCapcity;
            bool isParseSuccssed = float.TryParse(i_CargoCapcity, out convertedCargoCapcity);

            if (!isParseSuccssed)
            {
                throw new FormatException("Error: Invalid input of Cargo Capacity inserted! please try again");
            }

            m_CargoCapcity = convertedCargoCapcity;
        }

        private void convertAndSetCanCarryRefrigerated(string i_CanCarryRefrigerated)
        {
            bool validInput = i_CanCarryRefrigerated == "Yes" || i_CanCarryRefrigerated == "No";

            if (!validInput)
            {
                throw new FormatException("Error: Invalid input of Carry Refrigerated inserted! please try again");
            }

            m_CanCarryRefrigerated = i_CanCarryRefrigerated == "Yes" ? true : false;
        }

        public override string ToString()
        {
            string canCarryRefrigeratedString = m_CanCarryRefrigerated == true ? "Yes" : "No";

            return string.Concat(base.ToString(), string.Format("Truck Cargo Capacity: {0}{1}m_CanCarryRefrigerated: {2}{3}", m_CargoCapcity, Environment.NewLine, canCarryRefrigeratedString, Environment.NewLine));
        }

        public float CargoCapcity
        {
            get
            {
                return m_CargoCapcity;
            }
        }
        public bool CanCarryRefrigerated
        {
            get
            {
                return m_CanCarryRefrigerated;
            }
        }

        public static int NumberOfWheels
        {
            get
            {
                return sr_NumberOfWheel;
            }
        }
    }
}
