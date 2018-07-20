namespace VRage.Game.Models
{
    using BulletXNA.BulletCollision;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage;
    using VRage.Game.Components;
    using VRage.Utils;
    using VRageMath;

    public class MyQuantizedBvhAllTrianglesResult
    {
        private readonly MyResultComparer m_comparer = new MyResultComparer();
        private IntersectionFlags m_flags;
        private Line m_line;
        private MyModel m_model;
        private Plane[] m_planes;
        private readonly List<MyIntersectionResultLineTriangle> m_result = new List<MyIntersectionResultLineTriangle>();
        public readonly ProcessCollisionHandler ProcessTriangleHandler;

        public MyQuantizedBvhAllTrianglesResult()
        {
            this.ProcessTriangleHandler = new ProcessCollisionHandler(this.ProcessTriangle);
        }

        public void End()
        {
            this.m_result.Sort(this.m_comparer);
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
            if (lineTriangleIntersection.HasValue)
            {
                MyTriangle_BoneIndicesWeigths? boneIndicesWeights = this.m_model.GetBoneIndicesWeights(triangleIndex);
                MyIntersectionResultLineTriangle item = new MyIntersectionResultLineTriangle(triangleIndex, ref vertices, ref boneIndicesWeights, ref normal, lineTriangleIntersection.Value);
                this.m_result.Add(item);
            }
            return lineTriangleIntersection;
        }

        public void Start(MyModel model, Line line, Plane[] planes, IntersectionFlags flags = 1)
        {
            this.m_result.Clear();
            this.m_model = model;
            this.m_line = line;
            this.m_flags = flags;
            this.m_planes = planes;
        }

        public List<MyIntersectionResultLineTriangle> Result =>
            this.m_result;
    }
}

