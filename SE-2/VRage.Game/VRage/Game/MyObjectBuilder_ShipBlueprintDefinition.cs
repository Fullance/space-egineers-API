namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ShipBlueprintDefinition : MyObjectBuilder_PrefabDefinition
    {
        [ProtoMember(14)]
        public ulong OwnerSteamId;
        [ProtoMember(0x11)]
        public ulong Points;
        [ProtoMember(11)]
        public ulong WorkshopId;
    }
}

