namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ScriptSMFinalNode : MyObjectBuilder_ScriptSMNode
    {
    }
}

