namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CurveDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x15)]
        public List<Point> Points;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct Point
        {
            [ProtoMember(15)]
            public float Time;
            [ProtoMember(0x11)]
            public float Value;
        }
    }
}

