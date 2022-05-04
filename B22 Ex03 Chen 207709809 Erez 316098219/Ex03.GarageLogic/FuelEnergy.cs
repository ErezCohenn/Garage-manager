using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelEnergy : EnergySource
    {
        public enum eType
        {
            Octan98 = 1,
            Octan96 = 2,
            Octan95 = 3,
            Soler = 4,
        }

        private static readonly List<string> sr_FuelTypes = new List<string>() { "Octan98", "Octan96", "Octan95", "Soler" };
        private readonly eType r_FuelType;

        public FuelEnergy(float i_MaximumAmountOfFuelInLiters, eType i_FuelType, float i_CurrentFuelLeftInLiters = 0) : base(i_MaximumAmountOfFuelInLiters, i_CurrentFuelLeftInLiters)
        {
            r_FuelType = i_FuelType;
        }

        public void ReFuel(float i_AmountFuelInLitersToAdd, eType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException("Error: Invalid FuelType was inserted");
            }

            FillEnergy(i_AmountFuelInLitersToAdd);
        }

        public override string ToString()
        {
            return string.Concat(base.ToString(), string.Format("Fuel Type: {0}{1}.", r_FuelType, Environment.NewLine));
        }

        public eType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public static List<string> FuelTypes
        {
            get
            {
                return sr_FuelTypes;
            }
        }
    }
}
