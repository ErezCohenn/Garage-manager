using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string valueType = "value") :
        base(string.Format("Error: The {0} that was inserted is out of range.{1}The {2} should be within the range of the values: {3} To {4}{5}",
        valueType, Environment.NewLine, valueType, i_MinValue, i_MaxValue, Environment.NewLine))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }
    }
}
