namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ScriptScriptNode : MyObjectBuilder_ScriptNode
    {
        public List<MyInputParameterSerializationData> Inputs = new List<MyInputParameterSerializationData>();
        public string Name = string.Empty;
        public List<MyOutputParameterSerializationData> Outputs = new List<MyOutputParameterSerializationData>();
        public string Path;
        public int SequenceInput = -1;
        public int SequenceOutput = -1;
    }
}

