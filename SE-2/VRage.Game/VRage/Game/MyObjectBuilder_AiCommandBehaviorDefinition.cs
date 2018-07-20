namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_AiCommandBehaviorDefinition : MyObjectBuilder_AiCommandDefinition
    {
        [ProtoMember(11)]
        public string BehaviorTreeName;
        [ProtoMember(14)]
        public MyAiCommandEffect CommandEffect;
    }
}

