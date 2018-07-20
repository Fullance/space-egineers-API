namespace VRage.Game.ObjectBuilders
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_PlanetTextureMapProvider : MyObjectBuilder_PlanetMapProvider
    {
        [XmlAttribute]
        public string Path;
    }
}

