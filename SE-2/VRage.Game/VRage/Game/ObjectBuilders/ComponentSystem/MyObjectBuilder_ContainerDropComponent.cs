namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_ContainerDropComponent : MyObjectBuilder_ComponentBase
    {
        [ProtoMember(12, IsRequired=false)]
        public bool Competetive;
        [ProtoMember(15, IsRequired=false)]
        public string GPSName = "";
        [ProtoMember(0x12, IsRequired=false)]
        public long Owner;
        [ProtoMember(0x15, IsRequired=false), Serialize(MyObjectFlags.DefaultZero)]
        public string PlayingSound = "";
    }
}

