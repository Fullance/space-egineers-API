namespace VRage.Game.Models
{
    using BulletXNA.BulletCollision;
    using System;
    using System.Runtime.InteropServices;
    using VRage;
    using VRage.Game.Components;
    using VRage.Utils;
    using VRageMath;

    public class MyQuantizedBvhResult
    {
        private IntersectionFlags m_flags;
        private Line m_line;
        private MyModel m_model;
        private Plane[] m_planes;
        private MyIntersectionResultLineTriangle? m_result;
        public readonly ProcessCollisionHandler ProcessTriangleHandler;

        public MyQuantizedBvhResult()
        {
            this.ProcessTriangleHandler = new ProcessCollisionHandler(this.ProcessTriangle);
        }

        private float? ProcessTriangle(int triangleIndex)
        {
            MyTriangle_Vertices vertices;
            MyTriangleVertexIndices indices = this.m_model.Triangles[triangleIndex];
            this.m_model.GetVertex(indices.I0, indices.I2, indices.I1, out vertices.Vertex0, out vertices.Vertex1, out vertices.Vertex2);
            Vector3 normal = this.m_planes[triangleIndex].Normal;
            if (((this.m_flags & IntersectionFlags.FLIPPED_TRIANGLES) == ((IntersectionFlags) 0)) && (this.m_line.Direction.Dot(ref normal) > 0f))
            {
                return null;
            }
            float? lineTriangleIntersection = MyUtils.GetLineTriangleIntersection(ref this.m_line, ref vertices);
            if (lineTriangleIntersection.HasValue && float.IsNaN(lineTriangleIntersection.Value))
            {
                MyLog.Default.Warning("Invalid triangle in " + this.m_model.AssetName, new object[0]);
            }
            if ((!lineTriangleIntersection.HasValue || float.IsNaN(lineTriangleIntersection.Value)) || (this.m_result.HasValue && (lineTriangleIntersection.Value >= this.m_result.Value.Distance)))
            {
                return null;
            }
            MyTriangle_BoneIndicesWeigths? boneIndicesWeights = this.m_model.GetBoneIndicesWeights(triangleIndex);
            this.m_result = new MyIntersectionResultLineTriangle(triangleIndex, ref vertices, ref boneIndicesWeights, ref normal, lineTriangleIntersection.Value);
            return new float?(lineTriangleIntersection.Value);
        }

        public void Start(MyModel model, Line line, Plane[] planes, IntersectionFlags flags = 1)
        {
            this.m_result = null;
            this.m_model = model;
            this.m_planes = planes;
            this.m_line = line;
            this.m_flags = flags;
        }

        public MyIntersectionResultLineTriangle? Result =>
            this.m_result;
    }
}

