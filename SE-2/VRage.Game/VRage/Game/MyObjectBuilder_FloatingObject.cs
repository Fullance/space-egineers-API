namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_FloatingObject : MyObjectBuilder_EntityBase
    {
        [ProtoMember(13)]
        public MyObjectBuilder_InventoryItem Item;
        [ProtoMember(0x10), DefaultValue(0)]
        public int ModelVariant;
        [DefaultValue((string) null), Serialize(MyObjectFlags.DefaultZero), ProtoMember(20)]
        public string OreSubtypeId;

        public bool ShouldSerializeModelVariant() => 
            (this.ModelVariant != 0);
    }
}

