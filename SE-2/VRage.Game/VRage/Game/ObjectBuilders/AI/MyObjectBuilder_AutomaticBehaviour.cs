namespace VRage.Game.ObjectBuilders.AI
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_AutomaticBehaviour : MyObjectBuilder_Base
    {
        [ProtoMember(0x2c)]
        public bool CollisionAvoidance = true;
        [ProtoMember(0x3b)]
        public long CurrentTarget;
        [ProtoMember(0x35)]
        public bool CycleWaypoints;
        [ProtoMember(0x38)]
        public bool InAmbushMode;
        [ProtoMember(0x29)]
        public bool IsActive = true;
        [ProtoMember(50)]
        public float MaxPlayerDistance = 10000f;
        [ProtoMember(0x26)]
        public bool NeedUpdate = true;
        [ProtoMember(0x2f)]
        public int PlayerPriority = 10;
        [ProtoMember(0x49)]
        public TargetPrioritization PrioritizationStyle = TargetPrioritization.PriorityRandom;
        [ProtoMember(0x3e)]
        public float SpeedLimit = float.MinValue;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x41)]
        public List<DroneTargetSerializable> TargetList = new List<DroneTargetSerializable>();
        [ProtoMember(0x45), Serialize(MyObjectFlags.DefaultZero)]
        public List<long> WaypointList = new List<long>();

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct DroneTargetSerializable
        {
            [ProtoMember(0x19)]
            public long TargetId;
            [ProtoMember(0x1c)]
            public int Priority;
            public DroneTargetSerializable(long targetId, int priority)
            {
                this.TargetId = targetId;
                this.Priority = priority;
            }
        }
    }
}

