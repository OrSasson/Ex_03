using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        private readonly string m_modelName;
        private readonly string m_LicensePlateNum;
        private float m_EnergyLeftPercentage;
        private List<Wheel> m_Wheels;
    }
}


abstract class Engine
{

}

class ElectricEngine : Engine
{

}
class FuleEngine : Engine
{

}