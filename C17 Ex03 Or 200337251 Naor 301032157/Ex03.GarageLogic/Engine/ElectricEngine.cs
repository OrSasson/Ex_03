using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxBatteryCapacityInHours)
            : base(i_MaxBatteryCapacityInHours)
        {
               
        }

        public override string ToString()
        {
            string enginePropertiesStr = string.Format(
@"
Electric Engine Statistics:
-----------------------
Current Fuel amount:    {0}
Max Battery Amount:     {1}
Battery Left:           {2}%",

                // Should energySource or something like that.
                CurrentEnergyAmount,
                MaxEnergyAmount,
                RemainingEnergyPercentage);

            return enginePropertiesStr;
        }

    }
}
