namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyPlanetMaterialLayer
    {
        [XmlAttribute(AttributeName="Material"), ProtoMember(0x15)]
        public string Material;
        [ProtoMember(0x19), XmlAttribute(AttributeName="Depth")]
        public float Depth;
    }
}

