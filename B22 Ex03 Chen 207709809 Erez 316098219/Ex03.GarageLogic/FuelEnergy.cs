namespace Ex03.GarageLogic
{
    public class FuelEnergy : Energy
    {
        public enum eType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }

        private readonly eType r_FuelType;
        public FuelEnergy(eType i_FuelType, float i_AmountOfFuelInLiters, float i_MaxAmountOfFuelInLiters) : base(i_AmountOfFuelInLiters, i_MaxAmountOfFuelInLiters)
        {
            r_FuelType = i_FuelType;
        }

        public void ReFuel(float i_AmountFuelInLitersToLoad, eType i_FuelType)
        {
            if (i_AmountFuelInLitersToLoad + CurrentAmountOfEnergy > MaxEnergy)
            {
                // throw exception
            }

            if (i_FuelType != r_FuelType)
            {
                // throw exception
            }

            CurrentAmountOfEnergy += i_AmountFuelInLitersToLoad;
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
