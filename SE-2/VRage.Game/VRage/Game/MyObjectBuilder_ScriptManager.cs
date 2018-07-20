namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ScriptManager : MyObjectBuilder_SessionComponent
    {
        [ProtoMember(13)]
        public SerializableDictionary<string, object> variables = new SerializableDictionary<string, object>();
    }
}

