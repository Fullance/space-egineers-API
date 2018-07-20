namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_BehaviorTreeNodeMemory : MyObjectBuilder_Base
    {
        [ProtoMember(14), DefaultValue(false), XmlAttribute]
        public bool InitCalled;
    }
}

