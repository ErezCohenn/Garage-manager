using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eDetails
    {
        ModelName,
    }

    public abstract class Vehicle
    {
        private static readonly int sr_LicenseNumberLength;
        private static readonly Dictionary<string, string> sr_VehicleDetails;
        private readonly string r_LicenseNumber;
        private readonly EnergySource r_EnergySoucre;
        private string m_ModelName;
        private List<Wheel> m_VehicleWheels;

        static Vehicle()
        {
            Dictionary<string, string> vehicleDetails = new Dictionary<string, string>();

            vehicleDetails.Add(Enum.GetName(typeof(eDetails), eDetails.ModelName), getModelNameMessage());
            sr_VehicleDetails = vehicleDetails;
            sr_LicenseNumberLength = 7;
        }

        public Vehicle(EnergySource i_EnergySource, string i_LicenseNumber, int i_NumberOfVehicleWheels, float i_MaximumAirPressure)
        {
            if (i_EnergySource == null)
            {
                throw new NullReferenceException("Error: Failed to create energy source!");
            }

            m_ModelName = null;
            r_EnergySoucre = i_EnergySource;
            r_LicenseNumber = i_LicenseNumber;
            m_VehicleWheels = new List<Wheel>(i_NumberOfVehicleWheels);
            initilaizeVehicleWheels(i_MaximumAirPressure);
        }

        private static string getModelNameMessage()
        {
            return "Please enter the model name of the vehicle:";
        }
        private void initilaizeVehicleWheels(float i_MaximumAirPressure)
        {
            for (int i = 0; i < m_VehicleWheels.Capacity; i++)
            {
                m_VehicleWheels.Add(new Wheel(i_MaximumAirPressure, 0));
            }
        }

        public virtual Dictionary<string, string> GetVehicleDetails()
        {
            Dictionary<string, string> deatilsToFill = null;

            if (m_VehicleWheels.Count == 0)
            {
                throw new ArgumentException("Error: The vehicle has no wheels!");
            }

            if (r_EnergySoucre == null)
            {
                throw new ArgumentException("Error: The vehicle has no energy source!");
            }

            deatilsToFill = Utiles.ConcatDictionaries(r_EnergySoucre.GetDetails(), m_VehicleWheels[0].GetDetails());
            deatilsToFill = Utiles.ConcatDictionaries(deatilsToFill, sr_VehicleDetails);

            return deatilsToFill;
        }

        public virtual bool UpdateDetail(KeyValuePair<string, string> i_DetailToFill)
        {
            bool isDetailFound = false;

            if (i_DetailToFill.Key == Enum.GetName(typeof(eDetails), eDetails.ModelName))
            {
                isDetailFound = true;
                if (string.Empty == i_DetailToFill.Value)
                {
                    throw new FormatException("Error: Invalid input inserted! please try again.");
                }

                m_ModelName = i_DetailToFill.Value;
            }
            else
            {
                isDetailFound = r_EnergySoucre.UpdateDetail(i_DetailToFill);
                if (!isDetailFound)
                {
                    foreach (Wheel wheel in m_VehicleWheels)
                    {
                        isDetailFound = wheel.UpdateDetail(i_DetailToFill);
                        if (!isDetailFound)
                        {
                            break;
                        }
                    }
                }
            }

            return isDetailFound;
        }

        public override string ToString()
        {
            StringBuilder vehicleToString = new StringBuilder();
            int wheelNumber = 1;

            foreach (Wheel wheel in m_VehicleWheels)
            {
                vehicleToString.Append(string.Format("Wheel {0}: ", wheelNumber));
                vehicleToString.Append(wheel.ToString());
                wheelNumber++;
            }

            vehicleToString.Append(r_EnergySoucre.ToString());
            vehicleToString.Append(string.Format("Vehicel Model Name: {0}{1}License Number: {2}{3}", m_ModelName, Environment.NewLine, r_LicenseNumber, Environment.NewLine));

            return vehicleToString.ToString();
        }

        public float SetMaxAirPressureForTheWheels()
        {
            if (m_VehicleWheels.Count == 0)
            {
                throw new ArgumentException("Error: There are no wheels to the vehicle");
            }

            return m_VehicleWheels[0].MaxAirPressure;
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public List<Wheel> VehicleWheels
        {
            get
            {
                return m_VehicleWheels;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return r_EnergySoucre;
            }
        }

        public static int LicenseNumberLength
        {
            get
            {
                return sr_LicenseNumberLength;
            }
        }
    }
}
