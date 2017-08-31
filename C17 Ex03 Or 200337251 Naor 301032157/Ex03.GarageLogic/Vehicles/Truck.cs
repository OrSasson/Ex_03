using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Truck : Vehicle
    {
        const int k_numOfWheels = 12;
        const int k_maximalAirPressure = 34;
        private bool m_CarryigHazardousMaterial;
        float m_MaxLoadingWeight;
        

        public Truck(string i_ModelName, string i_LicenceNumber) 
            : base(i_ModelName, i_LicenceNumber, K_numOfWheels)
        {
            m_MaxLoadingWeight = default(float);
            m_CarryigHazardousMaterial = default(bool);
        }

        public bool CarryigHazardousMaterial
        {
            get
            {
                return m_CarryigHazardousMaterial;
            }

            set
            {
                m_CarryigHazardousMaterial = value;
            }
        }

        public static int K_numOfWheels
        {
            get
            {
                return k_numOfWheels;
            }
        }

        public static int K_maximalAirPressure
        {
            get
            {
                return k_maximalAirPressure;
            }
        }

        public abstract override void InitVehicleAdditionalProperties();
        
        //Duplicate Code!!!!
        //protected override void SetWheels(string i_ProducerName)
        //{
        //    for (int i = 0; i < k_numOfWheels; ++i)
        //    {
        //        m_Wheels.Add(new Wheel(i_ProducerName, 0, k_maximalAirPressure));
        //    }
        //}
    }
}
