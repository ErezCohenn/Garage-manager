namespace Ex03.GarageLogic
{
    public class ElectricEnergy : Energy
    {
        public ElectricEnergy(float i_AmountBatteryTimeInHours, float i_MaximumBatteryTimeInHours) : base(i_AmountBatteryTimeInHours, i_MaximumBatteryTimeInHours) { }

        public void ChargeBattery(float i_HoursToCharge)
        {
            if (i_HoursToCharge + CurrentAmountOfEnergy > MaxEnergy)
            {
                // throw exception
            }

            CurrentAmountOfEnergy += i_HoursToCharge;
        }
    }
}
