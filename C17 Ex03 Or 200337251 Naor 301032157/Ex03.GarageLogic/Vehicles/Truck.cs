using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Truck : Vehicle
    {
        const int k_numOfWheels = 12;
        const int k_MaxAirPressure = 34;
        private bool m_CarryigHazardousMaterial;
        float m_MaxLoadingWeight;
        

        public Truck(string i_ModelName, string i_LicenceNumber) 
            : base(i_ModelName, i_LicenceNumber, NumOfWheels)
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

        public static int NumOfWheels
        {
            get
            {
                return k_numOfWheels;
            }
        }

        internal override float getMaxAirPressure()
        {
            return k_MaxAirPressure;
        }

        public abstract override void InitUniqueVehicleTypeProperties();
        
        
    }
}
