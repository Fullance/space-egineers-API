namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_VisualScript : MyObjectBuilder_Base
    {
        [ProtoMember(0x12)]
        public List<string> DependencyFilePaths;
        [ProtoMember(15), Nullable]
        public string Interface;
        [ProtoMember(0x1a)]
        public string Name;
        [DynamicObjectBuilder(false), XmlArrayItem("MyObjectBuilder_ScriptNode", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ScriptNode>)), ProtoMember(0x15)]
        public List<MyObjectBuilder_ScriptNode> Nodes;
    }
}

