namespace VRage.Game.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game.Components;
    using VRage.ModAPI;
    using VRageMath;

    public interface IMyTriangePruningStructure
    {
        void Close();
        bool GetIntersectionWithAABB(IMyEntity physObject, ref BoundingBoxD aabb);
        MyIntersectionResultLineTriangleEx? GetIntersectionWithLine(IMyEntity entity, ref LineD line, IntersectionFlags flags = 1);
        MyIntersectionResultLineTriangleEx? GetIntersectionWithLine(IMyEntity entity, ref LineD line, ref MatrixD customInvMatrix, IntersectionFlags flags = 1);
        bool GetIntersectionWithSphere(ref BoundingSphere localSphere);
        bool GetIntersectionWithSphere(IMyEntity physObject, ref BoundingSphereD sphere);
        void GetTrianglesIntersectingAABB(ref BoundingBox sphere, List<MyTriangle_Vertex_Normal> retTriangles, int maxNeighbourTriangles);
        void GetTrianglesIntersectingLine(IMyEntity entity, ref LineD line, IntersectionFlags flags, List<MyIntersectionResultLineTriangleEx> result);
        void GetTrianglesIntersectingLine(IMyEntity entity, ref LineD line, ref MatrixD customInvMatrix, IntersectionFlags flags, List<MyIntersectionResultLineTriangleEx> result);
        void GetTrianglesIntersectingSphere(ref BoundingSphere sphere, Vector3? referenceNormalVector, float? maxAngle, List<MyTriangle_Vertex_Normals> retTriangles, int maxNeighbourTriangles);

        int Size { get; }
    }
}

