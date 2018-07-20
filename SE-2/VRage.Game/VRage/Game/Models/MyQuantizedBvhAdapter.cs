namespace VRage.Game.Models
{
    using BulletXNA.BulletCollision;
    using BulletXNA.LinearMath;
    using System;
    using System.Collections.Generic;
    using VRage;
    using VRage.Game.Components;
    using VRage.Import;
    using VRage.ModAPI;
    using VRage.Utils;
    using VRageMath;

    public class MyQuantizedBvhAdapter : IMyTriangePruningStructure
    {
        private BoundingBox[] m_bounds;
        private readonly GImpactQuantizedBvh m_bvh;
        private readonly MyModel m_model;
        private Plane[] m_planes;
        [ThreadStatic]
        private static MyQuantizedBvhAllTrianglesResult m_resultAllThreadStatic;
        [ThreadStatic]
        private static MyQuantizedBvhResult m_resultThreadStatic;

        public MyQuantizedBvhAdapter(GImpactQuantizedBvh bvh, MyModel model)
        {
            this.m_bvh = bvh;
            this.m_model = model;
        }

        private bool CheckSphereTriangleIntersection(ref BoundingSphere sphereF, int triangleIndex)
        {
            if (this.m_bounds[triangleIndex].Intersects(ref sphereF))
            {
                MyTriangle_Vertices vertices;
                MyTriangleVertexIndices indices = this.m_model.Triangles[triangleIndex];
                this.m_model.GetVertex(indices.I0, indices.I1, indices.I2, out vertices.Vertex0, out vertices.Vertex1, out vertices.Vertex2);
                if (MyUtils.GetSphereTriangleIntersection(ref sphereF, ref this.m_planes[triangleIndex], ref vertices).HasValue)
                {
                    return true;
                }
            }
            return false;
        }

        public void Close()
        {
        }

        public bool GetIntersectionWithAABB(IMyEntity entity, ref BoundingBoxD aabb)
        {
            this.UpdateCache();
            MatrixD worldMatrixNormalizedInv = entity.PositionComp.WorldMatrixNormalizedInv;
            Vector3D vectord = Vector3D.Transform(aabb.Center, ref worldMatrixNormalizedInv);
            BoundingBoxD xd2 = aabb;
            xd2.Translate(vectord - aabb.Center);
            IndexedVector3 min = xd2.Min.ToBullet();
            AABB box = new AABB(min, xd2.Max.ToBullet());
            return this.m_bvh.BoxQuery(ref box, triangleIndex => true);
        }

        public MyIntersectionResultLineTriangleEx? GetIntersectionWithLine(IMyEntity entity, ref LineD line, IntersectionFlags flags)
        {
            BoundingSphereD worldVolume = entity.PositionComp.WorldVolume;
            if (!MyUtils.IsLineIntersectingBoundingSphere(ref line, ref worldVolume))
            {
                return null;
            }
            MatrixD worldMatrixInvScaled = entity.PositionComp.WorldMatrixInvScaled;
            return this.GetIntersectionWithLine(entity, ref line, ref worldMatrixInvScaled, flags);
        }

        public MyIntersectionResultLineTriangleEx? GetIntersectionWithLine(IMyEntity entity, ref LineD line, ref MatrixD customInvMatrix, IntersectionFlags flags)
        {
            Line line2 = new Line((Vector3) Vector3D.Transform(line.From, ref customInvMatrix), (Vector3) Vector3D.Transform(line.To, ref customInvMatrix), true);
            this.UpdateCache();
            Result.Start(this.m_model, line2, this.m_planes, flags);
            IndexedVector3 vector = line2.Direction.ToBullet();
            IndexedVector3 vector2 = line2.From.ToBullet();
            this.m_bvh.RayQueryClosest(ref vector, ref vector2, Result.ProcessTriangleHandler);
            if (Result.Result.HasValue)
            {
                return new MyIntersectionResultLineTriangleEx(Result.Result.Value, entity, ref line2);
            }
            return null;
        }

        public bool GetIntersectionWithSphere(ref BoundingSphere sphereInObjectSpace)
        {
            this.UpdateCache();
            BoundingBox box = BoundingBox.CreateInvalid();
            BoundingSphere sphereF = sphereInObjectSpace;
            box.Include(ref sphereInObjectSpace);
            IndexedVector3 min = box.Min.ToBullet();
            AABB aabb = new AABB(min, box.Max.ToBullet());
            return this.m_bvh.BoxQuery(ref aabb, triangleIndex => this.CheckSphereTriangleIntersection(ref sphereF, triangleIndex));
        }

        public bool GetIntersectionWithSphere(IMyEntity entity, ref BoundingSphereD sphere)
        {
            MatrixD worldMatrixNormalizedInv = entity.PositionComp.WorldMatrixNormalizedInv;
            Vector3 center = (Vector3) Vector3D.Transform(sphere.Center, ref worldMatrixNormalizedInv);
            BoundingSphere sphereInObjectSpace = new BoundingSphere(center, (float) sphere.Radius);
            return this.GetIntersectionWithSphere(ref sphereInObjectSpace);
        }

        public void GetTrianglesIntersectingAABB(ref BoundingBox aabb, List<MyTriangle_Vertex_Normal> retTriangles, int maxNeighbourTriangles)
        {
            if (retTriangles.Count != maxNeighbourTriangles)
            {
                this.UpdateCache();
                IndexedVector3 min = aabb.Min.ToBullet();
                IndexedVector3 max = aabb.Max.ToBullet();
                AABB box = new AABB(ref min, ref max);
                this.m_bvh.BoxQuery(ref box, delegate (int triangleIndex) {
                    MyTriangle_Vertex_Normal normal;
                    MyTriangleVertexIndices indices = this.m_model.Triangles[triangleIndex];
                    MyTriangle_Vertices vertices = new MyTriangle_Vertices();
                    this.m_model.GetVertex(indices.I0, indices.I1, indices.I2, out vertices.Vertex0, out vertices.Vertex1, out vertices.Vertex2);
                    normal.Vertexes = vertices;
                    normal.Normal = Vector3.Forward;
                    retTriangles.Add(normal);
                    return retTriangles.Count == maxNeighbourTriangles;
                });
            }
        }

        public void GetTrianglesIntersectingLine(IMyEntity entity, ref LineD line, IntersectionFlags flags, List<MyIntersectionResultLineTriangleEx> result)
        {
            MatrixD worldMatrixNormalizedInv = entity.PositionComp.WorldMatrixNormalizedInv;
            this.GetTrianglesIntersectingLine(entity, ref line, ref worldMatrixNormalizedInv, flags, result);
        }

        public void GetTrianglesIntersectingLine(IMyEntity entity, ref LineD line, ref MatrixD customInvMatrix, IntersectionFlags flags, List<MyIntersectionResultLineTriangleEx> result)
        {
            this.UpdateCache();
            Line line2 = new Line((Vector3) Vector3D.Transform(line.From, ref customInvMatrix), (Vector3) Vector3D.Transform(line.To, ref customInvMatrix), true);
            ResultAll.Start(this.m_model, line2, this.m_planes, flags);
            IndexedVector3 vector = line2.Direction.ToBullet();
            IndexedVector3 vector2 = line2.From.ToBullet();
            this.m_bvh.RayQuery(ref vector, ref vector2, ResultAll.ProcessTriangleHandler);
            ResultAll.End();
            foreach (MyIntersectionResultLineTriangle triangle in ResultAll.Result)
            {
                result.Add(new MyIntersectionResultLineTriangleEx(triangle, entity, ref line2));
            }
        }

        public void GetTrianglesIntersectingSphere(ref BoundingSphere sphere, Vector3? referenceNormalVector, float? maxAngle, List<MyTriangle_Vertex_Normals> retTriangles, int maxNeighbourTriangles)
        {
            BoundingSphere sphereLocal;
            if (retTriangles.Count != maxNeighbourTriangles)
            {
                this.UpdateCache();
                BoundingBox box = BoundingBox.CreateInvalid();
                sphereLocal = sphere;
                box.Include(ref sphere);
                IndexedVector3 min = box.Min.ToBullet();
                AABB aabb = new AABB(min, box.Max.ToBullet());
                this.m_bvh.BoxQuery(ref aabb, delegate (int triangleIndex) {
                    if (this.CheckSphereTriangleIntersection(ref sphereLocal, triangleIndex))
                    {
                        if (referenceNormalVector.HasValue && maxAngle.HasValue)
                        {
                            float angleBetweenVectors = MyUtils.GetAngleBetweenVectors(referenceNormalVector.Value, this.m_planes[triangleIndex].Normal);
                            if (angleBetweenVectors > maxAngle)
                            {
                                goto Label_01C3;
                            }
                        }
                        MyTriangleVertexIndices indices = this.m_model.Triangles[triangleIndex];
                        MyTriangle_Vertex_Normals normals2 = new MyTriangle_Vertex_Normals();
                        MyTriangle_Vertices vertices = new MyTriangle_Vertices {
                            Vertex0 = PositionPacker.UnpackPosition(ref this.m_model.Vertices[indices.I0].Position),
                            Vertex1 = PositionPacker.UnpackPosition(ref this.m_model.Vertices[indices.I1].Position),
                            Vertex2 = PositionPacker.UnpackPosition(ref this.m_model.Vertices[indices.I2].Position)
                        };
                        normals2.Vertices = vertices;
                        normals2.Normals.Normal0 = this.m_model.GetVertexNormal(indices.I0);
                        normals2.Normals.Normal1 = this.m_model.GetVertexNormal(indices.I2);
                        normals2.Normals.Normal2 = this.m_model.GetVertexNormal(indices.I1);
                        MyTriangle_Vertex_Normals item = normals2;
                        retTriangles.Add(item);
                        if (retTriangles.Count == maxNeighbourTriangles)
                        {
                            return true;
                        }
                    }
                Label_01C3:
                    return false;
                });
            }
        }

        private void UpdateCache()
        {
            if (this.m_bounds == null)
            {
                lock (this.m_bvh)
                {
                    if (this.m_bounds == null)
                    {
                        int trianglesCount = this.m_model.GetTrianglesCount();
                        this.m_bounds = new BoundingBox[trianglesCount];
                        this.m_planes = new Plane[trianglesCount];
                        for (int i = 0; i < trianglesCount; i++)
                        {
                            MyTriangleVertexIndices indices = this.m_model.Triangles[i];
                            MyTriangle_Vertices vertices = new MyTriangle_Vertices {
                                Vertex0 = PositionPacker.UnpackPosition(ref this.m_model.Vertices[indices.I0].Position),
                                Vertex1 = PositionPacker.UnpackPosition(ref this.m_model.Vertices[indices.I1].Position),
                                Vertex2 = PositionPacker.UnpackPosition(ref this.m_model.Vertices[indices.I2].Position)
                            };
                            this.m_bounds[i].Min = this.m_bounds[i].Max = vertices.Vertex0;
                            this.m_bounds[i].Include(ref vertices.Vertex1);
                            this.m_bounds[i].Include(ref vertices.Vertex2);
                            this.m_planes[i] = new Plane(ref vertices.Vertex0, ref vertices.Vertex1, ref vertices.Vertex2);
                        }
                    }
                }
            }
        }

        private static MyQuantizedBvhResult Result =>
            (m_resultThreadStatic ?? (m_resultThreadStatic = new MyQuantizedBvhResult()));

        private static MyQuantizedBvhAllTrianglesResult ResultAll =>
            (m_resultAllThreadStatic ?? (m_resultAllThreadStatic = new MyQuantizedBvhAllTrianglesResult()));

        public int Size =>
            this.m_bvh.Size;
    }
}

