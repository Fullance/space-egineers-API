namespace VRage.Game
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Game.ObjectBuilders.Gui;
    using VRage.Game.ObjectBuilders.VisualScripting;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_VisualScriptManagerSessionComponent : MyObjectBuilder_SessionComponent
    {
        public bool FirstRun = true;
        [XmlArrayItem("FilePath"), XmlArray("LevelScriptFiles", IsNullable=true)]
        public string[] LevelScriptFiles;
        [DefaultValue((string) null)]
        public MyObjectBuilder_Questlog Questlog;
        [DefaultValue((string) null)]
        public MyObjectBuilder_ScriptStateMachineManager ScriptStateMachineManager;
        [XmlArrayItem("FilePath"), XmlArray("StateMachines", IsNullable=true)]
        public string[] StateMachines;
    }
}

