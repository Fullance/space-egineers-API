namespace VRage.Game.ModAPI
{
    using System;
    using VRageMath;

    public interface IMyOxygenProvider
    {
        float GetOxygenForPosition(Vector3D worldPoint);
        bool IsPositionInRange(Vector3D worldPoint);
    }
}

