namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_HudDefinition : MyObjectBuilder_DefinitionBase
    {
        public MyObjectBuilder_CrosshairStyle Crosshair;
        public float? CustomUIScale;
        public MyObjectBuilder_GravityIndicatorVisualStyle GravityIndicator;
        public Vector2I? OptimalScreenRatio;
        [XmlArrayItem("StatControl", typeof(MyAbstractXmlSerializer<MyObjectBuilder_StatControls>))]
        public MyObjectBuilder_StatControls[] StatControls;
        public MyObjectBuilder_ToolbarControlVisualStyle Toolbar;
        public MyStringHash? VisorOverlayTexture;
    }
}

