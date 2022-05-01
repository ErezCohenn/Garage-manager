using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eDetails
    {
        LicenseNumber,
        ModelName,
    }

    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private readonly List<Wheel> r_VehicleWheels;
        private readonly EnergySource r_EnergySoucre;
        private static readonly string[] sr_VehicleDeatials = { "LicenseNumber", "ModelName" };

        public Vehicle(EnergySource i_EnergySource, string i_LicenseNumber, int i_NumberOfVehicleWheels, float i_MaximumAirPressure, float i_CurrentAirPressure)
        {
            r_ModelName = null;
            r_EnergySoucre = i_EnergySource;
            r_LicenseNumber = i_LicenseNumber;
            r_VehicleWheels = new List<Wheel>(i_NumberOfVehicleWheels);
            initilaizeVehicleWheels(i_MaximumAirPressure, i_CurrentAirPressure);
        }

        private void initilaizeVehicleWheels(float i_MaximumAirPressure, float i_CurrentAirPressure)
        {
            for (int i = 0; i < r_VehicleWheels.Capacity; i++)
            {
                r_VehicleWheels[i] = new Wheel(i_MaximumAirPressure, i_CurrentAirPressure);
            }
        }

        public virtual Dictionary<string, string> GetVehicleDeatials()
        {
            Dictionary<string, string> deatilsToFill = concatDetails(r_EnergySoucre.GetDetails(), r_VehicleWheels[0].GetDetails());

            deatilsToFill.Add(sr_VehicleDeatials[(int)eDetails.LicenseNumber], string.Empty);
            deatilsToFill.Add(sr_VehicleDeatials[(int)eDetails.ModelName], string.Empty);

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
            return string.Concat(r_EnergySoucre.ToString(), r_VehicleWheels[0].ToString(), string.Format("Vehicel Model Name: {0}{1} License Number: {2}{3}", r_ModelName, Environment.NewLine, r_LicenseNumber, Environment.NewLine));
        }

        public override int GetHashCode()
        {
            return r_LicenseNumber.GetHashCode();
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
    }
}
