namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_SwitchScriptNode : MyObjectBuilder_ScriptNode
    {
        public string NodeType = string.Empty;
        public readonly List<OptionData> Options = new List<OptionData>();
        public int SequenceInput = -1;
        public MyVariableIdentifier ValueInput;

        [StructLayout(LayoutKind.Sequential)]
        public struct OptionData
        {
            public string Option;
            public int SequenceOutput;
        }
    }
}

