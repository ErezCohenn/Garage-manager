namespace Ex03.GarageLogic
{
    public class ElectricEnergy : EnergySource
    {
        public ElectricEnergy(float i_MaximumBatteryTimeInHours) : base(i_MaximumBatteryTimeInHours) { }

        public void ChargeBattery(float i_HoursToCharge)
        {
            base.FillEnergy(i_HoursToCharge);
        }
    }
}
