namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.Game.ObjectBuilders.Campaign;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_VSFiles : MyObjectBuilder_Base
    {
        public MyObjectBuilder_Campaign Campaign;
        public MyObjectBuilder_VisualLevelScript LevelScript;
        public MyObjectBuilder_ScriptSM StateMachine;
        public MyObjectBuilder_VisualScript VisualScript;
    }
}

