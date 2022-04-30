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
                r_VehicleWheels[i] = new Wheel(i_MaximumAirPressure);
            }
        }

        public virtual Dictionary<string, string> GetVehicleDeatials()
        {
            Dictionary<string, string> deatilsToFill = new Dictionary<string, string>();

            deatilsToFill.Add(sr_VehicleDeatials[(int)eDetails.LicenseNumber], string.Empty);
            deatilsToFill.Add(sr_VehicleDeatials[(int)eDetails.ModelName], string.Empty);
            //concatDetails(deatilsToFill, concatDetails(r_EnergySoucre.GetEnergyDetails());

            return deatilsToFill;
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
