namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ModAPI;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_CubeGrid : MyObjectBuilder_EntityBase
    {
        [ProtoMember(40), Serialize(MyObjectFlags.DefaultZero)]
        public SerializableVector3 AngularVelocity;
        [ProtoMember(0x59)]
        public List<MyObjectBuilder_BlockGroup> BlockGroups = new List<MyObjectBuilder_BlockGroup>();
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x54)]
        public List<MyObjectBuilder_ConveyorLine> ConveyorLines = new List<MyObjectBuilder_ConveyorLine>();
        [DefaultValue(true), ProtoMember(0x7f)]
        public bool CreatePhysics = true;
        [ProtoMember(0x13), XmlArrayItem("MyObjectBuilder_CubeBlock", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_CubeBlock>)), DynamicItem(typeof(MyObjectBuilderDynamicSerializer), true)]
        public List<MyObjectBuilder_CubeBlock> CubeBlocks = new List<MyObjectBuilder_CubeBlock>();
        [DefaultValue(true), ProtoMember(0x45)]
        public bool DampenersEnabled = true;
        [ProtoMember(0x68)]
        public bool DestructibleBlocks = true;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x60)]
        public string DisplayName;
        [DefaultValue(true), ProtoMember(0x95)]
        public bool Editable = true;
        [DefaultValue(true), ProtoMember(0x83)]
        public bool EnableSmallToLargeConnections = true;
        [DefaultValue((float) 1f), ProtoMember(0x8e)]
        public float GridGeneralDamageModifier = 1f;
        [ProtoMember(0x11)]
        public MyCubeSize GridSizeEnum;
        [DefaultValue(false), ProtoMember(0x5d)]
        public bool Handbrake;
        [DefaultValue(true), ProtoMember(0xa2, IsRequired=false)]
        public bool IsPowered = true;
        [ProtoMember(0x87)]
        public bool IsRespawnGrid;
        [DefaultValue(false), ProtoMember(0x18)]
        public bool IsStatic;
        [DefaultValue(false), ProtoMember(0x1b)]
        public bool IsUnsupportedStation;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x75)]
        public Vector3D? JumpDriveDirection;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x7a)]
        public float? JumpRemainingTime;
        [ProtoMember(0x23), Serialize(MyObjectFlags.DefaultZero)]
        public SerializableVector3 LinearVelocity;
        [ProtoMember(0x92)]
        public long LocalCoordSys;
        [ProtoMember(100), Serialize(MyObjectFlags.DefaultZero)]
        public float[] OxygenAmount;
        [DefaultValue((float) 0.3f), ProtoMember(0x4b)]
        public float PlanetSpawnHeightRatio = 0.3f;
        [ProtoMember(0x8a), DefaultValue(-1)]
        public int playedTime = -1;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(30)]
        public List<BoneInfo> Skeleton;
        [ProtoMember(0x51), DefaultValue((float) 650f)]
        public float SpawnRangeMax = 650f;
        [ProtoMember(0x4e), DefaultValue((float) 500f)]
        public float SpawnRangeMin = 500f;
        [ProtoMember(0x99), Serialize(MyObjectFlags.DefaultZero)]
        public List<long> TargetingTargets = new List<long>();
        [ProtoMember(0x9d), DefaultValue(false)]
        public bool TargetingWhitelist;
        [ProtoMember(0x48), DefaultValue(false)]
        public bool UsePositionForSpawn;
        [DefaultValue(false), ProtoMember(60)]
        public bool XMirroxOdd;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x2d)]
        public SerializableVector3I? XMirroxPlane;
        [ProtoMember(0x3f), DefaultValue(false)]
        public bool YMirroxOdd;
        [ProtoMember(50), Serialize(MyObjectFlags.DefaultZero)]
        public SerializableVector3I? YMirroxPlane;
        [DefaultValue(false), ProtoMember(0x42)]
        public bool ZMirroxOdd;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x37)]
        public SerializableVector3I? ZMirroxPlane;

        public override void Remap(IMyRemapHelper remapHelper)
        {
            base.Remap(remapHelper);
            foreach (MyObjectBuilder_CubeBlock block in this.CubeBlocks)
            {
                block.Remap(remapHelper);
            }
        }

        public bool ShouldSerializeAngularVelocity() => 
            (this.AngularVelocity != new SerializableVector3(0f, 0f, 0f));

        public bool ShouldSerializeBlockGroups() => 
            ((this.BlockGroups != null) && (this.BlockGroups.Count != 0));

        public bool ShouldSerializeConveyorLines() => 
            ((this.ConveyorLines != null) && (this.ConveyorLines.Count != 0));

        public bool ShouldSerializeJumpDriveDirection() => 
            this.JumpDriveDirection.HasValue;

        public bool ShouldSerializeJumpRemainingTime() => 
            this.JumpRemainingTime.HasValue;

        public bool ShouldSerializeLinearVelocity() => 
            (this.LinearVelocity != new SerializableVector3(0f, 0f, 0f));

        public bool ShouldSerializeSkeleton() => 
            ((this.Skeleton != null) && (this.Skeleton.Count != 0));

        public bool ShouldSerializeXMirroxPlane() => 
            this.XMirroxPlane.HasValue;

        public bool ShouldSerializeYMirroxPlane() => 
            this.YMirroxPlane.HasValue;

        public bool ShouldSerializeZMirroxPlane() => 
            this.ZMirroxPlane.HasValue;
    }
}

