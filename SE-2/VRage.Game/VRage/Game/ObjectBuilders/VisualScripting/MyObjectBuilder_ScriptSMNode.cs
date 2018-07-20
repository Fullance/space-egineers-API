namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ScriptSMNode : MyObjectBuilder_Base
    {
        [ProtoMember(0x10)]
        public string Name;
        [ProtoMember(13)]
        public SerializableVector2 Position;
        [ProtoMember(20)]
        public string ScriptClassName;
        [ProtoMember(0x12)]
        public string ScriptFilePath;
    }
}

