namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((System.Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_NewListScriptNode : MyObjectBuilder_ScriptNode
    {
        public readonly List<MyVariableIdentifier> Connections = new List<MyVariableIdentifier>();
        public readonly List<string> DefaultEntries = new List<string>();
        public string Type = string.Empty;
    }
}

