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
        private static readonly string[] sr_TruckDetails = { "CargoCapcity", "CanCarryRefrigerated" };

        public Truck(EnergySource i_EnergySource, string i_LicenseNumber) : base(i_EnergySource, i_LicenseNumber, sr_NumberOfWheel, WheelConstatns.k_MaxAirPressure)
        {
            m_CargoCapcity = 50;
            m_CanCarryRefrigerated = true;
        }
        public override Dictionary<string, string> GetVehicleDetails()
        {
            Dictionary<string, string> deatilsToFill = base.GetVehicleDetails();


            foreach (string detail in sr_TruckDetails)
            {
                deatilsToFill.Add(detail, string.Empty);
            }

            return deatilsToFill;
        }

        public override bool UpdateDetail(KeyValuePair<string, string> i_DetailToFill)
        {
            bool isDetailFound = false;

            if (i_DetailToFill.Key == sr_TruckDetails[(int)eDetails.CanCarryRefrigerated])
            {
                isDetailFound = true;
                convertAndSetCanCarryRefrigerated(i_DetailToFill.Value);

            }
            else if (i_DetailToFill.Key == sr_TruckDetails[(int)eDetails.CargoCapcity])
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
                throw new FormatException("Error: Faild to parse from string to Cargo Capcity");
            }

            m_CargoCapcity = convertedCargoCapcity;
        }

        private void convertAndSetCanCarryRefrigerated(string i_CanCarryRefrigerated)
        {
            bool convertedCanCarryRefrigerated;
            bool isParseSuccssed = bool.TryParse(i_CanCarryRefrigerated, out convertedCanCarryRefrigerated);

            if (!isParseSuccssed)
            {
                throw new FormatException("Error: Faild to parse from string to Carry Refrigerated");
            }

            m_CanCarryRefrigerated = convertedCanCarryRefrigerated;
        }

        public override string ToString()
        {
            string canCarryRefrigeratedString = m_CanCarryRefrigerated == true ? "Yes" : "No";
            string truckToString = string.Format("Truck Cargo Capcit: {0}{1}m_CanCarryRefrigerated: {2}{3}", m_CargoCapcity, Environment.NewLine, canCarryRefrigeratedString, Environment.NewLine);

            return string.Concat(base.ToString(), truckToString);
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

        public static string GetDetail(eDetails detail)
        {
            return sr_TruckDetails[(int)detail];
        }
    }
}
