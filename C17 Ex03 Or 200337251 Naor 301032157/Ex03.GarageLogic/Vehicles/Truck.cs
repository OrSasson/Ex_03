using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Truck : Vehicle
    {
        const int k_NumOfWheels = 12;
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
                return k_NumOfWheels;
            }
        }

        protected internal override float getMaxAirPressure()
        {
            return k_MaxAirPressure;
        }

        private void InitUniqueTruckProperties(Dictionary<string, string> i_AdditionaPropertiesDictionary)
        {// throwing an exception if for some reason the property value is not present in the dictionary. The parse methods of the value types throw the format/null exceptions.
            
            string truckPropertyValue;
            bool wasValueRetrieved = true;

            wasValueRetrieved = i_AdditionaPropertiesDictionary.TryGetValue(GarageConstants.k_MaxLoadingWeight, out truckPropertyValue);
            m_MaxLoadingWeight = float.Parse(truckPropertyValue);
            
            wasValueRetrieved = wasValueRetrieved && i_AdditionaPropertiesDictionary.TryGetValue(GarageConstants.k_CarryigHazardousMaterial, out truckPropertyValue);
            m_CarryigHazardousMaterial = bool.Parse(truckPropertyValue);

            if(wasValueRetrieved != true)
            {
                throw new Exception("One or more of the properties was not found");
            }
        }

        internal override void InitUniqueVehicleProperties(Dictionary<string, string> i_AdditionaPropertiesDictionary)
        {
            InitUniqueTruckProperties(i_AdditionaPropertiesDictionary);
        }
        public override string ToString()
        {
            return string.Format(
@"
Truck
-----
Model:                   {0}
License number:          {1}
{2}
Number of wheels:        {3}
{4}
Maximum carrying weight: {5}
Has dangerous material:  {6}

",
 ModelName,
 LicenseNumber,
 Wheel.ToString(),
 k_NumOfWheels,
 Engine.ToString(),
 m_MaxLoadingWeight,
 m_CarryigHazardousMaterial);
        }
    }
}
