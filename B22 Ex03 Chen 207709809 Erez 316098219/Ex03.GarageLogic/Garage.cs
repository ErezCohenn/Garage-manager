using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum eVehicleStatus
        {
            Repair,
            Fixed,
            PaidUp,
        }

        private readonly Dictionary<string, Client> m_VehiclesInGarage;

        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, Client>();
        }
    }
}
