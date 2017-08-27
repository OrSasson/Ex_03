using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Car : Vehicle
    {
        public Car()
        {
            eCarColor m_CarColor;
            eNumDoorsInCar m_NumOfDoors;

        }

        // $Ask Guy - This enum is very specific to this class. Could it reside here?
        private enum eCarColor
        {
            Green,
            Silver,
            White,
            Black
        }
        // See above.
        enum eNumDoorsInCar
        {
            Two,
            Three,
            Four,
            Five
        }

    }
}
