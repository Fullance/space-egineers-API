namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class MyPlanetOreMapping
    {
        [XmlIgnore, ProtoMember(0xec)]
        public ColorDefinitionRGBA? ColorShift;
        [ProtoMember(0xe8), XmlAttribute(AttributeName="Depth")]
        public float Depth = 10f;
        private float? m_colorInfluence;
        [XmlAttribute(AttributeName="Start"), ProtoMember(0xe4)]
        public float Start = 5f;
        [ProtoMember(0xe0), XmlAttribute(AttributeName="Type")]
        public string Type;
        [XmlAttribute(AttributeName="Value"), ProtoMember(220)]
        public byte Value;

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }
            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != base.GetType())
            {
                return false;
            }
            return this.Equals((MyPlanetOreMapping) obj);
        }

        protected bool Equals(MyPlanetOreMapping other) => 
            (this.Value == other.Value);

        public override int GetHashCode() => 
            this.Value.GetHashCode();

        [XmlAttribute("ColorInfluence"), ProtoMember(0xf6)]
        public float ColorInfluence
        {
            get
            {
                float? colorInfluence = this.m_colorInfluence;
                if (!colorInfluence.HasValue)
                {
                    return 0f;
                }
                return colorInfluence.GetValueOrDefault();
            }
            set
            {
                this.m_colorInfluence = new float?(value);
            }
        }

        [XmlAttribute("TargetColor"), ProtoMember(240)]
        public string TargetColor
        {
            get
            {
                if (!this.ColorShift.HasValue)
                {
                    return null;
                }
                return this.ColorShift.Value.Hex;
            }
            set
            {
                this.ColorShift = new ColorDefinitionRGBA(value);
            }
        }
    }
}

