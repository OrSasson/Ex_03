using Ex03.GarageLogic.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    //$ check 
    internal static class VehicleFactory 
    {
        //private Build/Generate/Produce.... Car  
        private static Vehicle CreateVehicle(eVehicleType i_VehicleType)
        {
            //$Naor - added a temporary local Vehicle
            Vehicle newVehicle = null;

            if(i_VehicleType == eVehicleType.Car)
            {
                // new Car(....)
            }
            else if( i_VehicleType == eVehicleType.Motorcycle)
            {
               // new Motorcycle(....);
            }

            return newVehicle;

        } 
        
    }
}