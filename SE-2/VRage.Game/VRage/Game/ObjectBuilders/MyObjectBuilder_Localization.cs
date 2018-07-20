namespace VRage.Game.ObjectBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_Localization : MyObjectBuilder_Base
    {
        public string Context = "VRage";
        public bool Default;
        [XmlIgnore]
        public List<KeyEntry> Entries = new List<KeyEntry>();
        public uint Id;
        public string Language = "English";
        [XmlIgnore]
        public bool Modified;
        public string ResourceName = "Default Name";
        public string ResXName;

        public override string ToString() => 
            (this.ResourceName + " " + this.Id);

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyEntry
        {
            public string Key;
            public string Value;
        }
    }
}

