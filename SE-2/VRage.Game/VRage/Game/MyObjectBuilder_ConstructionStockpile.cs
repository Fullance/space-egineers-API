namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ConstructionStockpile : MyObjectBuilder_Base
    {
        [ProtoMember(12), XmlElement(Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_StockpileItem>))]
        public MyObjectBuilder_StockpileItem[] Items = new MyObjectBuilder_StockpileItem[0];
    }
}

