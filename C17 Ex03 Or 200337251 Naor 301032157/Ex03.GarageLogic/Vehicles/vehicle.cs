using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string m_ModelName;
        Dictionary<string, object> additionaPropertiesDictionary;

        private readonly string r_LicensePlateNum;
        internal string LicensePlateNum
        {
            get
            {
                return r_LicensePlateNum;
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
            m_Wheels = new List<Wheel>();
        }
        public abstract void InitUniqueVehicleTypeProperties();

        // Overrding Object's methods.
        public override int GetHashCode()
        {
            return r_LicensePlateNum.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            Vehicle toCompareTo = obj as Vehicle;

            if(toCompareTo != null)
            {
                equals = r_LicensePlateNum == toCompareTo.r_LicensePlateNum;
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
        internal abstract float getMaxAirPressure();

        // Overriding Operators.
        public static bool operator == (Vehicle i_Lvehicle, Vehicle i_Rvehicle)
        {
            return i_Lvehicle.r_LicensePlateNum == i_Rvehicle.r_LicensePlateNum;
        }

        public static bool operator != (Vehicle i_Lvehicle, Vehicle i_Rvehicle)
        {
            return !(i_Lvehicle == i_Rvehicle);
        }
        
      
    }
}