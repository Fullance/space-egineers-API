namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class BlueprintItem
    {
        [XmlAttribute, ProtoMember(0x22)]
        public string Amount;
        [XmlIgnore, ProtoMember(12)]
        public SerializableDefinitionId Id;

        [XmlAttribute]
        public string SubtypeId
        {
            get => 
                this.Id.SubtypeId;
            set
            {
                this.Id.SubtypeId = value;
            }
        }

        [XmlAttribute]
        public string TypeId
        {
            get
            {
                if (this.Id.TypeId.IsNull)
                {
                    return "(null)";
                }
                return this.Id.TypeId.ToString();
            }
            set
            {
                this.Id.TypeId = MyObjectBuilderType.ParseBackwardsCompatible(value);
            }
        }
    }
}

