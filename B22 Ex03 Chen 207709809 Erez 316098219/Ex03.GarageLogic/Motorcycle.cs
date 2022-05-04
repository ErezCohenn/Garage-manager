using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        internal static class FuelConstatns
        {
            internal const FuelEnergy.eType k_FuelType = FuelEnergy.eType.Octan98;
            internal const float k_MaxTankFuelCapacityInLiters = 6.2f;
        }

        internal static class ElectricConstatns
        {
            internal const float k_MaxBattaryCapacityInHours = 2.5f;
        }

        internal static class WheelConstatns
        {
            internal const float k_MaxAirPressure = 31;
            internal static readonly int sr_NumberOfWheel = 2;
        }

        public enum eLicenseType
        {
            A,
            A1,
            B1,
            BB,
        }

        public enum eDetails
        {
            LicenseType,
            EngineCapacity,
        }

        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;
        private static readonly Dictionary<string, string> sr_MotorcycleDetails;

        static Motorcycle()
        {
            Dictionary<string, string> motorcycleDetails = new Dictionary<string, string>();

            motorcycleDetails.Add(Enum.GetName(typeof(eDetails), eDetails.EngineCapacity), getEngineCapacityMessage());
            motorcycleDetails.Add(Enum.GetName(typeof(eDetails), eDetails.LicenseType), getLicenseTypeMessage());
            sr_MotorcycleDetails = motorcycleDetails;
        }

        private static string getLicenseTypeMessage()
        {
            string[] licenses = Enum.GetNames(typeof(eLicenseType));
            StringBuilder messageToClient = new StringBuilder();

            messageToClient.Append("Please enter one of the following license of the motorcycle:");
            messageToClient.Append(Environment.NewLine);
            foreach (string license in licenses)
            {
                messageToClient.Append(license);
                messageToClient.Append(Environment.NewLine);
            }

            return messageToClient.ToString();
        }

        private static string getEngineCapacityMessage()
        {
            return "Please enter the engine capacity of your motorcycle:";
        }

        public Motorcycle(EnergySource i_EnergySource, string i_LicenseNumber) : base(i_EnergySource, i_LicenseNumber, WheelConstatns.sr_NumberOfWheel, WheelConstatns.k_MaxAirPressure)
        {
            m_LicenseType = eLicenseType.A;
            m_EngineCapacity = 50;
        }


        public override Dictionary<string, string> GetVehicleDetails()
        {
            return Utiles.ConcatDictionaries(base.GetVehicleDetails(), sr_MotorcycleDetails);
        }

        public override bool UpdateDetail(KeyValuePair<string, string> i_DetailToFill)
        {
            bool isDetailFound = false;

            if (i_DetailToFill.Key == Enum.GetName(typeof(eDetails), eDetails.LicenseType))
            {
                isDetailFound = true;
                if (!Enum.IsDefined(typeof(eLicenseType), i_DetailToFill.Value))
                {
                    throw new FormatException("Error: Invalid input inserted! please try again.");
                }

                Utiles.ConvertAndSetFromStringToType<eLicenseType>(i_DetailToFill.Value, out m_LicenseType, Enum.TryParse<eLicenseType>);
            }
            else if (i_DetailToFill.Key == Enum.GetName(typeof(eDetails), eDetails.EngineCapacity))
            {
                isDetailFound = true;
                Utiles.ConvertAndSetFromStringToType<int>(i_DetailToFill.Value, out m_EngineCapacity, int.TryParse);
            }
            else
            {
                isDetailFound = base.UpdateDetail(i_DetailToFill);
            }

            return isDetailFound;
        }

        public override string ToString()
        {
            return string.Concat(base.ToString(), string.Format("MotorCycle License type: {0}{1}Engine Capacity: {2}{3}", m_LicenseType, Environment.NewLine, m_EngineCapacity, Environment.NewLine));
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }
        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }
    }
}
