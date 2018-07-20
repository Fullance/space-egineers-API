namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_InventoryDefinition
    {
        [ProtoMember(14)]
        public float InventoryMass = float.MaxValue;
        [ProtoMember(0x11)]
        public float InventorySizeX = 1.2f;
        [ProtoMember(20)]
        public float InventorySizeY = 0.7f;
        [ProtoMember(0x17)]
        public float InventorySizeZ = 0.4f;
        [ProtoMember(11)]
        public float InventoryVolume = float.MaxValue;
        [ProtoMember(0x1a)]
        public int MaxItemCount = 0x7fffffff;
    }
}

