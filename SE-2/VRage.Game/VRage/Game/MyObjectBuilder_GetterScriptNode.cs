namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_GetterScriptNode : MyObjectBuilder_ScriptNode
    {
        public string BoundVariableName = string.Empty;
        public IdentifierList OutputIDs = new IdentifierList();
    }
}

