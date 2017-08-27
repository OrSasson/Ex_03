using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private readonly string m_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float m_MaximalAirPressure;

        // $Or - Change to Setter.   
        // Feels kinda right. He only required it do be in a method, setters are methods... 
        private void inflateWheel(float i_AmountOfAirToAdd)
        {
            // Question for Guy - I don't think a Try Catch block is neccessary here, since he explained we must do it only 
            // when we try to access or modify another element, like a file, device, connection... it does not make sense that a different entity than Wheel will change the wheels stats.
            if(m_CurrentAirPressure + i_AmountOfAirToAdd > m_MaximalAirPressure)
            {
                m_CurrentAirPressure += i_AmountOfAirToAdd;
            }
        }

    }
}
