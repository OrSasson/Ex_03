﻿namespace Ex03.GarageLogic
{

    internal class CustomerData
    {
        readonly string m_CustomerName;
        readonly string m_CustomerPhoneNumber;
        eVehicleStatus m_VehicleStatus;

        internal CustomerData(string i_CustomerName, string i_CustomerPhoneNumber)
        {
            m_CustomerName = i_CustomerName;
            m_CustomerPhoneNumber = i_CustomerPhoneNumber;
        }


        internal eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;

            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            string customerToStr = string.Format(
                @"Customer name: {0}
Customer phone number: {1}
Vehicle status: {2}"
, m_CustomerName, m_CustomerPhoneNumber , m_VehicleStatus);

            return customerToStr;
        }


    }
}