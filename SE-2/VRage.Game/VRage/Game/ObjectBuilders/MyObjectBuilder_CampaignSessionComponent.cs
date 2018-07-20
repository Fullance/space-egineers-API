namespace VRage.Game.ObjectBuilders
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_CampaignSessionComponent : MyObjectBuilder_SessionComponent
    {
        public string ActiveState;
        public string CampaignName;
        public string CurrentOutcome;
        public bool IsVanilla;
        public string LocalModFolder;
        public MyObjectBuilder_Checkpoint.ModItem Mod;
    }
}

