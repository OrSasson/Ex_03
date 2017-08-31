using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string m_Manufacturer;
        private readonly float m_MaximalAirPressure;
        private float m_CurrentAirPressure;
    
        public Wheel(string i_Manufacturer,float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_MaximalAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = default(float);
        }

        public void inflateWheel(float i_AmountOfAirToAdd)
        {
            if(i_AmountOfAirToAdd < 0 || m_CurrentAirPressure + i_AmountOfAirToAdd > m_MaximalAirPressure)
            {
                throw new ValueOutOfRangeExecption("You are trying to add too much air, or inputting a negative number as air pressure unit value. ", 0, m_MaximalAirPressure - m_CurrentAirPressure);
                
            }

            m_CurrentAirPressure += i_AmountOfAirToAdd;
        }

        public override string ToString()
        {
            return String.Format(@"Manufacturer: {0}
Current air pressure Units: {1}.
The max air pressure is: {2}", m_Manufacturer, m_CurrentAirPressure, m_MaximalAirPressure);
        }

    }
}
