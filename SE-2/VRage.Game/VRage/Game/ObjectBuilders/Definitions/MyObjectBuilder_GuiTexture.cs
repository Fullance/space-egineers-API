namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Xml.Serialization;
    using VRage.Data;
    using VRage.ObjectBuilders;
    using VRageMath;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_GuiTexture : MyObjectBuilder_Base
    {
        [ModdableContentFile(new string[] { "dds", "png" })]
        public string Path;
        [XmlIgnore]
        public Vector2I SizePx;
    }
}

