using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   internal abstract class Car : Vehicle
    {

        eCarColor m_CarColor;
        eNumDoorsInCar m_NumOfDoorsInCar;

        const int k_numOfWheels = 4;
        const int k_maximalAirPressure = 32;

        // $ OrNaor - Feels funky. Check.
        public Car(string i_ModelName, string i_LicenceNumber) :base(i_ModelName, i_LicenceNumber)
        {
            m_CarColor = eCarColor.Black;
            m_NumOfDoorsInCar = eNumDoorsInCar.Four;

        }
    }
}
