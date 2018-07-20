namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_FracturedBlock : MyObjectBuilder_CubeBlock
    {
        [ProtoMember(0x25)]
        public List<SerializableDefinitionId> BlockDefinitions = new List<SerializableDefinitionId>();
        [ProtoMember(0x2b)]
        public List<SerializableBlockOrientation> BlockOrientations = new List<SerializableBlockOrientation>();
        public bool CreatingFracturedBlock;
        [ProtoMember(0x30)]
        public List<MyMultiBlockPart> MultiBlocks = new List<MyMultiBlockPart>();
        [ProtoMember(40)]
        public List<ShapeB> Shapes = new List<ShapeB>();

        [ProtoContract]
        public class MyMultiBlockPart
        {
            [ProtoMember(0x1f)]
            public SerializableDefinitionId MultiBlockDefinition;
            [ProtoMember(0x21)]
            public int MultiBlockId;
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct ShapeB
        {
            [ProtoMember(20)]
            public string Name;
            [ProtoMember(0x16)]
            public SerializableQuaternion Orientation;
            [DefaultValue(false), ProtoMember(0x18)]
            public bool Fixed;
        }
    }
}

