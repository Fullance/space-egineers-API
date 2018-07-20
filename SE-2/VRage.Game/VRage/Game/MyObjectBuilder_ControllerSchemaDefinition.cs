namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ControllerSchemaDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlArrayItem("DeviceId"), ProtoMember(80)]
        public List<string> CompatibleDeviceIds;
        [ProtoMember(0x53)]
        public List<Schema> Schemas;

        [ProtoContract]
        public class CompatibleDevice
        {
            [ProtoMember(0x41)]
            public string DeviceId;
        }

        [ProtoContract]
        public class ControlDef
        {
            [ProtoMember(0x2d), XmlAttribute]
            public MyControllerSchemaEnum Control;
            [ProtoMember(0x29), XmlAttribute]
            public string Type;
        }

        [ProtoContract]
        public class ControlGroup
        {
            [ProtoMember(0x3a)]
            public List<MyObjectBuilder_ControllerSchemaDefinition.ControlDef> ControlDefs;
            [ProtoMember(0x37)]
            public string Name;
            [ProtoMember(0x34)]
            public string Type;
        }

        [ProtoContract]
        public class Schema
        {
            [ProtoMember(0x4b)]
            public List<MyObjectBuilder_ControllerSchemaDefinition.ControlGroup> ControlGroups;
            [ProtoMember(0x48)]
            public string SchemaName;
        }
    }
}

