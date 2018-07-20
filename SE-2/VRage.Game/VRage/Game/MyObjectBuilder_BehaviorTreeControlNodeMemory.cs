namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_BehaviorTreeControlNodeMemory : MyObjectBuilder_BehaviorTreeNodeMemory
    {
        [DefaultValue(0), XmlAttribute, ProtoMember(14)]
        public int InitialIndex;
    }
}

