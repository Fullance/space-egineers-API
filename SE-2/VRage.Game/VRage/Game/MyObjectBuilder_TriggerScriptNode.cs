namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_TriggerScriptNode : MyObjectBuilder_ScriptNode
    {
        public List<MyVariableIdentifier> InputIDs = new List<MyVariableIdentifier>();
        public List<string> InputNames = new List<string>();
        public List<string> InputTypes = new List<string>();
        public int SequenceInputID = -1;
        public string TriggerName = string.Empty;
    }
}

