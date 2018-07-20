namespace VRage.Game
{
    using System;
    using System.Xml.Serialization;

    public class MyVoxelMapModifierOption
    {
        [XmlAttribute(AttributeName="Chance")]
        public float Chance;
        [XmlElement("Change")]
        public MyVoxelMapModifierChange[] Changes;
    }
}

