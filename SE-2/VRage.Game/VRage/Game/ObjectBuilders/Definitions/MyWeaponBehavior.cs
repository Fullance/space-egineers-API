namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class MyWeaponBehavior
    {
        public bool IgnoresGrids;
        public bool IgnoresVoxels;
        public string Name = "No name";
        public int Priority = 10;
        [XmlArrayItem("Weapon")]
        public List<string> Requirements;
        public bool RequirementsIsWhitelist;
        public float TimeMax = 4f;
        public float TimeMin = 2f;
        [XmlArrayItem("WeaponRule")]
        public List<MyWeaponRule> WeaponRules;
    }
}

