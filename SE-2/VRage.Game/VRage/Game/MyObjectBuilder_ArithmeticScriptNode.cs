namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((System.Type) null, null)]
    public class MyObjectBuilder_ArithmeticScriptNode : MyObjectBuilder_ScriptNode
    {
        public MyVariableIdentifier InputAID = MyVariableIdentifier.Default;
        public MyVariableIdentifier InputBID = MyVariableIdentifier.Default;
        public string Operation;
        public List<MyVariableIdentifier> OutputNodeIDs = new List<MyVariableIdentifier>();
        public string Type;
        public string ValueA = string.Empty;
        public string ValueB = string.Empty;
    }
}

