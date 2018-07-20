namespace VRage.Game
{
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRageRender;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), XmlType("VisualSettingsDefinition")]
    public class MyObjectBuilder_VisualSettingsDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlElement(Type=typeof(MyStructXmlSerializer<MyFogProperties>))]
        public MyFogProperties FogProperties = MyFogProperties.Default;
        [XmlElement(Type=typeof(MyStructXmlSerializer<MyPostprocessSettings>))]
        public MyPostprocessSettings PostProcessSettings = MyPostprocessSettings.Default;
        public MyShadowsSettings ShadowSettings = new MyShadowsSettings();
        [XmlElement(Type=typeof(MyStructXmlSerializer<MySunProperties>))]
        public MySunProperties SunProperties = MySunProperties.Default;
    }
}

