namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ShipSoundSystemDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x10)]
        public float FullSpeed = 95f;
        [ProtoMember(0x13)]
        public float LargeShipDetectionRadius = 15f;
        [ProtoMember(13)]
        public float MaxUpdateRange = 2000f;
        [ProtoMember(0x16)]
        public float WheelStartUpdateRange = 500f;
        [ProtoMember(0x19)]
        public float WheelStopUpdateRange = 750f;
    }
}

