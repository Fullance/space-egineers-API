namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ScriptSMTransition : MyObjectBuilder_Base
    {
        public string From;
        public string Name;
        public string To;
    }
}

