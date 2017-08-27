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
        private static CreateCar(eVehicleType i_VehicleType)
        {
            if(i_VehicleType == eVehicleType.Car)
            {
                new Car(....)
            }
            else if( i_VehicleType == eVehicleType.Motorcycle)
            {
                new Motorcycle
            }

        } 
        
    }

    class Program
    {
        internal static void Main()
        {
            
        }
    }
    
}



