using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeExecption : Exception
    {
        float m_MinValue;
        float m_MaxValue;

        public ValueOutOfRangeExecption(string i_Message, float i_MinValue, float i_MaxValue) : base(i_Message)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }

            private set
            {
                m_MinValue = value;
            }
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }

            private set
            {
                m_MaxValue = value;
            }
        }
    }
}