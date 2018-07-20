namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;

    public class MyWeaponRule
    {
        public bool CanGoThroughVoxels;
        public bool FiringAfterLosingSight = true;
        public float TimeMax = 3f;
        public float TimeMin = 2f;
        public string Weapon = "";
    }
}

