namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_InventoryItem : MyObjectBuilder_Base
    {
        [XmlElement("Amount"), ProtoMember(13)]
        public MyFixedPoint Amount = 1;
        [ProtoMember(0x22), Serialize(MyObjectFlags.DefaultZero), DynamicObjectBuilder(false), XmlElement(Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_PhysicalObject>))]
        public MyObjectBuilder_PhysicalObject Content;
        [ProtoMember(0x30)]
        public uint ItemId;
        [DynamicObjectBuilder(false), Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x2a), XmlElement(Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_PhysicalObject>))]
        public MyObjectBuilder_PhysicalObject PhysicalContent;
        [XmlElement("Scale"), ProtoMember(0x11)]
        public float Scale = 1f;

        public bool ShouldSerializeContent() => 
            false;

        public bool ShouldSerializeObsolete_AmountDecimal() => 
            false;

        public bool ShouldSerializeScale() => 
            !(this.Scale == 1f);

        [XmlElement("AmountDecimal"), NoSerialize]
        public decimal Obsolete_AmountDecimal
        {
            get => 
                ((decimal) this.Amount);
            set
            {
                this.Amount = (MyFixedPoint) value;
            }
        }
    }
}

