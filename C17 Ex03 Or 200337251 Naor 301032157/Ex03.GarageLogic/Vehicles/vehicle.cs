using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        protected readonly int r_NumOfWheels;
        protected float m_EnergyLeftPercentage;
        private List<Wheel> m_Wheels;
        private Engine r_VehicleEngine; 

        protected internal abstract float getMaxAirPressure();

        internal abstract void InitUniqueVehicleProperties(Dictionary<string, string> additionaPropertiesDictionary);

        internal string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

        internal Engine Engine
        {
            get
            {
                return r_VehicleEngine;
            }
            set
            {
                r_VehicleEngine = value;
            }
        }

        public Vehicle(string i_ModelName, string i_LicensePlateNum, int i_NumOfWheels)
        {
            r_ModelName = i_ModelName;
            r_NumOfWheels = i_NumOfWheels;
            r_LicenseNumber = i_LicensePlateNum;
            m_Wheels = new List<Wheel>();
        }

        // Overrding Object's methods.
        public override int GetHashCode()
        {
            return r_LicenseNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Vehicle toCompareTo = null;
            if(obj is Vehicle)
            {
                toCompareTo = obj as Vehicle; 
            }

            return this.r_LicenseNumber == toCompareTo.r_LicenseNumber;
        }

        internal void SetVehicleWheels(string i_ManufacturerName)
        {
            for (int i = 0; i < r_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_ManufacturerName, 0, getMaxAirPressure()));
            }
        }

        internal void inflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateWheelToMaxCapacity();
            }
        }

        // Overriding Operators.
        public static bool operator ==(Vehicle i_Lvehicle, Vehicle i_Rvehicle)
        {
            return i_Lvehicle.r_LicenseNumber == i_Rvehicle.r_LicenseNumber;
        }

        public static bool operator !=(Vehicle i_Lvehicle, Vehicle i_Rvehicle)
        {
            return i_Lvehicle.r_LicenseNumber != i_Rvehicle.r_LicenseNumber;
        }
    }
}