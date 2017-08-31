using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Engine
    {
        // Or - Should this be const?
        private readonly float r_MaxEnergyAmount;
        private float m_CurrentEnergyAmount;

        public Engine(float i_MaxEnergyAmount)
        {
            r_MaxEnergyAmount = i_MaxEnergyAmount;
            m_CurrentEnergyAmount = default(float);
        }

        protected float MaxEnergyAmount
        {
            get
            {
                return r_MaxEnergyAmount;
            }
        }

        protected float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentEnergyAmount;
            }
            set
            {
                m_CurrentEnergyAmount = value;
            }
        }
    }
}
