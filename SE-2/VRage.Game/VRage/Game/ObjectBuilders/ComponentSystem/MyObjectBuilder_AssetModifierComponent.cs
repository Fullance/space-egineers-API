namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_AssetModifierComponent : MyObjectBuilder_ComponentBase
    {
        [ProtoMember(14), Serialize(MyObjectFlags.DefaultZero), XmlArrayItem("AssetModifier")]
        public List<SerializableDefinitionId> AssetModifiers = new List<SerializableDefinitionId>();
    }
}

