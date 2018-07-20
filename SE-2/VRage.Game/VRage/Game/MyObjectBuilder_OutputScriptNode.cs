namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_OutputScriptNode : MyObjectBuilder_ScriptNode
    {
        public List<MyInputParameterSerializationData> Inputs = new List<MyInputParameterSerializationData>();
        public int SequenceInputID = -1;
    }
}

