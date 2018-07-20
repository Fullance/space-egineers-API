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

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_FracturedPiece : MyObjectBuilder_EntityBase
    {
        [ProtoMember(0x18)]
        public List<SerializableDefinitionId> BlockDefinitions = new List<SerializableDefinitionId>();
        [ProtoMember(0x1b)]
        public List<Shape> Shapes = new List<Shape>();

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct Shape
        {
            [ProtoMember(0x11)]
            public string Name;
            [ProtoMember(0x13)]
            public SerializableQuaternion Orientation;
            [DefaultValue(false), ProtoMember(0x15)]
            public bool Fixed;
        }
    }
}

