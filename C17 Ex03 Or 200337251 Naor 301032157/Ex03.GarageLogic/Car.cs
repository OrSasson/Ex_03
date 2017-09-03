using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle
    {
        private const int k_NumOfWheels = 4;
        private const int k_MaxAirPressure = 32;
        private eCarColor m_CarColor;
        private eNumDoorsInCar m_NumOfDoorsInCar;

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }

            private set
            {
                m_CarColor = value;
            }
        }

        public eNumDoorsInCar NumOfDoorsInCar
        {
            get
            {
                return m_NumOfDoorsInCar;
            }

            private set
            {
                m_NumOfDoorsInCar = value;
            }
        }

        public Car(string i_ModelName, string i_LicenceNumber)
            : base(i_ModelName, i_LicenceNumber, k_NumOfWheels)
        {
            CarColor = eCarColor.NotDetermined;
            NumOfDoorsInCar = eNumDoorsInCar.NotDetermined;
        }

        private void initUniqueCarProperties(Dictionary<string, string> additionaPropertiesDictionary)
        {
            string carPropertyValue;
            bool wasValueRetrieved = true;

            wasValueRetrieved = additionaPropertiesDictionary.TryGetValue(GarageConstants.k_KeyColor, out carPropertyValue);
            CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), carPropertyValue);

            wasValueRetrieved = wasValueRetrieved && additionaPropertiesDictionary.TryGetValue(GarageConstants.k_KeyNumOfDoors, out carPropertyValue);
            NumOfDoorsInCar = (eNumDoorsInCar)Enum.Parse(typeof(eNumDoorsInCar), carPropertyValue);

            if (wasValueRetrieved != true)
            {
                throw new Exception("One or more of the properties was not found");
            }
        }

        internal override void InitUniqueVehicleProperties(Dictionary<string, string> additionaPropertiesDictionary)
        {
            initUniqueCarProperties(additionaPropertiesDictionary);
        }

        protected internal override float getMaxAirPressure()
        {
            return k_MaxAirPressure;
        }

        public override string ToString()
        {
            return string.Format(
@"
Car
----------------------------
Model:                   {0}
License number:          {1}
{2}
Number of wheels:        {3}
{4}
Color: {5}
Number of Doors:  {6}",
 ModelName,
 LicenseNumber,
 Engine.ToString(),
 k_NumOfWheels,
 Wheel.ToString(),
 m_CarColor,
 m_NumOfDoorsInCar);
        }
    }
}
