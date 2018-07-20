namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ModAPI;
    using VRage.ObjectBuilders;
    using VRage.Serialization;
    using VRageMath;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public abstract class MyObjectBuilder_ProjectorBase : MyObjectBuilder_FunctionalBlock
    {
        [ProtoMember(0x22)]
        public bool GetOwnershipFromProjector;
        [ProtoMember(0x1a)]
        public bool InstantBuildingEnabled;
        [ProtoMember(0x16)]
        public bool KeepProjection;
        [ProtoMember(30)]
        public int MaxNumberOfBlocks = 200;
        [ProtoMember(0x1c)]
        public int MaxNumberOfProjections = 5;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(15)]
        public MyObjectBuilder_CubeGrid ProjectedGrid;
        [ProtoMember(0x12)]
        public Vector3I ProjectionOffset;
        [ProtoMember(20)]
        public Vector3I ProjectionRotation;
        [ProtoMember(0x20)]
        public int ProjectionsRemaining;
        [ProtoMember(0x18)]
        public bool ShowOnlyBuildable;

        protected MyObjectBuilder_ProjectorBase()
        {
        }

        public override void Remap(IMyRemapHelper remapHelper)
        {
            base.Remap(remapHelper);
            if (this.ProjectedGrid != null)
            {
                this.ProjectedGrid.Remap(remapHelper);
            }
        }
    }
}

