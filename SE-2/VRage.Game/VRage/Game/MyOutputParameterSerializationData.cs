namespace VRage.Game
{
    using System;
    using System.Collections.Generic;

    public class MyOutputParameterSerializationData
    {
        public string Name;
        public IdentifierList Outputs;
        public string Type;

        public MyOutputParameterSerializationData()
        {
            this.Outputs.Ids = new List<MyVariableIdentifier>();
        }
    }
}

