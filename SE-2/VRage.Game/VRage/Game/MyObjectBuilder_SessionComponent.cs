namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_SessionComponent : MyObjectBuilder_Base
    {
        public bool ShouldSerializeDefinition() => 
            this.Definition.HasValue;

        public SerializableDefinitionId? Definition { get; set; }
    }
}

