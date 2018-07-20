namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_TextStatVisualStyle : MyObjectBuilder_StatVisualStyle
    {
        public Vector4? ColorMask;
        public string Font;
        public float Scale;
        public string Text;
        public MyGuiDrawAlignEnum? TextAlign;
    }
}

