using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        private const float k_MaxAirPressure = 28f;
        private const int k_NumOfWheels = 2;

        eMotorcylceLicenseType m_LicenseType;
        int m_EngineVolume; // m_EngineCapacity??

        internal Motorcycle(string i_ModelName, string i_LicenceNumber)
            : base(i_ModelName, i_LicenceNumber, k_NumOfWheels) { }

        private void initUniqueMotorcycleProperties(Dictionary<string, string> additionaPropertiesDictionary)
        {
            string MotoryclePropertyValue;
            bool wasValueRetrieved = true;

            wasValueRetrieved = additionaPropertiesDictionary.TryGetValue(GarageConstants.k_KeyLicenseType, out MotoryclePropertyValue);
            m_LicenseType = (eMotorcylceLicenseType)Enum.Parse(typeof(eMotorcylceLicenseType), MotoryclePropertyValue);

            wasValueRetrieved = wasValueRetrieved && additionaPropertiesDictionary.TryGetValue(GarageConstants.k_KeyEngineVolume, out MotoryclePropertyValue);
            m_EngineVolume = int.Parse(MotoryclePropertyValue);

            if (wasValueRetrieved != true)
            {
                throw new Exception("One or more of the properties was not found");
            }
        }

        internal override void InitUniqueVehicleProperties(Dictionary<string, string> additionaPropertiesDictionary)
        {
            initUniqueMotorcycleProperties(additionaPropertiesDictionary);
        }

        protected internal override float getMaxAirPressure()
        {
            return k_MaxAirPressure;
        }
        public override string ToString()
        {
            return string.Format(
@"
Motorcycle
----------
Model:             {0}
License number:    {1}
{2}
Number of wheels:  {3}
{4}
License Type:      {5}
Engine Volume:     {6}

",
 ModelName,
 LicenseNumber,
 Wheel.ToString(),
 k_NumOfWheels,
 Engine.ToString(),
 m_LicenseType,
 m_EngineVolume);

        }
    }
}