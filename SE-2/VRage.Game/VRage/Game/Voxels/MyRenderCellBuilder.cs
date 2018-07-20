namespace VRage.Game.Voxels
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage;
    using VRage.Collections;
    using VRage.Utils;
    using VRage.Voxels;
    using VRageMath;
    using VRageMath.PackedVector;
    using VRageRender.Voxels;

    public class MyRenderCellBuilder
    {
        [ThreadStatic]
        private static MyRenderCellBuilder m_instance;
        private List<MyVoxelVertex> m_vertices = new List<MyVoxelVertex>();
        private const int MAX_INDICES_COUNT = 0x186a0;
        private const int MAX_INDICES_COUNT_STOP = 0x1869d;
        private const int MAX_VERTICES_COUNT = 0xffff;
        private const int MAX_VERTICES_COUNT_STOP = 0xfffc;
        private static MyConcurrentQueue<MultiMaterialHelper> MM_HelperPool = new MyConcurrentQueue<MultiMaterialHelper>();
        private readonly Dictionary<int, MultiMaterialHelper> MM_Helpers = new Dictionary<int, MultiMaterialHelper>();
        private static MyConcurrentQueue<VertexInBatchLookup> SM_BatchLookupPool = new MyConcurrentQueue<VertexInBatchLookup>();
        private readonly Dictionary<int, VertexInBatchLookup> SM_BatchLookups = new Dictionary<int, VertexInBatchLookup>();
        private static MyConcurrentQueue<SingleMaterialHelper> SM_HelperPool = new MyConcurrentQueue<SingleMaterialHelper>();
        private readonly Dictionary<int, SingleMaterialHelper> SM_Helpers = new Dictionary<int, SingleMaterialHelper>();

        private unsafe void AddIfNotPresent(int* buffer, ref int count, int length, int value)
        {
            if (count != length)
            {
                for (int i = 0; i < count; i++)
                {
                    if (buffer[i] == value)
                    {
                        return;
                    }
                }
                buffer[count++] = value;
            }
        }

        private void AddVertexToBuffer(SingleMaterialHelper materialHelper, ref MyVoxelVertex vertex, VertexInBatchLookup inBatchLookup, ushort srcVertexIdx)
        {
            if (!inBatchLookup.IsInBatch(srcVertexIdx))
            {
                int count = materialHelper.Vertices.Count;
                materialHelper.AddVertex(ref vertex);
                inBatchLookup.PutToBatch(srcVertexIdx, (ushort) count);
            }
        }

        public void BuildCell(MyIsoMesh mesh, List<MyVoxelMeshPart> outBatches, out BoundingBox bounds)
        {
            bounds = BoundingBox.CreateInvalid();
            this.m_vertices.SetSize<MyVoxelVertex>(0);
            foreach (VertexInBatchLookup lookup in this.SM_BatchLookups.Values)
            {
                lookup.ResetBatch();
            }
            for (int i = 0; i < mesh.VerticesCount; i++)
            {
                MyVoxelVertex vertex;
                this.ProcessHighVertex(mesh, i, out vertex);
            }
            for (int j = 0; j < this.m_vertices.Count; j++)
            {
                MyVoxelVertex vertex2 = this.m_vertices[j];
                bounds.Include(vertex2.Position);
            }
            for (int k = 0; k < mesh.TrianglesCount; k++)
            {
                MyVoxelTriangle triangle = mesh.Triangles[k];
                MyVoxelVertex vertex3 = this.m_vertices[triangle.V0];
                MyVoxelVertex vertex4 = this.m_vertices[triangle.V1];
                MyVoxelVertex vertex5 = this.m_vertices[triangle.V2];
                if ((vertex3.Material == vertex4.Material) && (vertex3.Material == vertex5.Material))
                {
                    SingleMaterialHelper helper;
                    VertexInBatchLookup lookup2;
                    int material = vertex3.Material;
                    if (!this.SM_Helpers.TryGetValue(material, out helper))
                    {
                        if (!SM_HelperPool.TryDequeue(out helper))
                        {
                            helper = new SingleMaterialHelper();
                        }
                        helper.Material = material;
                        this.SM_Helpers.Add(material, helper);
                    }
                    if (!this.SM_BatchLookups.TryGetValue(material, out lookup2))
                    {
                        if (!SM_BatchLookupPool.TryDequeue(out lookup2))
                        {
                            lookup2 = new VertexInBatchLookup();
                        }
                        this.SM_BatchLookups.Add(material, lookup2);
                    }
                    this.AddVertexToBuffer(helper, ref vertex3, lookup2, triangle.V0);
                    this.AddVertexToBuffer(helper, ref vertex4, lookup2, triangle.V1);
                    this.AddVertexToBuffer(helper, ref vertex5, lookup2, triangle.V2);
                    int indexCount = helper.IndexCount;
                    helper.Indices[indexCount] = lookup2.GetIndexInBatch(triangle.V0);
                    helper.Indices[indexCount + 1] = lookup2.GetIndexInBatch(triangle.V1);
                    helper.Indices[indexCount + 2] = lookup2.GetIndexInBatch(triangle.V2);
                    helper.IndexCount += 3;
                    if ((helper.Vertices.Count >= 0xfffc) || (helper.IndexCount >= 0x1869d))
                    {
                        this.EndSingleMaterial(helper, outBatches);
                    }
                }
                else
                {
                    Vector3I vectori = this.GetMaterials(ref vertex3, ref vertex4, ref vertex5);
                    int key = vectori.X + ((vectori.Y + (vectori.Z << 10)) << 10);
                    MultiMaterialHelper helper2 = null;
                    if (!this.MM_Helpers.TryGetValue(key, out helper2))
                    {
                        if (!MM_HelperPool.TryDequeue(out helper2))
                        {
                            helper2 = new MultiMaterialHelper();
                        }
                        helper2.Material0 = vectori.X;
                        helper2.Material1 = vectori.Y;
                        helper2.Material2 = vectori.Z;
                        this.MM_Helpers.Add(key, helper2);
                    }
                    helper2.AddVertex(ref vertex3);
                    helper2.AddVertex(ref vertex4);
                    helper2.AddVertex(ref vertex5);
                    if (helper2.Vertices.Count >= 0xfffc)
                    {
                        this.EndMultiMaterial(helper2, outBatches);
                    }
                }
            }
            foreach (SingleMaterialHelper helper3 in this.SM_Helpers.Values)
            {
                if (helper3.IndexCount > 0)
                {
                    this.EndSingleMaterial(helper3, outBatches);
                }
                helper3.IndexCount = 0;
                helper3.Vertices.Clear();
                SM_HelperPool.Enqueue(helper3);
            }
            this.SM_Helpers.Clear();
            foreach (MultiMaterialHelper helper4 in this.MM_Helpers.Values)
            {
                if (helper4.Vertices.Count > 0)
                {
                    this.EndMultiMaterial(helper4, outBatches);
                }
                helper4.Vertices.Clear();
                MM_HelperPool.Enqueue(helper4);
            }
            this.MM_Helpers.Clear();
            foreach (VertexInBatchLookup lookup3 in this.SM_BatchLookups.Values)
            {
                SM_BatchLookupPool.Enqueue(lookup3);
            }
            this.SM_BatchLookups.Clear();
        }

        private void EndMultiMaterial(MultiMaterialHelper helper, List<MyVoxelMeshPart> outBatches)
        {
            if (helper.Vertices.Count > 0)
            {
                MyVertexFormatVoxelSingleData[] destinationArray = new MyVertexFormatVoxelSingleData[helper.Vertices.Count];
                Array.Copy(helper.Vertices.GetInternalArray<MyVertexFormatVoxelSingleData>(), destinationArray, destinationArray.Length);
                uint[] numArray = new uint[helper.Vertices.Count];
                for (ushort i = 0; i < numArray.Length; i = (ushort) (i + 1))
                {
                    numArray[i] = i;
                }
                MyVoxelMeshPart item = new MyVoxelMeshPart {
                    Vertices = destinationArray,
                    Indices = numArray,
                    Material0 = (byte) helper.Material0,
                    Material1 = (byte) helper.Material1,
                    Material2 = (byte) helper.Material2
                };
                outBatches.Add(item);
            }
            helper.Vertices.Clear();
        }

        private void EndSingleMaterial(SingleMaterialHelper materialHelper, List<MyVoxelMeshPart> outBatches)
        {
            if ((materialHelper.IndexCount > 0) && (materialHelper.Vertices.Count > 0))
            {
                MyVertexFormatVoxelSingleData[] destinationArray = new MyVertexFormatVoxelSingleData[materialHelper.Vertices.Count];
                Array.Copy(materialHelper.Vertices.GetInternalArray<MyVertexFormatVoxelSingleData>(), destinationArray, destinationArray.Length);
                uint[] numArray = new uint[materialHelper.IndexCount];
                Array.Copy(materialHelper.Indices, numArray, numArray.Length);
                MyVoxelMeshPart item = new MyVoxelMeshPart {
                    Vertices = destinationArray,
                    Indices = numArray,
                    Material0 = (byte) materialHelper.Material,
                    Material1 = 0xff,
                    Material2 = 0xff
                };
                outBatches.Add(item);
            }
            materialHelper.IndexCount = 0;
            materialHelper.Vertices.Clear();
            this.SM_BatchLookups[materialHelper.Material].ResetBatch();
        }

        private unsafe Vector3I GetMaterials(ref MyVoxelVertex v0, ref MyVoxelVertex v1, ref MyVoxelVertex v2)
        {
            int count = 0;
            int* buffer = (int*) stackalloc byte[(((IntPtr) 3) * 4)];
            this.AddIfNotPresent(buffer, ref count, 3, v0.Material);
            this.AddIfNotPresent(buffer, ref count, 3, v1.Material);
            this.AddIfNotPresent(buffer, ref count, 3, v2.Material);
            while (count < 3)
            {
                buffer[count++] = 0;
            }
            if (buffer[0] > buffer[1])
            {
                MyUtils.Swap<int>(ref (int) ref buffer, ref (int) ref (buffer + 1));
            }
            if (buffer[1] > buffer[2])
            {
                MyUtils.Swap<int>(ref (int) ref (buffer + 1), ref (int) ref (buffer + 2));
            }
            if (buffer[0] > buffer[1])
            {
                MyUtils.Swap<int>(ref (int) ref buffer, ref (int) ref (buffer + 1));
            }
            return new Vector3I(buffer[0], buffer[1], buffer[2]);
        }

        private void ProcessHighVertex(MyIsoMesh mesh, int vertexIndex, out MyVoxelVertex vertex)
        {
            vertex = new MyVoxelVertex();
            vertex.Position = mesh.Positions[vertexIndex];
            vertex.Normal = mesh.Normals[vertexIndex];
            vertex.Material = mesh.Materials[vertexIndex];
            vertex.Cell = mesh.Cells[vertexIndex];
            vertex.ColorShiftHSV = mesh.ColorShiftHSV[vertexIndex];
            this.m_vertices.Add(vertex);
        }

        public static MyRenderCellBuilder Instance =>
            MyUtils.Init<MyRenderCellBuilder>(ref m_instance);

        private class MultiMaterialHelper
        {
            public int Material0;
            public int Material1;
            public int Material2;
            public readonly List<MyVertexFormatVoxelSingleData> Vertices = new List<MyVertexFormatVoxelSingleData>();

            public void AddVertex(ref MyVoxelVertex vertex)
            {
                byte num2;
                int material = vertex.Material;
                if (this.Material0 == material)
                {
                    num2 = 0;
                }
                else if (this.Material1 == material)
                {
                    num2 = 1;
                }
                else
                {
                    if (this.Material2 != material)
                    {
                        throw new InvalidOperationException("Should not be there, invalid material");
                    }
                    num2 = 2;
                }
                MyVertexFormatVoxelSingleData item = new MyVertexFormatVoxelSingleData {
                    Position = vertex.Position,
                    Normal = vertex.Normal,
                    Material = new Byte4((float) this.Material0, (float) this.Material1, (float) this.Material2, (float) num2),
                    PackedColorShift = vertex.ColorShiftHSV
                };
                this.Vertices.Add(item);
            }
        }

        private class SingleMaterialHelper
        {
            public int IndexCount;
            public readonly ushort[] Indices = new ushort[0x186a0];
            public int Material;
            public readonly List<MyVertexFormatVoxelSingleData> Vertices = new List<MyVertexFormatVoxelSingleData>(0xffff);

            public void AddVertex(ref MyVoxelVertex vertex)
            {
                MyVertexFormatVoxelSingleData item = new MyVertexFormatVoxelSingleData {
                    Position = vertex.Position,
                    Normal = vertex.Normal,
                    Material = new Byte4((float) this.Material, (float) this.Material, (float) this.Material, 0f),
                    PackedColorShift = vertex.ColorShiftHSV
                };
                this.Vertices.Add(item);
            }
        }

        private class VertexInBatchLookup
        {
            private readonly VertexData[] m_data = new VertexData[0xffff];
            private int m_idCounter = 1;

            internal ushort GetIndexInBatch(int vertexIndex) => 
                this.m_data[vertexIndex].IndexInBatch;

            public bool IsInBatch(int vertexIndex) => 
                (this.m_data[vertexIndex].BatchId == this.m_idCounter);

            internal void PutToBatch(ushort vertexIndex, ushort indexInBatch)
            {
                this.m_data[vertexIndex].BatchId = this.m_idCounter;
                this.m_data[vertexIndex].IndexInBatch = indexInBatch;
            }

            internal void ResetBatch()
            {
                this.m_idCounter++;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct VertexData
            {
                public ushort IndexInBatch;
                public int BatchId;
            }
        }
    }
}

