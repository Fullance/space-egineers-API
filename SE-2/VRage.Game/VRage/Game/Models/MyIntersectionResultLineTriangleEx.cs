namespace VRage.Game.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage;
    using VRage.ModAPI;
    using VRage.Utils;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyIntersectionResultLineTriangleEx
    {
        public MyIntersectionResultLineTriangle Triangle;
        public Vector3 IntersectionPointInObjectSpace;
        public Vector3D IntersectionPointInWorldSpace;
        public IMyEntity Entity;
        public object UserObject;
        public Vector3 NormalInWorldSpace;
        public Vector3 NormalInObjectSpace;
        public Line InputLineInObjectSpace;
        public MyIntersectionResultLineTriangleEx(MyIntersectionResultLineTriangle triangle, IMyEntity entity, ref Line line)
        {
            this.Triangle = triangle;
            this.Entity = entity;
            this.InputLineInObjectSpace = line;
            this.UserObject = null;
            this.NormalInObjectSpace = MyUtils.GetNormalVectorFromTriangle(ref this.Triangle.InputTriangle);
            if (!this.NormalInObjectSpace.IsValid())
            {
                this.NormalInObjectSpace = new Vector3(0f, 0f, 1f);
            }
            this.IntersectionPointInObjectSpace = line.From + ((Vector3) (line.Direction * this.Triangle.Distance));
            if (this.Entity is IMyVoxelBase)
            {
                this.IntersectionPointInWorldSpace = this.IntersectionPointInObjectSpace + ((IMyVoxelBase) this.Entity).PositionLeftBottomCorner;
                this.NormalInWorldSpace = this.NormalInObjectSpace;
            }
            else
            {
                MatrixD worldMatrix = this.Entity.WorldMatrix;
                this.NormalInWorldSpace = (Vector3) MyUtils.GetTransformNormalNormalized(this.NormalInObjectSpace, ref worldMatrix);
                this.IntersectionPointInWorldSpace = Vector3D.Transform(this.IntersectionPointInObjectSpace, ref worldMatrix);
            }
        }

        public MyIntersectionResultLineTriangleEx(MyIntersectionResultLineTriangle triangle, IMyEntity entity, ref Line line, Vector3D intersectionPointInWorldSpace, Vector3 normalInWorldSpace)
        {
            this.Triangle = triangle;
            this.Entity = entity;
            this.InputLineInObjectSpace = line;
            this.UserObject = null;
            this.NormalInObjectSpace = this.NormalInWorldSpace = normalInWorldSpace;
            this.IntersectionPointInWorldSpace = intersectionPointInWorldSpace;
            this.IntersectionPointInObjectSpace = (Vector3) this.IntersectionPointInWorldSpace;
        }

        public VertexBoneIndicesWeights? GetAffectingBoneIndicesWeights(ref List<VertexArealBoneIndexWeight> tmpStorage)
        {
            float num;
            float num2;
            float num3;
            if (!this.Triangle.BoneWeights.HasValue)
            {
                return null;
            }
            if (tmpStorage == null)
            {
                tmpStorage = new List<VertexArealBoneIndexWeight>(4);
            }
            tmpStorage.Clear();
            MyTriangle_BoneIndicesWeigths weigths = this.Triangle.BoneWeights.Value;
            Vector3.Barycentric(this.IntersectionPointInObjectSpace, this.Triangle.InputTriangle.Vertex0, this.Triangle.InputTriangle.Vertex1, this.Triangle.InputTriangle.Vertex2, out num, out num2, out num3);
            this.FillIndicesWeightsStorage(tmpStorage, ref weigths.Vertex0, num);
            this.FillIndicesWeightsStorage(tmpStorage, ref weigths.Vertex1, num2);
            this.FillIndicesWeightsStorage(tmpStorage, ref weigths.Vertex2, num3);
            tmpStorage.Sort(new Comparison<VertexArealBoneIndexWeight>(this.Comparison));
            VertexBoneIndicesWeights indicesWeights = new VertexBoneIndicesWeights();
            this.FillIndicesWeights(ref indicesWeights, 0, tmpStorage);
            this.FillIndicesWeights(ref indicesWeights, 1, tmpStorage);
            this.FillIndicesWeights(ref indicesWeights, 2, tmpStorage);
            this.FillIndicesWeights(ref indicesWeights, 3, tmpStorage);
            this.NormalizeBoneWeights(ref indicesWeights);
            return new VertexBoneIndicesWeights?(indicesWeights);
        }

        private int Comparison(VertexArealBoneIndexWeight x, VertexArealBoneIndexWeight y)
        {
            if (x.Weight > y.Weight)
            {
                return -1;
            }
            if (x.Weight == y.Weight)
            {
                return 0;
            }
            return 1;
        }

        private void FillIndicesWeights(ref VertexBoneIndicesWeights indicesWeights, int index, List<VertexArealBoneIndexWeight> tmpStorage)
        {
            if (index < tmpStorage.Count)
            {
                indicesWeights.Indices[index] = tmpStorage[index].Index;
                indicesWeights.Weights[index] = tmpStorage[index].Weight;
            }
        }

        private void FillIndicesWeightsStorage(List<VertexArealBoneIndexWeight> tmpStorage, ref MyVertex_BoneIndicesWeights indicesWeights, float arealCoord)
        {
            this.HandleAddBoneIndexWeight(tmpStorage, ref indicesWeights, 0, arealCoord);
            this.HandleAddBoneIndexWeight(tmpStorage, ref indicesWeights, 1, arealCoord);
            this.HandleAddBoneIndexWeight(tmpStorage, ref indicesWeights, 2, arealCoord);
            this.HandleAddBoneIndexWeight(tmpStorage, ref indicesWeights, 3, arealCoord);
        }

        private void HandleAddBoneIndexWeight(List<VertexArealBoneIndexWeight> tmpStorage, ref MyVertex_BoneIndicesWeights indicesWeights, int index, float arealCoord)
        {
            float num = indicesWeights.Weights[index];
            if (num != 0f)
            {
                byte boneIndex = indicesWeights.Indices[index];
                int num3 = this.FindExsistingBoneIndexWeight(tmpStorage, boneIndex);
                if (num3 == -1)
                {
                    VertexArealBoneIndexWeight item = new VertexArealBoneIndexWeight {
                        Index = boneIndex,
                        Weight = num * arealCoord
                    };
                    tmpStorage.Add(item);
                }
                else
                {
                    VertexArealBoneIndexWeight weight2 = tmpStorage[num3];
                    weight2.Weight += num * arealCoord;
                    tmpStorage[num3] = weight2;
                }
            }
        }

        private int FindExsistingBoneIndexWeight(List<VertexArealBoneIndexWeight> tmpStorage, int boneIndex)
        {
            for (int i = 0; i < tmpStorage.Count; i++)
            {
                if (tmpStorage[i].Index == boneIndex)
                {
                    return i;
                }
            }
            return -1;
        }

        private unsafe void NormalizeBoneWeights(ref VertexBoneIndicesWeights indicesWeights)
        {
            float num = 0f;
            for (int i = 0; i < 4; i++)
            {
                num += indicesWeights.Weights[i];
            }
            for (int j = 0; j < 4; j++)
            {
                ref Vector4 vectorRef;
                int num4;
                (vectorRef = (Vector4) &indicesWeights.Weights)[num4 = j] = vectorRef[num4] / num;
            }
        }

        public static MyIntersectionResultLineTriangleEx? GetCloserIntersection(ref MyIntersectionResultLineTriangleEx? a, ref MyIntersectionResultLineTriangleEx? b)
        {
            if ((a.HasValue || !b.HasValue) && ((!a.HasValue || !b.HasValue) || (b.Value.Triangle.Distance >= a.Value.Triangle.Distance)))
            {
                return a;
            }
            return b;
        }

        public static bool IsDistanceLessThanTolerance(ref MyIntersectionResultLineTriangleEx? a, ref MyIntersectionResultLineTriangleEx? b, float distanceTolerance)
        {
            if ((a.HasValue || !b.HasValue) && ((!a.HasValue || !b.HasValue) || (Math.Abs((float) (b.Value.Triangle.Distance - a.Value.Triangle.Distance)) > distanceTolerance)))
            {
                return false;
            }
            return true;
        }
    }
}

