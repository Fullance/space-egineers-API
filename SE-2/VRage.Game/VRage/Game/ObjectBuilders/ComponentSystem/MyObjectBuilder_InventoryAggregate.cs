namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_InventoryAggregate : MyObjectBuilder_InventoryBase
    {
        [DefaultValue((string) null), DynamicNullableObjectBuilderItem(false), ProtoMember(15), XmlArrayItem("MyObjectBuilder_InventoryBase", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_InventoryBase>)), Serialize(MyObjectFlags.DefaultZero)]
        public List<MyObjectBuilder_InventoryBase> Inventories;

        public override void Clear()
        {
            foreach (MyObjectBuilder_InventoryBase base2 in this.Inventories)
            {
                base2.Clear();
            }
        }
    }
}

