namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_CoordinateSystem : MyObjectBuilder_SessionComponent
    {
        [ProtoMember(0x1b)]
        public List<CoordSysInfo> CoordSystems = new List<CoordSysInfo>();
        [ProtoMember(0x19)]
        public long LastCoordSysId = 1L;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct CoordSysInfo
        {
            [ProtoMember(15)]
            public long Id;
            [ProtoMember(0x11)]
            public long EntityCount;
            [ProtoMember(0x13)]
            public SerializableQuaternion Rotation;
            [ProtoMember(0x15)]
            public SerializableVector3D Position;
        }
    }
}

