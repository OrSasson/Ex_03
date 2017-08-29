using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeExeception : Exception
    {
        float m_MinValue;
        float m_MaxValue;

        public ValueOutOfRangeExeception() : base()
        {
            m_MinValue = 0;
            m_MaxValue = 40;
        }
    }
}