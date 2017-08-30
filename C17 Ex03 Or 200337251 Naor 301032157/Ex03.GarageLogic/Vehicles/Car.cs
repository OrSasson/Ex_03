using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   internal abstract class Car : Vehicle
    {
        eCarColor m_CarColor;
        eNumDoorsInCar m_NumOfDoorsInCar;
        Engine Engine;
        // $ OrNaor - Feels funky. Check.
        public Car(eCarColor i_CarColor, eNumDoorsInCar i_NumOfDoorsInCar, string i_ModelName, string i_LicensePlateNum, float i_EnergyLeftPercentage, List<Wheel> i_Wheels)
            :base (i_ModelName, i_LicensePlateNum,i_EnergyLeftPercentage, i_Wheels)
        {
            
        }
    }
}
