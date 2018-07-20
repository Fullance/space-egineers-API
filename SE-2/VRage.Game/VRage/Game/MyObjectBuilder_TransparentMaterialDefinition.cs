namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Data;
    using VRage.ObjectBuilders;
    using VRageMath;
    using VRageRender;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_TransparentMaterialDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x4e)]
        public bool AlphaCutout;
        [ProtoMember(0x1b)]
        public bool AlphaMistingEnable;
        [ProtoMember(0x24)]
        public float AlphaMistingEnd;
        [ProtoMember(0x21)]
        public float AlphaMistingStart;
        [ProtoMember(0x2a)]
        public float AlphaSaturation;
        [ProtoMember(0x18)]
        public bool CanBeAffectedByOtherLights;
        [ProtoMember(0x2d)]
        public Vector4 Color = Vector4.One;
        [ProtoMember(0x30)]
        public Vector4 ColorAdd = Vector4.Zero;
        [ProtoMember(60)]
        public float Fresnel = 1f;
        [ProtoMember(0x42)]
        public float Gloss = 0.4f;
        [ProtoMember(0x12), ModdableContentFile("dds")]
        public string GlossTexture;
        [ProtoMember(0x45)]
        public float GlossTextureAdd = 0.55f;
        [ProtoMember(0x4b)]
        public bool IsFlareOccluder;
        [ProtoMember(0x36)]
        public Vector4 LightMultiplier = ((Vector4) (Vector4.One * 0.1f));
        [ProtoMember(0x3f)]
        public float ReflectionShadow = 0.1f;
        [ProtoMember(0x39)]
        public float Reflectivity = 0.6f;
        [ProtoMember(0x33)]
        public Vector4 ShadowMultiplier = Vector4.Zero;
        [ProtoMember(0x27)]
        public float SoftParticleDistanceScale;
        [ProtoMember(0x48)]
        public float SpecularColorFactor = 20f;
        [ProtoMember(0x51)]
        public Vector2I TargetSize = new Vector2I(-1, -1);
        [ModdableContentFile("dds"), ProtoMember(15)]
        public string Texture;
        [ProtoMember(0x15)]
        public MyTransparentMaterialTextureType TextureType;
        [ProtoMember(30)]
        public bool UseAtlas;
    }
}

