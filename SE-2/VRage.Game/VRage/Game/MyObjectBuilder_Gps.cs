namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_Gps : MyObjectBuilder_Base
    {
        [ProtoMember(0x2e)]
        public List<Entry> Entries;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct Entry
        {
            [ProtoMember(0x12)]
            public string name;
            [ProtoMember(0x15)]
            public string description;
            [ProtoMember(0x18)]
            public Vector3D coords;
            [ProtoMember(0x1b)]
            public bool isFinal;
            [ProtoMember(30)]
            public bool showOnHud;
            [ProtoMember(0x21)]
            public bool alwaysVisible;
            [ProtoMember(0x24)]
            public Color color;
            [ProtoMember(0x27, IsRequired=false)]
            public long entityId;
            [ProtoMember(0x2a, IsRequired=false)]
            public string DisplayName { get; set; }
        }
    }
}

