namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_EventScriptNode : MyObjectBuilder_ScriptNode
    {
        public string Name;
        public List<string> OuputTypes = new List<string>();
        public List<IdentifierList> OutputIDs = new List<IdentifierList>();
        public List<string> OutputNames = new List<string>();
        public int SequenceOutputID = -1;
    }
}

