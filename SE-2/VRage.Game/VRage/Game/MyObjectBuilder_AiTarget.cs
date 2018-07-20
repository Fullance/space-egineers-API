namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_AiTarget : MyObjectBuilder_Base
    {
        [ProtoMember(0x2a)]
        public ushort? CompoundId = null;
        [ProtoMember(0x24)]
        public MyAiTargetEnum CurrentTarget;
        [ProtoMember(0x27)]
        public long? EntityId = null;
        [ProtoMember(0x2d)]
        public Vector3I TargetCube = Vector3I.Zero;
        [ProtoMember(0x30)]
        public Vector3D TargetPosition = Vector3D.Zero;
        [ProtoMember(0x33)]
        public List<UnreachableEntitiesData> UnreachableEntities;

        [ProtoContract]
        public class UnreachableEntitiesData
        {
            [ProtoMember(0x20)]
            public int Timeout;
            [ProtoMember(0x1d)]
            public long UnreachableEntityId;
        }
    }
}

