using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeExecption : Exception
    {
        internal float m_MinValue;
        internal float m_MaxValue;

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