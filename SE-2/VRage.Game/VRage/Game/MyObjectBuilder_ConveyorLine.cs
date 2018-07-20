namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRage.Serialization;
    using VRageMath;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ConveyorLine : MyObjectBuilder_Base
    {
        [DefaultValue(0), ProtoMember(60)]
        public LineConductivity ConveyorLineConductivity;
        [ProtoMember(0x39), DefaultValue(0)]
        public LineType ConveyorLineType;
        [ProtoMember(40)]
        public Base6Directions.Direction EndDirection;
        [ProtoMember(0x25)]
        public SerializableVector3I EndPosition;
        [ProtoMember(0x2f)]
        public List<MyObjectBuilder_ConveyorPacket> PacketsBackward = new List<MyObjectBuilder_ConveyorPacket>();
        [ProtoMember(0x2b)]
        public List<MyObjectBuilder_ConveyorPacket> PacketsForward = new List<MyObjectBuilder_ConveyorPacket>();
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x33), DefaultValue((string) null), XmlArrayItem("Section")]
        public List<SerializableLineSectionInformation> Sections = new List<SerializableLineSectionInformation>();
        [ProtoMember(0x22)]
        public Base6Directions.Direction StartDirection;
        [ProtoMember(0x1f)]
        public SerializableVector3I StartPosition;

        public bool ShouldSerializePacketsBackward() => 
            (this.PacketsBackward.Count != 0);

        public bool ShouldSerializePacketsForward() => 
            (this.PacketsForward.Count != 0);

        public bool ShouldSerializeSections() => 
            (this.Sections != null);

        public enum LineConductivity
        {
            FULL,
            FORWARD,
            BACKWARD,
            NONE
        }

        public enum LineType
        {
            DEFAULT_LINE,
            SMALL_LINE,
            LARGE_LINE
        }
    }
}

