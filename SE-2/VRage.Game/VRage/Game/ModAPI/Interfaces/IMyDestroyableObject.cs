namespace VRage.Game.ModAPI.Interfaces
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Utils;

    public interface IMyDestroyableObject
    {
        bool DoDamage(float damage, MyStringHash damageSource, bool sync, MyHitInfo? hitInfo = new MyHitInfo?(), long attackerId = 0L);
        void OnDestroy();

        float Integrity { get; }

        bool UseDamageSystem { get; }
    }
}

