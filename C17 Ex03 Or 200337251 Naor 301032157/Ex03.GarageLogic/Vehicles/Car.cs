using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle
    {
        eCarColor m_CarColor;
        eNumDoorsInCar m_NumOfDoorsInCar;
        const int k_numOfWheels = 4;
        const int k_MaxAirPressure = 32;

        public Car(string i_ModelName, string i_LicenceNumber)
            : base(i_ModelName, i_LicenceNumber, k_numOfWheels)
        {
            m_CarColor = eCarColor.Black;
            m_NumOfDoorsInCar = eNumDoorsInCar.FourDoors;
        }

        // $ Or - need to create a method for the enum validation.
        internal override float getMaxAirPressure()
        {
            return k_MaxAirPressure;
        }

        // Need to make this generic, so we won't duplicate code.
        private void InitUniqueCarProperties(Dictionary<string, string> additionaPropertiesDictionary)
        {
            string carPropertyValue;

            additionaPropertiesDictionary.TryGetValue(GarageConstants.k_KeyColor, out carPropertyValue);
            m_CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), carPropertyValue);

            additionaPropertiesDictionary.TryGetValue(GarageConstants.k_KeyNumOfDoors, out carPropertyValue);
            m_NumOfDoorsInCar = (eNumDoorsInCar)Enum.Parse(typeof(eNumDoorsInCar), carPropertyValue);
        }

        internal override void InitUniqueVehicleProperties(Dictionary<string, string> additionaPropertiesDictionary)
        {
            InitUniqueCarProperties(additionaPropertiesDictionary);
        }

    }
}
