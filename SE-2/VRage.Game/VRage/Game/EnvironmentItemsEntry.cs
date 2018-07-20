namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [ProtoContract]
    public class EnvironmentItemsEntry
    {
        [DefaultValue(true), ProtoMember(0x16)]
        public bool Enabled = true;
        [XmlAttribute, ProtoMember(0x19)]
        public float Frequency = 1f;
        [ProtoMember(0x12), XmlAttribute]
        public string ItemSubtype;
        [ProtoMember(14), XmlAttribute]
        public string Subtype;
        [XmlAttribute, ProtoMember(10)]
        public string Type;

        public override bool Equals(object other)
        {
            EnvironmentItemsEntry entry = other as EnvironmentItemsEntry;
            return ((((entry != null) && entry.Type.Equals(this.Type)) && entry.Subtype.Equals(this.Subtype)) && entry.ItemSubtype.Equals(this.ItemSubtype));
        }

        public override int GetHashCode() => 
            (((this.Type.GetHashCode() * 0x180005) ^ (this.Subtype.GetHashCode() * 0xc005)) ^ this.ItemSubtype.GetHashCode());
    }
}

