namespace VRage.Game.ModAPI
{
    using System;
    using VRage.ModAPI;
    using VRageMath;

    public interface IHitInfo
    {
        float Fraction { get; }

        IMyEntity HitEntity { get; }

        Vector3 Normal { get; }

        Vector3D Position { get; }
    }
}

