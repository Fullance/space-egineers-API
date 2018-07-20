namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_DeviceBase : MyObjectBuilder_Base
    {
        [ProtoMember(11)]
        public uint? InventoryItemId = null;

        public bool ShouldSerializeInventoryItemId() => 
            this.InventoryItemId.HasValue;
    }
}

