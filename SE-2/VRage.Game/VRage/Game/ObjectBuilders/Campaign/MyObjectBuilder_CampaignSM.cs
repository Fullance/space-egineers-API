namespace VRage.Game.ObjectBuilders.Campaign
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_CampaignSM : MyObjectBuilder_Base
    {
        public MyObjectBuilder_CampaignSMNode[] Nodes;
        public MyObjectBuilder_CampaignSMTransition[] Transitions;
    }
}

