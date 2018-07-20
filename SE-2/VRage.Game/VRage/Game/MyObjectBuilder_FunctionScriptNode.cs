namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((System.Type) null, null)]
    public class MyObjectBuilder_FunctionScriptNode : MyObjectBuilder_ScriptNode
    {
        public string DeclaringType = string.Empty;
        public string ExtOfType = string.Empty;
        public List<MyVariableIdentifier> InputParameterIDs = new List<MyVariableIdentifier>();
        public List<MyParameterValue> InputParameterValues = new List<MyParameterValue>();
        public MyVariableIdentifier InstanceInputID = MyVariableIdentifier.Default;
        public List<IdentifierList> OutputParametersIDs = new List<IdentifierList>();
        public int SequenceInputID = -1;
        public int SequenceOutputID = -1;
        public string Type = string.Empty;
        public int Version;
    }
}

