namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_PhysicalMaterialDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x1a)]
        public float CollisionMultiplier = 1f;
        [ProtoMember(14)]
        public float Density = 32000f;
        [ProtoMember(20)]
        public float HorisontalFragility = 1f;
        [ProtoMember(0x11)]
        public float HorisontalTransmissionMultiplier = 1f;
        [ProtoMember(0x17)]
        public float SupportMultiplier = 1f;
        [ProtoMember(11)]
        public bool Transparent;
    }
}

