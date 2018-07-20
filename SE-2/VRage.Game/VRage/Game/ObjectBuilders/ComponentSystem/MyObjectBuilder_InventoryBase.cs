namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_InventoryBase : MyObjectBuilder_ComponentBase
    {
        [DefaultValue((string) null), ProtoMember(13), Serialize(MyObjectFlags.DefaultZero)]
        public string InventoryId;

        public virtual void Clear()
        {
        }
    }
}

