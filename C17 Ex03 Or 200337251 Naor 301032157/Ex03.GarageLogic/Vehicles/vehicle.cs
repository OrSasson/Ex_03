using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected internal abstract float getMaxAirPressure();
        internal abstract void InitUniqueVehicleProperties(Dictionary<string, string> additionaPropertiesDictionary);

        protected readonly string m_ModelName;

        private readonly string r_LicenseNumber;
        internal string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        protected readonly int r_NumOfWheels;

        protected float m_EnergyLeftPercentage;

        private List<Wheel> m_Wheels;
        public  List<Wheel> Wheels
        {
            get { return m_Wheels; }
            
        }

        private Engine r_FuelEngine; // why is there an Engine here? 
        internal Engine Engine
        {
            get
            {
                return r_FuelEngine;
            }
            set
            {
                r_FuelEngine = value;
            }
        }

        public Vehicle(string i_ModelName, string i_LicensePlateNum, int i_NumOfWheels)
        {
            m_ModelName = i_ModelName;
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
            bool equals = false;
            Vehicle toCompareTo = obj as Vehicle;

            if(toCompareTo != null)
            {
                equals = r_LicenseNumber == toCompareTo.r_LicenseNumber;
            }

            return base.Equals(obj);
        }

        internal void SetWheels(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            for (int i = 0; i < r_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_ManufacturerName, i_CurrentAirPressure, getMaxAirPressure()));
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
        public static bool operator == (Vehicle i_Lvehicle, Vehicle i_Rvehicle)
        {
            return i_Lvehicle.r_LicenseNumber == i_Rvehicle.r_LicenseNumber;
        }

        public static bool operator != (Vehicle i_Lvehicle, Vehicle i_Rvehicle)
        {
            return !(i_Lvehicle == i_Rvehicle);
        }
        
      
    }
}