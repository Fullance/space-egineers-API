namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRageMath;

    [MyObjectBuilderDefinition((Type) null, null), MyEnvironmentItems(typeof(MyObjectBuilder_EnvironmentItemDefinition)), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_EnvironmentItems : MyObjectBuilder_EntityBase
    {
        [ProtoMember(0x2c)]
        public Vector3D CellsOffset;
        [ProtoMember(0x29), XmlArrayItem("Item")]
        public MyOBEnvironmentItemData[] Items;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct MyOBEnvironmentItemData
        {
            [ProtoMember(0x21)]
            public MyPositionAndOrientation PositionAndOrientation;
            [ProtoMember(0x24)]
            public string SubtypeName;
        }
    }
}

