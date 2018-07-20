namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_WheelModelsDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x11, IsRequired=false)]
        public string AlternativeModel;
        [ProtoMember(20, IsRequired=false)]
        public float AngularVelocityThreshold;
    }
}

