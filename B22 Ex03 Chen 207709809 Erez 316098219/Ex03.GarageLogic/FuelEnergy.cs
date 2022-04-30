using System.Collections.Generic;

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

        public new enum eDetails
        {
            FuelType,
        }

        private readonly eType r_FuelType;
        private static readonly string[] sr_FuelEnergyDetails = { "FuelType" };

        public FuelEnergy(float i_MaximumAmountOfFuelInLiters, eType i_FuelType) : base(i_MaximumAmountOfFuelInLiters)
        {
            r_FuelType = i_FuelType;
        }

        public override Dictionary<string, string> GetEnergyDetails()
        {
            Dictionary<string, string> deatilsToFill = base.GetEnergyDetails();

            deatilsToFill.Add(sr_FuelEnergyDetails[(int)eDetails.FuelType], string.Empty);

            return deatilsToFill;
        }

        public void ReFuel(float i_AmountFuelInLitersToAdd, eType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                // throw exception
            }

            base.FillEnergy(i_AmountFuelInLitersToAdd);
        }

        public override string ToString()
        {
            return string.Concat(base.ToString(), string.Format("Fuel Type: {0}{1}", r_FuelType, System.Environment.NewLine));
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
