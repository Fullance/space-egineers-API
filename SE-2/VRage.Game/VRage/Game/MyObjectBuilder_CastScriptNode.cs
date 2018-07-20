namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((System.Type) null, null)]
    public class MyObjectBuilder_CastScriptNode : MyObjectBuilder_ScriptNode
    {
        public MyVariableIdentifier InputID = MyVariableIdentifier.Default;
        public List<MyVariableIdentifier> OuputIDs = new List<MyVariableIdentifier>();
        public int SequenceInputID = -1;
        public int SequenceOuputID = -1;
        public string Type;
    }
}

