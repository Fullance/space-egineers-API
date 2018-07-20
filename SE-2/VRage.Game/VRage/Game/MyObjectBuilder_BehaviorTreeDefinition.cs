namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_BehaviorTreeDefinition : MyObjectBuilder_DefinitionBase
    {
        [DefaultValue("Barbarian"), ProtoMember(0x12)]
        public string Behavior = "Barbarian";
        [ProtoMember(13), XmlElement("FirstNode", typeof(MyAbstractXmlSerializer<MyObjectBuilder_BehaviorTreeNode>))]
        public MyObjectBuilder_BehaviorTreeNode FirstNode;
    }
}

