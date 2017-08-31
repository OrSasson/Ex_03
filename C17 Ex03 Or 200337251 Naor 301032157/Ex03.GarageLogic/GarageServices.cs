using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   public class GarageServices
    {
        // static?
        private static Dictionary<Vehicle, CustomerData> s_GarageEntries = new Dictionary<Vehicle, CustomerData>();
        private List<Vehicle> m_VehicleList;      

        internal GarageServices()
        {
        }

        
        public string ShowVehiclesByStatus(eVehicleStatus i_VehicleStatus)
        {
            //int licenseNumber;
            //CustomerData customerData;
            //StringBuilder vehiclesByStatusSB = new StringBuilder();

            //foreach (Vehicle vehicle in m_VehicleList)
            //{
            //    int.TryParse(vehicle.LicensePlateNum, out licenseNumber);
            //    m_GarageData.TryGetValue(licenseNumber, out customerData);
            //    vehiclesByStatusSB.AppendLine(licenseNumber.ToString());
            //}

            //return vehiclesByStatusSB.ToString();
            string bababa = "This is all the vehicles";
            return bababa;
        }

        // $Or - These 3 methods will be option 1 in the menu. Use your UI to create this flow - if exists, change status. else - AddNewGarage Entry.
        public void ChangeVehicleStatus(Vehicle i_VehicleToChange, eVehicleStatus i_NewVehicleStatus)
        {
            CustomerData customerData;

            s_GarageEntries.TryGetValue(i_VehicleToChange, out customerData);
            customerData.VehicleStatus = i_NewVehicleStatus;
        }

        public bool IsVehicleInGarage(Vehicle i_Vehicle)
        {
            return s_GarageEntries.ContainsKey(i_Vehicle);
        }

        public static void AddNewGarageEntry(eVehicleType i_VehicleType, string i_ModelName, string i_LicenceNumber, string i_WheelManfucaturerName, string i_OwnerName, string i_OwnerPhoneNum)
        {
            string propertiesToAdd = string.Empty;

            // Check if the casting works.
            Vehicle vehicleToAdd = VehicleFactory.CreateVehicle((int)i_VehicleType, i_ModelName, i_LicenceNumber);
            vehicleToAdd.SetWheels(i_WheelManfucaturerName);
            CustomerData vehicleCustomerData = new CustomerData(i_OwnerName, i_OwnerPhoneNum);

            s_GarageEntries.Add(vehicleToAdd, vehicleCustomerData);
        }


        // $Or - This method will be option 2 in the menu. Just pass the right enum value to display the desired results. Display options in the UI accordingly (repair, paid...) and print the list returned.
        public static List<string> GetVehicles(eVehicleStatus i_vehicleStatusFilter, bool i_IncludeFiltering) 
        {
            List<string> vehiclesList = new List<string>();

            foreach (KeyValuePair<Vehicle,CustomerData> garageEntry in s_GarageEntries)
            {
                if(i_IncludeFiltering && garageEntry.Value.VehicleStatus == i_vehicleStatusFilter)
                {
                    vehiclesList.Add(garageEntry.Key.LicensePlateNum);
                }
            }

            return vehiclesList;
        }



    }

}
