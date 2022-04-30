using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private readonly float r_modelName;
        private readonly string r_licenseNumber;
        private float m_energyPercentageLeft;
        private List<Wheel> m_vehicleWheels;
    }
}
