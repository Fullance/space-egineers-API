namespace VRage.Game.ObjectBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_SkinInventory : MyObjectBuilder_Base
    {
        public List<ulong> Character;
        public SerializableVector3 Color;
        public string Model;
        public List<ulong> Tools;
    }
}

