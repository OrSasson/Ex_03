using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        // Please make sure consts are correct
        const float k_MaxAirPressure = 28f;
        const int k_numOfWheels = 2;
        eMotorcylceLicenseType m_LicenseType;
        int m_EngineVolume; // m_EngineCapacity??

        internal Motorcycle(string i_ModelName, string i_LicenceNumber) 
            : base(i_ModelName, i_LicenceNumber, k_numOfWheels)
        {
           
        }

        internal override float getMaxAirPressure()
        {
            return k_MaxAirPressure;
        }

      
    }
}