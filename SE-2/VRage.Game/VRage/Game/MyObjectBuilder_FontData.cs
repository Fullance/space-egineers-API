namespace VRage.Game
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_FontData : MyObjectBuilder_Base
    {
        [XmlAttribute]
        public string Path;
        [XmlAttribute]
        public uint Size;
    }
}

