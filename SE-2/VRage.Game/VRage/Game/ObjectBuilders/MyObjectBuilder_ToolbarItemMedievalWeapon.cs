namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ToolbarItemMedievalWeapon : MyObjectBuilder_ToolbarItemWeapon
    {
        [ProtoMember(0x10)]
        public uint? ItemId;
    }
}

