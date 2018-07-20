namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_VariableScriptNode : MyObjectBuilder_ScriptNode
    {
        public List<MyVariableIdentifier> OutputNodeIds = new List<MyVariableIdentifier>();
        public List<MyVariableIdentifier> OutputNodeIdsX = new List<MyVariableIdentifier>();
        public List<MyVariableIdentifier> OutputNodeIdsY = new List<MyVariableIdentifier>();
        public List<MyVariableIdentifier> OutputNodeIdsZ = new List<MyVariableIdentifier>();
        public string VariableName = "Default";
        public string VariableType = string.Empty;
        public string VariableValue = string.Empty;
        public Vector3D Vector;
    }
}

