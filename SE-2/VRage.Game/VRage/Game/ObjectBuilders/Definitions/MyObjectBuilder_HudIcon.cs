namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game.GUI;
    using VRage.ObjectBuilders;
    using VRage.Utils;
    using VRageMath;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_HudIcon : MyObjectBuilder_Base
    {
        public MyAlphaBlinkBehavior Blink;
        public MyGuiDrawAlignEnum? OriginAlign;
        public Vector2 Position;
        public Vector2? Size;
        public MyStringHash Texture;
    }
}

