namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Data;
    using VRage.ObjectBuilders;
    using VRageMath;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_PhysicalItemDefinition : MyObjectBuilder_DefinitionBase
    {
        [DefaultValue(true), ProtoMember(0x2e)]
        public bool CanSpawnFromScreen = true;
        [DefaultValue((string) null), ProtoMember(0x3e)]
        public SerializableDefinitionId? DestroyedPieceId = null;
        [ProtoMember(0x41)]
        public int DestroyedPieces;
        [ProtoMember(0x44), DefaultValue((string) null)]
        public string ExtraInventoryTooltipLine;
        [ProtoMember(0x3b)]
        public int Health = 100;
        [DefaultValue((string) null), ProtoMember(30)]
        public string IconSymbol;
        [ProtoMember(0x12)]
        public float Mass;
        [ProtoMember(0x47)]
        public MyFixedPoint MaxStackAmount = MyFixedPoint.MaxValue;
        [ProtoMember(0x15), ModdableContentFile("mwm")]
        public string Model = @"Models\Components\Sphere.mwm";
        [ProtoMember(0x19), XmlArrayItem("Model"), ModdableContentFile("mwm")]
        public string[] Models;
        [ProtoMember(0x25), DefaultValue((string) null)]
        public float? ModelVolume = null;
        [ProtoMember(40)]
        public string PhysicalMaterial;
        [ProtoMember(50)]
        public bool RotateOnSpawnX;
        [ProtoMember(0x35)]
        public bool RotateOnSpawnY;
        [ProtoMember(0x38)]
        public bool RotateOnSpawnZ;
        [ProtoMember(15)]
        public Vector3 Size;
        [ProtoMember(0x22), DefaultValue((string) null)]
        public float? Volume = null;
        [ProtoMember(0x2b)]
        public string VoxelMaterial;

        public bool ShouldSerializeIconSymbol() => 
            (this.IconSymbol != null);
    }
}

