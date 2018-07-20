namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_ModStorageComponentDefinition : MyObjectBuilder_ComponentDefinitionBase
    {
        [Serialize(MyObjectFlags.DefaultValueOrEmpty | MyObjectFlags.DefaultZero), DefaultValue((string) null), ProtoMember(13)]
        public Guid[] RegisteredStorageGuids;
    }
}

