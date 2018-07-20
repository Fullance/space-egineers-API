namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Game.ObjectBuilders.ComponentSystem;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_Inventory : MyObjectBuilder_InventoryBase
    {
        [ProtoMember(0x2b), DefaultValue((string) null)]
        public MyInventoryFlags? InventoryFlags = null;
        [ProtoMember(0x18)]
        public List<MyObjectBuilder_InventoryItem> Items = new List<MyObjectBuilder_InventoryItem>();
        [ProtoMember(0x21), DefaultValue((string) null)]
        public MyFixedPoint? Mass = null;
        [DefaultValue((string) null), ProtoMember(0x24)]
        public int? MaxItemCount = null;
        [ProtoMember(0x1b)]
        public uint nextItemId;
        [ProtoMember(0x2e)]
        public bool RemoveEntityOnEmpty;
        [DefaultValue((string) null), ProtoMember(40)]
        public SerializableVector3? Size = null;
        [DefaultValue((string) null), ProtoMember(30)]
        public MyFixedPoint? Volume = null;

        public override void Clear()
        {
            this.Items.Clear();
            this.nextItemId = 0;
            base.Clear();
        }

        public bool ShouldSerializeMaxItemCount() => 
            this.MaxItemCount.HasValue;
    }
}

