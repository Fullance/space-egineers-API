namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_GuiTextureAtlasDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlArrayItem("CompositeTexture")]
        public MyObjectBuilder_CompositeTexture[] CompositeTextures;
        [XmlArrayItem("Texture")]
        public MyObjectBuilder_GuiTexture[] Textures;
    }
}

