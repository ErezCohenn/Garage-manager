namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly float r_CargoCapcity;
        private readonly bool r_CanCarryRefrigerated;

        public Truck(float i_CargoVolume, bool i_CanCarryRefrigerated, float i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft, int i_NumberOfVehicleWheels) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageLeft, i_NumberOfVehicleWheels)
        {
            r_CargoCapcity = i_CargoVolume;
            r_CanCarryRefrigerated = i_CanCarryRefrigerated;
        }

        public float CargoCapcity
        {
            get
            {
                return r_CargoCapcity;
            }
        }
        public bool CanCarryRefrigerated
        {
            get
            {
                return r_CanCarryRefrigerated;
            }
        }
    }
}
