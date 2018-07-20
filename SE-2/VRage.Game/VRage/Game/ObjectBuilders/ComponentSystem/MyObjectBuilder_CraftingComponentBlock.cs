namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CraftingComponentBlock : MyObjectBuilder_CraftingComponentBase
    {
        [ProtoMember(12)]
        public List<MyObjectBuilder_InventoryItem> InsertedItems = new List<MyObjectBuilder_InventoryItem>();
        [ProtoMember(15)]
        public float InsertedItemUseLevel;
    }
}

