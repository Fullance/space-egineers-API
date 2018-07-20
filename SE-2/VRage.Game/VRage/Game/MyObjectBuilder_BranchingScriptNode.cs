namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_BranchingScriptNode : MyObjectBuilder_ScriptNode
    {
        public MyVariableIdentifier InputID = MyVariableIdentifier.Default;
        public int SequenceInputID = -1;
        public int SequenceTrueOutputID = -1;
        public int SequnceFalseOutputID = -1;
    }
}

