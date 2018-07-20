namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ForLoopScriptNode : MyObjectBuilder_ScriptNode
    {
        public List<MyVariableIdentifier> CounterValueOutputs = new List<MyVariableIdentifier>();
        public string FirstIndexValue = "0";
        public MyVariableIdentifier FirstIndexValueInput = MyVariableIdentifier.Default;
        public string IncrementValue = "1";
        public MyVariableIdentifier IncrementValueInput = MyVariableIdentifier.Default;
        public string LastIndexValue = "0";
        public MyVariableIdentifier LastIndexValueInput = MyVariableIdentifier.Default;
        public int SequenceBody = -1;
        public List<int> SequenceInputs = new List<int>();
        public int SequenceOutput = -1;
    }
}

