namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [Description("Main definition for a game."), XmlType("VR.GameDefinition"), XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_GameDefinition : MyObjectBuilder_DefinitionBase
    {
        [DefaultValue(false), Description("Weather this game definition is the default for new scenarios.")]
        public bool Default;
        [Description("What object builder to inherit from if any."), DefaultValue((string) null)]
        public string InheritFrom;
        [XmlArrayItem("Component"), DefaultValue("empty"), Description("List of session components to load for this Game.")]
        public List<Comp> SessionComponents = new List<Comp>();

        [StructLayout(LayoutKind.Sequential)]
        public struct Comp
        {
            [XmlAttribute]
            public string Type;
            [XmlAttribute]
            public string Subtype;
            [XmlText]
            public string ComponentName;
        }
    }
}

