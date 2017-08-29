using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        // Should be properties?
        protected readonly string m_ModelName;
        private readonly string licensePlateNum;
        protected float m_EnergyLeftPercentage;
        protected List<Wheel> m_Wheels;

        internal string LicensePlateNum
        {
            get
            {
                return licensePlateNum;
            }
        }
    }
}