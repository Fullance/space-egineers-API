namespace VRage.Game.ObjectBuilders.Components
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_LocalizationSessionComponent : MyObjectBuilder_SessionComponent
    {
        public List<string> AdditionalPaths = new List<string>();
        public string CampaignModFolderName = string.Empty;
        public List<string> CampaignPaths = new List<string>();
        public string Language = "English";
    }
}

