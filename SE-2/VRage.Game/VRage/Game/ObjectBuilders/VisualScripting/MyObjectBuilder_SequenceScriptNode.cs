namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_SequenceScriptNode : MyObjectBuilder_ScriptNode
    {
        public int SequenceInput = -1;
        public List<int> SequenceOutputs = new List<int>();
    }
}

