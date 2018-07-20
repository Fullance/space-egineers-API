namespace VRage.Game.ObjectBuilders.Campaign
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_Campaign : MyObjectBuilder_Base
    {
        public string DefaultLocalizationLanguage;
        public string Description;
        public string DescriptionLocalizationFile;
        public string Difficulty;
        public string ImagePath;
        [XmlIgnore]
        public bool IsDebug;
        [XmlIgnore]
        public bool IsLocalMod = true;
        public bool IsMultiplayer;
        [XmlIgnore]
        public bool IsVanilla = true;
        [XmlArrayItem("Language")]
        public List<string> LocalizationLanguages = new List<string>();
        [XmlArrayItem("Path")]
        public List<string> LocalizationPaths = new List<string>();
        [XmlIgnore]
        public string ModFolderPath;
        public string Name;
        [XmlIgnore]
        public ulong PublishedFileId;
        public MyObjectBuilder_CampaignSM StateMachine;
    }
}

