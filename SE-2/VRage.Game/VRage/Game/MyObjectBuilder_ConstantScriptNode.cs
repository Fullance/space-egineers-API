namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((System.Type) null, null)]
    public class MyObjectBuilder_ConstantScriptNode : MyObjectBuilder_ScriptNode
    {
        public IdentifierList OutputIds = new IdentifierList();
        public string Type = string.Empty;
        public string Value = string.Empty;
    }
}

