namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ItemAutoswitchComponent : MyObjectBuilder_SessionComponent
    {
        [ProtoMember(12)]
        public SerializableDefinitionId? AutoswitchTargetDefinition;
    }
}

