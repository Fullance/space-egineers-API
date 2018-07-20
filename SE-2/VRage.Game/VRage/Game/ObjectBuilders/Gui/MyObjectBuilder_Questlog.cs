namespace VRage.Game.ObjectBuilders.Gui
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_Questlog : MyObjectBuilder_Base
    {
        public List<MultilineData> LineData = new List<MultilineData>();
        public string Title = string.Empty;
        public bool Visible = true;
    }
}

