using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        // Should be properties?
        protected readonly string m_ModelName;
        private readonly string   r_LicensePlateNum;
        protected float           m_EnergyLeftPercentage;
        protected List<Wheel>     m_Wheels;

        public Vehicle(string i_ModelName,string i_LicensePlateNum,  float i_EnergyLeftPercentage, List<Wheel> i_Wheels)
        {

        }
        internal string LicensePlateNum
        {
            get
            {
                return licensePlateNum;
            }
        }
    }
}