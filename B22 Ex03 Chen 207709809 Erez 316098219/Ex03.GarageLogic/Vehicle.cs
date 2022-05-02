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
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private readonly List<Wheel> r_VehicleWheels;
        private readonly EnergySource r_EnergySoucre;

        private static readonly int sr_LicenseNumberLength = 7;
        private static readonly string[] sr_VehicleDeatials = { "LicenseNumber", "ModelName" };



        public Vehicle(EnergySource i_EnergySource, string i_LicenseNumber, int i_NumberOfVehicleWheels, float i_MaximumAirPressure)
        {
            r_ModelName = null;
            r_EnergySoucre = i_EnergySource;
            r_LicenseNumber = i_LicenseNumber;
            r_VehicleWheels = new List<Wheel>(i_NumberOfVehicleWheels);
            initilaizeVehicleWheels(i_MaximumAirPressure);
        }

        private void initilaizeVehicleWheels(float i_MaximumAirPressure)
        {
            for (int i = 0; i < r_VehicleWheels.Capacity; i++)
            {
                r_VehicleWheels[i] = new Wheel(i_MaximumAirPressure, 0);
            }
        }


        public virtual Dictionary<string, string> GetVehicleDetails()

        {
            Dictionary<string, string> deatilsToFill = concatDetails(r_EnergySoucre.GetDetails(), r_VehicleWheels[0].GetDetails());

            foreach (string detail in sr_VehicleDeatials)
            {
                deatilsToFill.Add(detail, string.Empty);
            }

            return deatilsToFill;
        }

        private Dictionary<string, string> concatDetails(Dictionary<string, string> firstDictionarySource, Dictionary<string, string> secondDictionarySource)
        {
            Dictionary<string, string> dictionaryDestantaion = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> details in firstDictionarySource)
            {
                dictionaryDestantaion.Add(details.Key, details.Value);
            }

            foreach (KeyValuePair<string, string> details in secondDictionarySource)
            {
                dictionaryDestantaion.Add(details.Key, details.Value);
            }

            return dictionaryDestantaion;
        }

        public override string ToString()
        {
            StringBuilder vehicleToString = new StringBuilder();
            int wheelNumber = 1;

            foreach (Wheel wheel in r_VehicleWheels)
            {
                vehicleToString.Append(string.Format("Wheel {0}: ", wheelNumber));
                vehicleToString.Append(wheel.ToString());
                wheelNumber++;
            }

            vehicleToString.Append(r_EnergySoucre.ToString());
            vehicleToString.Append(string.Format("Vehicel Model Name: {0}{1}License Number: {2}{3}", r_ModelName, Environment.NewLine, r_LicenseNumber, Environment.NewLine));

            return vehicleToString.ToString();

        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
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
                return r_VehicleWheels;
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
