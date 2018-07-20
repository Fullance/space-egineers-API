namespace VRage.Game.ObjectBuilders.Campaign
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CampaignSMTransition : MyObjectBuilder_Base
    {
        public string From;
        public string Name;
        public string To;
    }
}

