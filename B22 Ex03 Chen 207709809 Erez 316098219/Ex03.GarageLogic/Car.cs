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

        private readonly eCarColors r_CarColor;
        private readonly int r_NumberOfDoors;

        public Car(eCarColors i_CarColor, int i_NumberOfDoors, float i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft, int i_NumberOfVehicleWheels) : base(i_ModelName, i_LicenseNumber, i_EnergyPercentageLeft, i_NumberOfVehicleWheels)
        {
            r_CarColor = i_CarColor;
            r_NumberOfDoors = i_NumberOfDoors;
        }
    }
}
