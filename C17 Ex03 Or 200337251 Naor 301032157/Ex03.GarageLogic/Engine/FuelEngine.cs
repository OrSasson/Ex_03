using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;


        public FuelEngine(eFuelType i_FuelType, float i_MaxEnergyAmount)
       : base(i_MaxEnergyAmount)
        {
            r_FuelType = i_FuelType;
        }

        internal static string GetSupportedFuelTypes()
        {
            return string.Join(",", Enum.GetNames(typeof(eFuelType)));
        }


       internal eFuelType FuelType
       {
            get
            {
                return r_FuelType;
            }
       }


        public override string ToString()
        {
            string enginePropertiesStr = string.Format(
@"
Fuel Engine Statistics:
------------------------
Fuel Type:           {0}
Current Fuel amount: {1}
Max Fuel Amount:     {2}
Fuel Left:           {3}%",
                r_FuelType.ToString(),
                CurrentEnergyAmount,
                MaxEnergyAmount,
                RemainingEnergyPercentage);

            return enginePropertiesStr;
        }

    }
}
