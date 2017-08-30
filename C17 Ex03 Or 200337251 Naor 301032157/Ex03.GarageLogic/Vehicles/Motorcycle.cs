using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        internal Motorcycle()
        {

        }
        eMotorcylceLicenseType m_LicenseType;
        int m_EngineVolume; // m_EngineCapacity??
    }
}