using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        // Should be properties?

        //Guy defined
        protected readonly string m_ModelName;
        private readonly string r_LicensePlateNum;
        protected readonly int m_numOfWheels;

        protected float m_EnergyLeftPercentage;
        protected List<Wheel> m_Wheels;

        
        protected readonly Dictionary<int, int> r_VehicleProperties;

        public Vehicle(string i_ModelName, string i_LicensePlateNum, /*float i_EnergyLeftPercentage*/)
        {
            m_ModelName = i_ModelName;
            m_Wheels = new List<Wheel>();
            r_VehicleProperties = new Dictionary<int, int>();

        }
        internal string LicensePlateNum
        {
            get
            {
                return r_LicensePlateNum;
            }
        }


        internal float EnergyLeftPercentage
        {
            get
            {
                return m_EnergyLeftPercentage;
            }
        }

    }
}