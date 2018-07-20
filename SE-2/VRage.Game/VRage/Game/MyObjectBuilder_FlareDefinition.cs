namespace VRage.Game
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageRender.Messages;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_FlareDefinition : MyObjectBuilder_DefinitionBase
    {
        public float? Intensity;
        public Vector2? Size;
        [XmlArrayItem("SubGlare")]
        public MySubGlare[] SubGlares;
    }
}

