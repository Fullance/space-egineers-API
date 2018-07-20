namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class MyPlanetAtmosphere
    {
        [ProtoMember(0x211), XmlElement]
        public bool Breathable;
        [ProtoMember(0x219), XmlElement]
        public float Density = 1f;
        [XmlElement, ProtoMember(0x21d)]
        public float LimitAltitude = 2f;
        [XmlElement, ProtoMember(0x215)]
        public float OxygenDensity = 1f;
    }
}

