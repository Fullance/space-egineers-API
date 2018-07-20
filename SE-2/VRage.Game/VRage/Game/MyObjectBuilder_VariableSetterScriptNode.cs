namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_VariableSetterScriptNode : MyObjectBuilder_ScriptNode
    {
        public int SequenceInputID = -1;
        public int SequenceOutputID = -1;
        public MyVariableIdentifier ValueInputID = MyVariableIdentifier.Default;
        public string VariableName = string.Empty;
        public string VariableValue = string.Empty;
    }
}

