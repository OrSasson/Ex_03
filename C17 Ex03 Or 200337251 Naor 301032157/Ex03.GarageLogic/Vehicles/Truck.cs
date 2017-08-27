using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehicles
{
    abstract class Truck : Vehicle
    {
        private bool isCarryigHazardousMaterial;
        float maxWeightCarry; // $Or$ I need to come up with     a better name for this. //$Naor - m_TruckWeightLimit ? 
    }
}
