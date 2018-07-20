namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_WeaponItemDefinition : MyObjectBuilder_PhysicalItemDefinition
    {
        [ProtoMember(0x1a)]
        public bool ShowAmmoCount;
        [ProtoMember(0x17)]
        public PhysicalItemWeaponDefinitionId WeaponDefinitionId;

        [ProtoContract]
        public class PhysicalItemWeaponDefinitionId
        {
            [ProtoMember(0x13), XmlAttribute]
            public string Subtype;
            [XmlIgnore]
            public MyObjectBuilderType Type = typeof(MyObjectBuilder_WeaponDefinition);
        }
    }
}

