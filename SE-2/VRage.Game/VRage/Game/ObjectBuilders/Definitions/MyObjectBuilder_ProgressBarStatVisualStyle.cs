namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Utils;
    using VRageMath;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ProgressBarStatVisualStyle : MyObjectBuilder_StatVisualStyle
    {
        public bool? Inverted;
        public NineTiledData? NineTiledStyle;
        public SimpleBarData? SimpleStyle;

        [StructLayout(LayoutKind.Sequential)]
        public struct NineTiledData
        {
            public MyStringHash Texture;
            public Vector4? ColorMask;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SimpleBarData
        {
            public MyStringHash BackgroundTexture;
            public MyStringHash ProgressTexture;
            public Vector4? BackgroundColorMask;
            public Vector4? ProgressColorMask;
            public Vector2I ProgressTextureOffsetPx;
        }
    }
}

