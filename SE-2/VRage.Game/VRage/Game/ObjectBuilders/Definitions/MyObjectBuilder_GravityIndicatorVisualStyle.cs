namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRage.Utils;
    using VRageMath;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_GravityIndicatorVisualStyle : MyObjectBuilder_Base
    {
        public MyStringHash FillTexture;
        public Vector2 OffsetPx;
        public MyGuiDrawAlignEnum OriginAlign;
        public MyStringHash OverlayTexture;
        public Vector2 SizePx;
        public Vector2 VelocitySizePx;
        public MyStringHash VelocityTexture;
        [XmlElement(typeof(MyAbstractXmlSerializer<ConditionBase>))]
        public ConditionBase VisibleCondition;
    }
}

