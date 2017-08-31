using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        // Should be properties?

        //Guy defined
        protected readonly string m_ModelName;
        private readonly string r_LicensePlateNum;
        protected readonly int r_numOfWheels;

        protected float m_EnergyLeftPercentage;
        private List<Wheel> m_Wheels;
        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public Vehicle(string i_ModelName, string i_LicensePlateNum, int i_NumOfWheels) //, /*float i_EnergyLeftPercentage*/)
        {
            m_ModelName = i_ModelName;
            r_numOfWheels = i_NumOfWheels;
            m_Wheels = new List<Wheel>();
        }

        abstract internal void SetWheels(string i_ProducerName);//, float i_MaxAirPressure)

        internal string LicensePlateNum
        {
            get
            {
                return r_LicensePlateNum;
            }
        }
        internal float EnergyLeftPercentage
        {
            get
            {
                return m_EnergyLeftPercentage;
            }
        }
        public abstract void InitVehicleAdditionalProperties();


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

        // Overriding Operators.
        public static bool operator ==(Vehicle i_Lvehicle, Vehicle i_Rvehicle)
        {
            return i_Lvehicle.r_LicensePlateNum == i_Rvehicle.r_LicensePlateNum;
        }
        public static bool operator !=(Vehicle i_Lvehicle, Vehicle i_Rvehicle)
        {
            return !(i_Lvehicle == i_Rvehicle);
        }

        private  Engine r_FuelEngine;
        // $change this.
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

    }
}