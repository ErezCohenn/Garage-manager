namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private float m_CargoCapcity;
        private bool m_CanCarryRefrigerated;

        public Truck(float i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft, int i_NumberOfVehicleWheels) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageLeft, i_NumberOfVehicleWheels) { }

        public float CargoCapcity
        {
            get
            {
                return m_CargoCapcity;
            }
            set
            {
                m_CargoCapcity = value;
            }
        }
        public bool CanCarryRefrigerated
        {
            get
            {
                return m_CanCarryRefrigerated;
            }
            set
            {
                m_CanCarryRefrigerated = value;
            }
        }
    }
}
