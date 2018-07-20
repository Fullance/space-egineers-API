namespace VRage.Game
{
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyVoxelMapModifierChange
    {
        [XmlAttribute(AttributeName="From")]
        public string From;
        [XmlAttribute(AttributeName="To")]
        public string To;
    }
}

