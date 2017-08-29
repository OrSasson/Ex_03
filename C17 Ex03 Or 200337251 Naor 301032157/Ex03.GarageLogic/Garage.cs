using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   internal class Garage
    {
        private Dictionary<int, CustomerData> m_VehicleData;
        private List<Vehicle> m_VehicleList;      

        internal Garage()
        {
            m_VehicleData = new Dictionary<int, CustomerData>();

            //vehicleData = new Dictionary<Vehicle.number...., CustomerData>();
        }

        private void  AssignNewCarToGarage()
        {
            m_VehicleData.Add(GetVehicle(), GetCustomerData());
        }

        public string ShowVehiclesByStatus(eVehicleStatus i_VehicleStatus)
        {
            int licenseNumber;
            CustomerData customerData;
            StringBuilder vehiclesByStatusSB = new StringBuilder();

            foreach (Vehicle vehicle in m_VehicleList)
            {
                int.TryParse(vehicle.LicensePlateNum, out licenseNumber);
                m_VehicleData.TryGetValue(licenseNumber, out customerData);
                vehiclesByStatusSB.AppendLine(licenseNumber.ToString());
            }

            return vehiclesByStatusSB.ToString();
        }

        public void ChangeVehicleStatus(int i_LicensePlateNumber, eVehicleStatus i_NewVehicleStatus)
        {
            CustomerData customerData;
            
            m_VehicleData.TryGetValue(i_LicensePlateNumber, out customerData);
            customerData.VehicleStatus = i_NewVehicleStatus;
        }

        private CustomerData GetCustomerData()
        {
            throw new NotImplementedException();
        }

        private int GetVehicle()
        {
            throw new NotImplementedException();
        }
    }

}
