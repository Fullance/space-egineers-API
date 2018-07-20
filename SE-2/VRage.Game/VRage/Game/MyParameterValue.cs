namespace VRage.Game
{
    using System;

    public class MyParameterValue
    {
        public string ParameterName;
        public string Value;

        public MyParameterValue()
        {
            this.ParameterName = string.Empty;
            this.Value = string.Empty;
        }

        public MyParameterValue(string paramName)
        {
            this.ParameterName = paramName;
        }
    }
}

