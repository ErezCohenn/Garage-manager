using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eCarColors
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

        private eCarColors m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;
        private static readonly int sr_NumberOfWheel = 4;
        private static readonly string[] sr_CarDetails = { "Color", "NumberOfDoors" };
        private const float k_MaximumAirPressure = 31;

        public Car(EnergySource i_EnergySource, string i_LicenseNumber) : base(i_EnergySource, i_LicenseNumber, sr_NumberOfWheel, k_MaximumAirPressure)
        {
            m_CarColor = eCarColors.White;
            m_NumberOfDoors = eNumberOfDoors.Four;
        }

        public override Dictionary<string, string> GetVehicleDeatials()
        {
            Dictionary<string, string> deatilsToFill = base.GetVehicleDeatials();

            deatilsToFill.Add(sr_CarDetails[(int)eDetails.Color], string.Empty);
            deatilsToFill.Add(sr_CarDetails[(int)eDetails.NumberOfDoors], string.Empty);

            return deatilsToFill;
        }

        public override string ToString()
        {
            return string.Concat(base.ToString(), string.Format("Car color: {0}{1} Number Of Doors: {2}{3}", m_CarColor, Environment.NewLine, m_NumberOfDoors, Environment.NewLine));
        }

        public eCarColors CarColors
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
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
