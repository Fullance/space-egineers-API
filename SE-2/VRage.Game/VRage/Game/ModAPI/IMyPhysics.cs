namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRageMath;

    public interface IMyPhysics
    {
        bool CastLongRay(Vector3D from, Vector3D to, out IHitInfo hitInfo, bool any);
        bool CastRay(Vector3D from, Vector3D to, out IHitInfo hitInfo, int raycastFilterLayer = 0);
        void CastRay(Vector3D from, Vector3D to, List<IHitInfo> toList, int raycastFilterLayer = 0);
        bool CastRay(Vector3D from, Vector3D to, out IHitInfo hitInfo, uint raycastCollisionFilter, bool ignoreConvexShape);
        void EnsurePhysicsSpace(BoundingBoxD aabb);
        int GetCollisionLayer(string strLayer);

        float ServerSimulationRatio { get; }

        float SimulationRatio { get; }

        int StepsLastSecond { get; }
    }
}

