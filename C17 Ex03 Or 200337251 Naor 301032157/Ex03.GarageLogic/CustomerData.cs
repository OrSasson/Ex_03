namespace Ex03.GarageLogic
{

    internal class CustomerData
    {
        readonly string m_CustomerName;
        readonly string m_CustomerPhoneNumber;
        eVehicleStatus m_VehicleStatus;

       

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                // $Or - Throw exception not the right enum...
                m_VehicleStatus = value;
            }
        }

        internal CustomerData(string i_CustomerName, string i_CustomerPhoneNumber)
        {
            m_CustomerName = i_CustomerName;
            m_CustomerPhoneNumber = i_CustomerPhoneNumber;
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