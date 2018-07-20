namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_PirateAntennas : MyObjectBuilder_SessionComponent
    {
        [ProtoMember(0x1f)]
        public MyPirateDrone[] Drones;
        [ProtoMember(0x1c)]
        public long PiratesIdentity;

        [ProtoContract]
        public class MyPirateDrone
        {
            [XmlAttribute("AntennaEntityId"), ProtoMember(0x13)]
            public long AntennaEntityId;
            [ProtoMember(0x17), XmlAttribute("DespawnTimer")]
            public int DespawnTimer;
            [ProtoMember(15), XmlAttribute("EntityId")]
            public long EntityId;
        }
    }
}

