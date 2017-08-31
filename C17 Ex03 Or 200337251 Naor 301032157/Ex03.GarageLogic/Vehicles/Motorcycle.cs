using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        // Please make sure consts are correct
        const float k_maximalAirPressure = 28f;
        const int k_numOfWheels = 2;

        internal Motorcycle(string i_ModelName, string i_LicenceNumber) 
            : base(i_ModelName, i_LicenceNumber, k_numOfWheels)
        {
           
        }

        internal override void SetWheels(string i_ManufacturerName)
        {
            for (int i = 0; i < k_numOfWheels; ++i)
            {
                Wheels.Add(new Wheel(i_ManufacturerName, 0, k_maximalAirPressure));
            }
        }

        eMotorcylceLicenseType m_LicenseType;
        int m_EngineVolume; // m_EngineCapacity??
    }
}