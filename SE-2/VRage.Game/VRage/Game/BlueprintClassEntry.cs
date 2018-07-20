namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class BlueprintClassEntry
    {
        [XmlAttribute, ProtoMember(0x1b)]
        public string BlueprintSubtypeId;
        [ProtoMember(12), XmlAttribute]
        public string Class;
        [DefaultValue(true), ProtoMember(0x1f)]
        public bool Enabled = true;
        [XmlIgnore]
        public MyObjectBuilderType TypeId;

        public override bool Equals(object other)
        {
            BlueprintClassEntry entry = other as BlueprintClassEntry;
            return (((entry != null) && entry.Class.Equals(this.Class)) && entry.BlueprintSubtypeId.Equals(this.BlueprintSubtypeId));
        }

        public override int GetHashCode() => 
            ((this.Class.GetHashCode() * 0x1db7) + this.BlueprintSubtypeId.GetHashCode());

        [ProtoMember(0x13), XmlAttribute]
        public string BlueprintTypeId
        {
            get => 
                this.TypeId.ToString();
            set
            {
                this.TypeId = MyObjectBuilderType.ParseBackwardsCompatible(value);
            }
        }
    }
}

