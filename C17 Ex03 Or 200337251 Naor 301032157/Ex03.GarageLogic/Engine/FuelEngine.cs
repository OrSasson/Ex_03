using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        eFuelType m_EngineFueltype;

        public FuelEngine(eFuelType i_FuelType, float i_MaxEnergyAmount)
            :base(i_MaxEnergyAmount)
        {
            m_EngineFueltype = i_FuelType;
        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
    }
}
