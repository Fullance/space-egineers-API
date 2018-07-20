namespace VRage.Game.ObjectBuilders.Campaign
{
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CampaignSMNode : MyObjectBuilder_Base
    {
        public SerializableVector2 Location;
        public string Name;
        public string SaveFilePath;
    }
}

