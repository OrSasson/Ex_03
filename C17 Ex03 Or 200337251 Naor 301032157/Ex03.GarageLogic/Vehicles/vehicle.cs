using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        private readonly string m_ModelName; // $Naor - maybe change to m_Manufacturer ? 
        private readonly string m_LicensePlateNum;
        private float m_EnergyLeftPercentage;
        private List<Wheel> m_Wheels;
    }
}