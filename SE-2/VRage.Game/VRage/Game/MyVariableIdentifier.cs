namespace VRage.Game
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using VRage.Game.VisualScripting;
    using VRage.Serialization;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyVariableIdentifier
    {
        public int NodeID;
        public string VariableName;
        public string OriginName;
        public string OriginType;
        [NoSerialize]
        public static MyVariableIdentifier Default;
        public MyVariableIdentifier(int nodeId, string variableName)
        {
            this.NodeID = nodeId;
            this.VariableName = variableName;
            this.OriginName = string.Empty;
            this.OriginType = string.Empty;
        }

        public MyVariableIdentifier(int nodeId, string variableName, ParameterInfo parameter) : this(nodeId, variableName)
        {
            this.OriginName = parameter.Name;
            this.OriginType = parameter.ParameterType.Signature();
        }

        public MyVariableIdentifier(ParameterInfo parameter) : this(-1, string.Empty, parameter)
        {
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MyVariableIdentifier))
            {
                return false;
            }
            MyVariableIdentifier identifier = (MyVariableIdentifier) obj;
            return ((this.NodeID == identifier.NodeID) && (this.VariableName == identifier.VariableName));
        }

        static MyVariableIdentifier()
        {
            MyVariableIdentifier identifier = new MyVariableIdentifier {
                NodeID = -1,
                VariableName = ""
            };
            Default = identifier;
        }
    }
}

