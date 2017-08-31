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

        public Car(string i_ModelName, string i_LicenceNumber) 
            : base(i_ModelName, i_LicenceNumber, k_numOfWheels)
        {
            m_CarColor = eCarColor.Black;
            m_NumOfDoorsInCar = eNumDoorsInCar.FourDoors;
        }

        // $ Or - need to create a method for the enum validation.
        internal override void SetWheels(string i_ProducerName)
        {
            for (int i = 0; i < k_numOfWheels; ++i)
            {
                Wheels.Add(new Wheel(i_ProducerName, default(float), k_maximalAirPressure));
            }
        }
    }
}