namespace VRage.Game.ObjectBuilders.Definitions.GUI
{
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ButtonListStyleDefinition : MyObjectBuilder_DefinitionBase
    {
        public SerializableVector2 ButtonMargin = new Vector2(10f, 10f);
        public SerializableVector2 ButtonSize = new Vector2(75f, 75f);
        [XmlAttribute]
        public string StyleName;
    }
}

