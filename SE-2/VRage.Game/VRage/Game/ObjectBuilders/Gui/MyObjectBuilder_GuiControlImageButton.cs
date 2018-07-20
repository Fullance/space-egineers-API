namespace VRage.Game.ObjectBuilders.Gui
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_GuiControlImageButton : MyObjectBuilder_GuiControlBase
    {
        public bool DrawCrossTextureWhenDisabled;
        public bool DrawRedTextureWhenDisabled;
        public string Text;
        public int TextAlignment;
        public string TextEnum;
        public float TextScale;
    }
}

