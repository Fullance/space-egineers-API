namespace VRage.Game.Models
{
    using System;
    using System.Runtime.InteropServices;
    using VRage;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyIntersectionResultLineTriangle
    {
        public float Distance;
        public MyTriangle_Vertices InputTriangle;
        public MyTriangle_BoneIndicesWeigths? BoneWeights;
        public Vector3 InputTriangleNormal;
        public int TriangleIndex;
        public MyIntersectionResultLineTriangle(int triangleIndex, ref MyTriangle_Vertices triangle, ref Vector3 triangleNormal, float distance)
        {
            this.InputTriangle = triangle;
            this.InputTriangleNormal = triangleNormal;
            this.Distance = distance;
            this.BoneWeights = null;
            this.TriangleIndex = triangleIndex;
        }

        public MyIntersectionResultLineTriangle(int triangleIndex, ref MyTriangle_Vertices triangle, ref MyTriangle_BoneIndicesWeigths? boneWeigths, ref Vector3 triangleNormal, float distance)
        {
            this.InputTriangle = triangle;
            this.InputTriangleNormal = triangleNormal;
            this.Distance = distance;
            this.BoneWeights = boneWeigths;
            this.TriangleIndex = triangleIndex;
        }

        public static MyIntersectionResultLineTriangle? GetCloserIntersection(ref MyIntersectionResultLineTriangle? a, ref MyIntersectionResultLineTriangle? b)
        {
            if ((a.HasValue || !b.HasValue) && ((!a.HasValue || !b.HasValue) || (b.Value.Distance >= a.Value.Distance)))
            {
                return a;
            }
            return b;
        }
    }
}

