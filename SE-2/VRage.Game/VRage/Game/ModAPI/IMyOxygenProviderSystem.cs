namespace VRage.Game.ModAPI
{
    using System;
    using VRageMath;

    public interface IMyOxygenProviderSystem
    {
        void AddOxygenGenerator(IMyOxygenProvider provider);
        float GetOxygenInPoint(Vector3D worldPoint);
        void RemoveOxygenGenerator(IMyOxygenProvider provider);
    }
}

