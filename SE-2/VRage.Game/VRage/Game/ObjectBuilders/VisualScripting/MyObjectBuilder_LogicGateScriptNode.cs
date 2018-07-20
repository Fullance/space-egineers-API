namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_LogicGateScriptNode : MyObjectBuilder_ScriptNode
    {
        public LogicOperation Operation = LogicOperation.NOT;
        public List<MyVariableIdentifier> ValueInputs = new List<MyVariableIdentifier>();
        public List<MyVariableIdentifier> ValueOutputs = new List<MyVariableIdentifier>();

        public enum LogicOperation
        {
            AND,
            OR,
            XOR,
            NAND,
            NOR,
            NOT
        }
    }
}

