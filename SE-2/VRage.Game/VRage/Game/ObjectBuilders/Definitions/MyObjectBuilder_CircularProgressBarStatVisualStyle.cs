namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Utils;
    using VRageMath;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CircularProgressBarStatVisualStyle : MyObjectBuilder_StatVisualStyle
    {
        public float? AngleOffset;
        public bool? Animate;
        public Vector4? AnimatedSegmentColorMask;
        public double? AnimationDelayMs;
        public double? AnimationSegmentDelayMs;
        public MyStringHash? BackgroudTexture;
        public Vector4? EmptySegmentColorMask;
        public Vector4? FullSegmentColorMask;
        public int? NumberOfSegments;
        public Vector2? SegmentOrigin;
        public Vector2 SegmentSizePx;
        public MyStringHash SegmentTexture;
        public bool? ShowEmptySegments;
        public float? SpacingAngle;
    }
}

