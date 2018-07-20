namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ModStorageComponent : MyObjectBuilder_ComponentBase
    {
        [Serialize(MyObjectFlags.DefaultZero), DefaultValue((string) null), ProtoMember(14)]
        public SerializableDictionary<Guid, string> Storage;
    }
}

