namespace VRage.Game
{
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRageMath;
    using VRageRender;

    [StructLayout(LayoutKind.Sequential)]
    public struct MySunProperties
    {
        [StructDefault]
        public static readonly MySunProperties Default;
        public float SunIntensity;
        [XmlElement(Type=typeof(MyStructXmlSerializer<MyEnvironmentLightData>))]
        public MyEnvironmentLightData EnvironmentLight;
        [XmlElement(Type=typeof(MyStructXmlSerializer<MyEnvironmentProbeData>))]
        public MyEnvironmentProbeData EnvironmentProbe;
        [XmlElement(Type=typeof(MyStructXmlSerializer<MyTextureDebugMultipliers>))]
        public MyTextureDebugMultipliers TextureMultipliers;
        public Vector3 BaseSunDirectionNormalized;
        public Vector3 SunDirectionNormalized;
        public int EnvMapResolution;
        public int EnvMapFilteredResolution;
        static MySunProperties()
        {
            MySunProperties properties = new MySunProperties {
                SunIntensity = 1f,
                EnvironmentLight = MyEnvironmentLightData.Default,
                EnvironmentProbe = MyEnvironmentProbeData.Default,
                SunDirectionNormalized = Defaults.SunDirectionNormalized,
                BaseSunDirectionNormalized = Defaults.BaseSunDirectionNormalized,
                TextureMultipliers = MyTextureDebugMultipliers.Defaults,
                EnvMapResolution = 0x200,
                EnvMapFilteredResolution = 0x100
            };
            Default = properties;
        }

        public MyEnvironmentData EnvironmentData
        {
            get
            {
                MyEnvironmentData data = new MyEnvironmentData {
                    EnvironmentLight = this.EnvironmentLight,
                    EnvironmentProbe = this.EnvironmentProbe,
                    TextureMultipliers = this.TextureMultipliers,
                    EnvMapResolution = this.EnvMapResolution,
                    EnvMapFilteredResolution = this.EnvMapFilteredResolution
                };
                data.EnvironmentLight.SunColorRaw = (Vector3) (this.EnvironmentLight.SunColorRaw * this.SunIntensity);
                return data;
            }
        }
        public Vector3 SunRotationAxis
        {
            get
            {
                Vector3 vector;
                if (Math.Abs(Vector3.Dot(this.BaseSunDirectionNormalized, Vector3.Up)) > 0.95f)
                {
                    vector = Vector3.Cross(Vector3.Cross(this.BaseSunDirectionNormalized, Vector3.Left), this.BaseSunDirectionNormalized);
                }
                else
                {
                    vector = Vector3.Cross(Vector3.Cross(this.BaseSunDirectionNormalized, Vector3.Up), this.BaseSunDirectionNormalized);
                }
                vector.Normalize();
                return vector;
            }
        }
        private static class Defaults
        {
            public static readonly Vector3 BaseSunDirectionNormalized = new Vector3(0.3394673f, 0.7097954f, -0.6172134f);
            public const int EnvMapFilteredResolution = 0x100;
            public const int EnvMapResolution = 0x200;
            public static readonly Vector3 SunDirectionNormalized = new Vector3(0.3394673f, 0.7097954f, -0.6172134f);
            public const float SunIntensity = 1f;
        }
    }
}

