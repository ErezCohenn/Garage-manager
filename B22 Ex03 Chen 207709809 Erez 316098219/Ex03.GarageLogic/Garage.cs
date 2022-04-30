using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum eVehicleStatus
        {
            InRepair,
            Fixed,
            PaidUp,
        }

        private readonly Dictionary<string, Client> m_VehiclesInGarage;

        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, Client>();
        }

        public void AddVehicle(string i_LicenseNumber, VehicleGenerator.eVehicleType i_VehicleType, VehicleGenerator.eEnergyType i_EnergyType)
        {

        }

        public string GetLicenseNumbersByFilter(bool i_InRepairFilter, bool i_FixedFilter, bool i_PaidFilter)
        {
            StringBuilder licenseNumbers = new StringBuilder();
            int licenseIndex = 1;

            foreach (KeyValuePair<string, Client> cardVehicle in m_VehiclesInGarage)
            {
                if (i_InRepairFilter && cardVehicle.Value.VehicleStatus == eVehicleStatus.InRepair)
                {
                    licenseNumbers.Append(string.Format("{0}. {1}{2}", licenseIndex, cardVehicle.Key, Environment.NewLine));
                    licenseIndex++;
                }
                else if (i_FixedFilter && cardVehicle.Value.VehicleStatus == eVehicleStatus.Fixed)
                {
                    licenseNumbers.Append(string.Format("{0}. {1}{2}", licenseIndex, cardVehicle.Key, Environment.NewLine));
                    licenseIndex++;
                }
                else if (i_PaidFilter && cardVehicle.Value.VehicleStatus == eVehicleStatus.PaidUp)
                {
                    licenseNumbers.Append(string.Format("{0}. {1}{2}", licenseIndex, cardVehicle.Key, Environment.NewLine));
                    licenseIndex++;
                }
            }

            if (licenseNumbers.ToString().Equals(string.Empty))
            {
                throw new ArgumentException("Vehicle is not in the Garage!");
            }

            return licenseNumbers.ToString();
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            bool isVehicleExists = isExists(i_LicenseNumber);

            if (!isVehicleExists)
            {
                throw new ArgumentException("Vehicle is not in the Garage!");
            }
            else
            {
                m_VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_NewStatus;
            }
        }

        private bool isExists(string i_LicenseNumber)
        {
            return m_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public void InflateWheelsAirPressureToMaximum(string i_LicenseNumber)
        {
            bool isVehicleExists = isExists(i_LicenseNumber);
            List<Wheel> vehicleWheels = null;

            if (!isVehicleExists)
            {
                throw new ArgumentException("Vehicle is not in the Garage!");
            }
            else
            {
                vehicleWheels = m_VehiclesInGarage[i_LicenseNumber].Vehicle.VehicleWheels;

                foreach (Wheel wheel in vehicleWheels)
                {
                    wheel.CurrentAirPressure = wheel.MaxAirPressure;
                }
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, FuelEnergy.eType i_FuelType, float i_AmountFuelToAdd)
        {
            bool isVehicleExists = isExists(i_LicenseNumber);
            FuelEnergy energyToReFuel = null;

            if (!isVehicleExists)
            {
                throw new ArgumentException("Vehicle is not in the Garage!");
            }

            if (m_VehiclesInGarage[i_LicenseNumber].Vehicle.EnergySource is ElectricEnergy)
            {
                throw new ArgumentException("Vehicle is driven on Electricity!");
            }

            try
            {
                energyToReFuel = m_VehiclesInGarage[i_LicenseNumber].Vehicle.EnergySource as FuelEnergy;
                energyToReFuel.ReFuel(i_AmountFuelToAdd, i_FuelType);
            }
            catch
            {
                // todo
            }
        }

        public void ChargeElectronicVehicle(string i_LicenseNumber, float i_AmountHoursToCharge)
        {
            bool isVehicleExists = isExists(i_LicenseNumber);
            ElectricEnergy energyToReFuel = null;

            if (!isVehicleExists)
            {
                throw new ArgumentException("Vehicle is not in the Garage!");
            }

            if (m_VehiclesInGarage[i_LicenseNumber].Vehicle.EnergySource is FuelEnergy)
            {
                throw new ArgumentException("Vehicle is driven on Fuel!");
            }

            try
            {
                energyToReFuel = m_VehiclesInGarage[i_LicenseNumber].Vehicle.EnergySource as ElectricEnergy;
                energyToReFuel.ChargeBattery(i_AmountHoursToCharge);
            }
            catch
            {
                // todo
            }
        }

        public string GetVehicleInformation(string i_LicenseNumber)
        {
            bool isVehicleExists = isExists(i_LicenseNumber);

            if (!isVehicleExists)
            {
                throw new ArgumentException("Vehicle is not in the Garage!");
            }
            else
            {
                return m_VehiclesInGarage[i_LicenseNumber].ToString();
            }

        }
    }
}
