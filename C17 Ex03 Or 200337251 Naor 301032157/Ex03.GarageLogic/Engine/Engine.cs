using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Engine
    { // Should currentEnergy initialization be in the ctor here?
        private float m_CurrentEnergy;
        private readonly float r_MaxEnergy;

        internal Engine(float i_MaxEnergyAmount)
        {
            r_MaxEnergy = i_MaxEnergyAmount;
        }

        protected float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentEnergy;
            }
            //set
            //{
            //    m_CurrentEnergy = value;
            //}
        }

        private float calculateRemainingEnergyPercentage()
        {
            return 100f * m_CurrentEnergy / r_MaxEnergy;
        }

        internal float RemainingEnergyPercentage
        {
            get
            {
                return calculateRemainingEnergyPercentage();
            }
        }

        protected float MaxEnergyAmount
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        internal void AddEnergyToVehicle(float i_EnergyToAdd)
        {
            if (i_EnergyToAdd > r_MaxEnergy - m_CurrentEnergy || i_EnergyToAdd < 0)
            {
                throw new ValueOutOfRangeExecption("The inputted Fuel amount is out of range.", 0 , r_MaxEnergy - m_CurrentEnergy);
            }
            else
            {
                m_CurrentEnergy += i_EnergyToAdd;
            }
        }
    }
}
