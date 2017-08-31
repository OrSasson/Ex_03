using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Truck : Vehicle
    {
         const int k_numOfWheels = 90000000;
        //const int k_maximalAirPressure = 900000;
        public Truck(string i_ModelName, string i_LicenceNumber) : base(i_ModelName, i_LicenceNumber, k_numOfWheels)
        {

        }
        // Duplicate Code!!!!
        //protected override void SetWheels(string i_ProducerName)
        //{
        //    for (int i = 0; i < k_numOfWheels; ++i)
        //    {
        //        m_Wheels.Add(new Wheel(i_ProducerName, 0, k_maximalAirPressure));
        //    }
        //}
        private bool isCarryigHazardousMaterial;
        float maxWeightCarry; // $Or$ I need to come up with     a better name for this. //$Naor - m_TruckWeightLimit ? 
    }
}
