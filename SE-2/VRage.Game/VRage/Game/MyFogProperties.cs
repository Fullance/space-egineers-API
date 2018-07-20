namespace VRage.Game
{
    using System;
    using System.Runtime.InteropServices;
    using VRage;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyFogProperties
    {
        [StructDefault]
        public static readonly MyFogProperties Default;
        public float FogMultiplier;
        public float FogDensity;
        public Vector3 FogColor;
        static MyFogProperties()
        {
            MyFogProperties properties = new MyFogProperties {
                FogMultiplier = 0.13f,
                FogDensity = 0.003f,
                FogColor = Defaults.FogColor
            };
            Default = properties;
        }
        private static class Defaults
        {
            public static readonly Vector3 FogColor = new Vector3(0f, 0f, 0f);
            public const float FogDensity = 0.003f;
            public const float FogMultiplier = 0.13f;
        }
    }
}

