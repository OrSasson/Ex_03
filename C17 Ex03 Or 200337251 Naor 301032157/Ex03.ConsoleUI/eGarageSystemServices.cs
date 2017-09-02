using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal enum eGarageSystemServices
    {
        NoSelection = 0,
        AssignVehicleToRepair,
        ViewVehiclesPlateNumbersByStatus,
        ChangeVehicleStatus,
        InflateVehicleWheelsToMax,
        RefuelFuelBasedVehicle,
        RechargeElectricBasedVehicle,
        ViewVehicleInfo
    }
}