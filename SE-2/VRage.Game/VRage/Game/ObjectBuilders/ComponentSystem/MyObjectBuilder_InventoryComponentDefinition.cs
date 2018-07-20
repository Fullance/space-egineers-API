namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_InventoryComponentDefinition : MyObjectBuilder_ComponentDefinitionBase
    {
        public InventoryConstraintDefinition InputConstraint;
        [ProtoMember(0x1c)]
        public float Mass = float.MaxValue;
        [ProtoMember(0x25)]
        public int MaxItemCount = 0x7fffffff;
        [ProtoMember(0x22)]
        public bool MultiplierEnabled = true;
        [ProtoMember(0x1f)]
        public bool RemoveEntityOnEmpty;
        [ProtoMember(0x16)]
        public SerializableVector3? Size;
        [ProtoMember(0x19)]
        public float Volume = float.MaxValue;

        public class InventoryConstraintDefinition
        {
            [XmlElement("Entry")]
            public List<SerializableDefinitionId> Entries = new List<SerializableDefinitionId>();
            [XmlAttribute("Whitelist")]
            public bool IsWhitelist = true;
        }
    }
}

