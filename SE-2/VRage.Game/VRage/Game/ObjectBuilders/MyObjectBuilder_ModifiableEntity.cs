namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_ModifiableEntity : MyObjectBuilder_EntityBase
    {
        [ProtoMember(0x11, IsRequired=false), XmlArrayItem("AssetModifier"), Serialize(MyObjectFlags.DefaultZero)]
        public List<SerializableDefinitionId> AssetModifiers;
    }
}

