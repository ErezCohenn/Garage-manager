namespace Ex03.GarageLogic
{
    public class ElectricEnergy : EnergySource
    {
        public ElectricEnergy(float i_MaximumBatteryTimeInHours, float i_CurrentBatteryHoursLeft) : base(i_MaximumBatteryTimeInHours, i_CurrentBatteryHoursLeft) { }

        public void ChargeBattery(float i_HoursToCharge)
        {
            base.FillEnergy(i_HoursToCharge);
        }
    }
}
