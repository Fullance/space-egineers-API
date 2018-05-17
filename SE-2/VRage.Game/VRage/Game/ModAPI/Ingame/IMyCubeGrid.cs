namespace VRage.Game.ModAPI.Ingame
{
    using System;
    using VRage.Game;
    using VRageMath;

    public interface IMyCubeGrid : IMyEntity
    {
        bool CubeExists(Vector3I pos);
        IMySlimBlock GetCubeBlock(Vector3I pos);
        Vector3D GridIntegerToWorld(Vector3I gridCoords);
        Vector3I WorldToGridInteger(Vector3D coords);

        string CustomName { get; set; }

        float GridSize { get; }

        MyCubeSize GridSizeEnum { get; }

        bool IsStatic { get; }

        Vector3I Max { get; }

        Vector3I Min { get; }
    }
}

