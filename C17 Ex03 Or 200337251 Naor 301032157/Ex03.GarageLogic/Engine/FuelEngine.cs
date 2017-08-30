using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        public FuelEngine(eFuelType i_fuelType, float i_MaxEnergyAmount, float i_CurrentEnergyAmount) :base(i_MaxEnergyAmount, i_CurrentEnergyAmount)
        {

        }

        internal enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
    }
}
