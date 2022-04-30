namespace Ex03.GarageLogic
{
    public class FuelEnergy : EnergySource
    {
        public enum eType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler,
        }

        private readonly eType r_FuelType;
        public FuelEnergy(eType i_FuelType, float i_AmountOfFuelInLiters, float i_MaximumAmountOfFuelInLiters) : base(i_AmountOfFuelInLiters, i_MaximumAmountOfFuelInLiters)
        {
            r_FuelType = i_FuelType;
        }

        public void ReFuel(float i_AmountFuelInLitersToAdd, eType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                // throw exception
            }

            base.LoadEnergy(i_AmountFuelInLitersToAdd);
        }

        public eType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }
    }
}
