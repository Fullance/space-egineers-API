namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Game.ObjectBuilders.ComponentSystem;
    using VRage.ModAPI;
    using VRage.ObjectBuilders;
    using VRage.Serialization;
    using VRage.Utils;
    using VRageMath;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CubeBlock : MyObjectBuilder_Base
    {
        [Serialize, ProtoMember(0x9d), DefaultValue((float) 1f)]
        public float BlockGeneralDamageModifier = 1f;
        [ProtoMember(0x40)]
        public SerializableBlockOrientation BlockOrientation = SerializableBlockOrientation.Identity;
        [DefaultValue((float) 1f), ProtoMember(60), Serialize(MyPrimitiveFlags.FixedPoint16 | MyPrimitiveFlags.Normalized)]
        public float BuildPercent = 1f;
        [ProtoMember(0x6c), DefaultValue(0), Serialize(MyObjectFlags.DefaultZero)]
        public long BuiltBy;
        [ProtoMember(0x49)]
        public SerializableVector3 ColorMaskHSV = new SerializableVector3(0f, -1f, 0f);
        [Serialize(MyObjectFlags.DefaultZero), DefaultValue((string) null), ProtoMember(0xa1)]
        public MyObjectBuilder_ComponentContainer ComponentContainer;
        [NoSerialize, ProtoMember(0x44), DefaultValue((string) null)]
        public MyObjectBuilder_Inventory ConstructionInventory;
        [ProtoMember(0x63), Serialize(MyObjectFlags.DefaultZero), DefaultValue((string) null)]
        public MyObjectBuilder_ConstructionStockpile ConstructionStockpile;
        [NoSerialize, ProtoMember(0x79), DefaultValue(0)]
        public float DeformationRatio;
        [Serialize(MyObjectFlags.DefaultZero), DefaultValue(0), ProtoMember(0x13)]
        public long EntityId;
        [Serialize(MyPrimitiveFlags.FixedPoint16 | MyPrimitiveFlags.Normalized), ProtoMember(0x38), DefaultValue((float) 1f)]
        public float IntegrityPercent = 1f;
        private SerializableQuaternion m_orientation;
        [ProtoMember(0x1d), Serialize(MyPrimitiveFlags.Variant, Kind=MySerializeKind.Item)]
        public SerializableVector3I Min = new SerializableVector3I(0, 0, 0);
        [ProtoMember(0x94), DefaultValue((string) null), Serialize(MyObjectFlags.DefaultZero)]
        public SerializableDefinitionId? MultiBlockDefinition = null;
        [ProtoMember(0x8f), Serialize(MyObjectFlags.DefaultZero), DefaultValue(0)]
        public int MultiBlockId;
        [DefaultValue(-1), ProtoMember(0x99), Serialize]
        public int MultiBlockIndex = -1;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x19)]
        public string Name;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x68), DefaultValue(0)]
        public long Owner;
        [DefaultValue(0), ProtoMember(0x76)]
        public MyOwnershipShareModeEnum ShareMode;
        [DefaultValue((string) null), Serialize(MyObjectFlags.DefaultZero), XmlArrayItem("SubBlock"), ProtoMember(0x8b)]
        public MySubBlockId[] SubBlocks;

        public virtual void Remap(IMyRemapHelper remapHelper)
        {
            if (this.EntityId != 0L)
            {
                this.EntityId = remapHelper.RemapEntityId(this.EntityId);
            }
            if (this.SubBlocks != null)
            {
                for (int i = 0; i < this.SubBlocks.Length; i++)
                {
                    if (this.SubBlocks[i].SubGridId != 0L)
                    {
                        this.SubBlocks[i].SubGridId = remapHelper.RemapEntityId(this.SubBlocks[i].SubGridId);
                    }
                }
            }
            if ((this.MultiBlockId != 0) && this.MultiBlockDefinition.HasValue)
            {
                this.MultiBlockId = remapHelper.RemapGroupId("MultiBlockId", this.MultiBlockId);
            }
        }

        public virtual void SetupForProjector()
        {
            this.Owner = 0L;
            this.ShareMode = MyOwnershipShareModeEnum.None;
        }

        public bool ShouldSerializeBlockOrientation() => 
            (this.BlockOrientation != SerializableBlockOrientation.Identity);

        public bool ShouldSerializeColorMaskHSV() => 
            (this.ColorMaskHSV != new SerializableVector3(0f, -1f, 0f));

        public bool ShouldSerializeComponentContainer() => 
            (((this.ComponentContainer != null) && (this.ComponentContainer.Components != null)) && (this.ComponentContainer.Components.Count > 0));

        public bool ShouldSerializeConstructionInventory() => 
            false;

        public bool ShouldSerializeConstructionStockpile() => 
            (this.ConstructionStockpile != null);

        public bool ShouldSerializeEntityId() => 
            (this.EntityId != 0L);

        public bool ShouldSerializeMin() => 
            (this.Min != new SerializableVector3I(0, 0, 0));

        public bool ShouldSerializeMultiBlockDefinition() => 
            ((this.MultiBlockId != 0) && this.MultiBlockDefinition.HasValue);

        public bool ShouldSerializeMultiBlockId() => 
            (this.MultiBlockId != 0);

        public bool ShouldSerializeOrientation() => 
            false;

        public static MyObjectBuilder_CubeBlock Upgrade(MyObjectBuilder_CubeBlock cubeBlock, MyObjectBuilderType newType, string newSubType)
        {
            MyObjectBuilder_CubeBlock block = MyObjectBuilderSerializer.CreateNewObject(newType, newSubType) as MyObjectBuilder_CubeBlock;
            if (block == null)
            {
                return null;
            }
            block.EntityId = cubeBlock.EntityId;
            block.Min = cubeBlock.Min;
            block.m_orientation = cubeBlock.m_orientation;
            block.IntegrityPercent = cubeBlock.IntegrityPercent;
            block.BuildPercent = cubeBlock.BuildPercent;
            block.BlockOrientation = cubeBlock.BlockOrientation;
            block.ConstructionInventory = cubeBlock.ConstructionInventory;
            block.ColorMaskHSV = cubeBlock.ColorMaskHSV;
            return block;
        }

        [NoSerialize]
        public SerializableQuaternion Orientation
        {
            get => 
                this.m_orientation;
            set
            {
                if (!MyUtils.IsZero((Quaternion) value, 1E-05f))
                {
                    this.m_orientation = value;
                }
                else
                {
                    this.m_orientation = Quaternion.Identity;
                }
                this.BlockOrientation = new SerializableBlockOrientation(Base6Directions.GetForward((Quaternion) this.m_orientation), Base6Directions.GetUp((Quaternion) this.m_orientation));
            }
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct MySubBlockId
        {
            [ProtoMember(0x80)]
            public long SubGridId;
            [ProtoMember(0x83)]
            public string SubGridName;
            [ProtoMember(0x86)]
            public SerializableVector3I SubBlockPosition;
        }
    }
}

