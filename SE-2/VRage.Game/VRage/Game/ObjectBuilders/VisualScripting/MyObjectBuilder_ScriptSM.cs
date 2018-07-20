namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_ScriptSM : MyObjectBuilder_Base
    {
        [ProtoMember(0x13)]
        public MyObjectBuilder_ScriptSMCursor[] Cursors;
        [ProtoMember(13)]
        public string Name;
        [ProtoMember(0x16), DynamicObjectBuilder(false), XmlArrayItem("MyObjectBuilder_ScriptSMNode", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ScriptSMNode>))]
        public MyObjectBuilder_ScriptSMNode[] Nodes;
        [ProtoMember(0x10)]
        public long OwnerId;
        [ProtoMember(0x1b)]
        public MyObjectBuilder_ScriptSMTransition[] Transitions;
    }
}

