namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Game.GUI;
    using VRage.ObjectBuilders;
    using VRage.Utils;
    using VRageMath;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_StatVisualStyle : MyObjectBuilder_Base
    {
        public MyAlphaBlinkBehavior Blink;
        [XmlElement(typeof(MyAbstractXmlSerializer<ConditionBase>))]
        public ConditionBase BlinkCondition;
        public VisualStyleCategory? Category;
        public uint? FadeInTimeMs;
        public uint? FadeOutTimeMs;
        public uint? MaxOnScreenTimeMs;
        public Vector2 OffsetPx;
        public Vector2 SizePx;
        public MyStringHash StatId;
        [XmlElement(typeof(MyAbstractXmlSerializer<ConditionBase>))]
        public ConditionBase VisibleCondition;
    }
}

