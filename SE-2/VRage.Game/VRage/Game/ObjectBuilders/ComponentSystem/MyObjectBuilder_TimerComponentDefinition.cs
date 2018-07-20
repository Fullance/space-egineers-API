namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_TimerComponentDefinition : MyObjectBuilder_ComponentDefinitionBase
    {
        [ProtoMember(11)]
        public float TimeToRemoveMin;
    }
}

