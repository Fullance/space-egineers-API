namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_StockpileItem : MyObjectBuilder_Base
    {
        [ProtoMember(12)]
        public int Amount;
        [Nullable, DynamicObjectBuilder(false), ProtoMember(15)]
        public MyObjectBuilder_PhysicalObject PhysicalContent;
    }
}

