namespace Ex03.GarageLogic
{
    public class ElectricEnergy : EnergySource
    {
        public ElectricEnergy(float i_AmountBatteryTimeInHours, float i_MaximumBatteryTimeInHours) : base(i_AmountBatteryTimeInHours, i_MaximumBatteryTimeInHours) { }

        public void ChargeBattery(float i_HoursToCharge)
        {
            base.FillEnergy(i_HoursToCharge);
        }
    }
}
