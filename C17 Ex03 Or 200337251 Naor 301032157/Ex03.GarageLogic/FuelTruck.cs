namespace Ex03.GarageLogic
{
    internal class FuelTruck : Truck
    {
        private const float k_MaxFuelAmount = 130f;
        private const eFuelType k_fuelType = eFuelType.Soler;

        public FuelTruck(string i_ModelName, string i_LicenceNumber)
            : base(i_ModelName, i_LicenceNumber)
        {
            Engine = new FuelEngine(k_fuelType, k_MaxFuelAmount);
        }
    }
}
