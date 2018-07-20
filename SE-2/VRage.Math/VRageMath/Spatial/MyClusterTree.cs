namespace VRageMath.Spatial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using VRage;
    using VRage.Collections;
    using VRageMath;

    public class MyClusterTree
    {
        public const ulong CLUSTERED_OBJECT_ID_UNITIALIZED = ulong.MaxValue;
        public readonly bool ForcedClusters;
        public Func<long, bool> GetEntityReplicableExistsById;
        public static Vector3 IdealClusterSize = new Vector3(20000f);
        public static Vector3 IdealClusterSizeHalfSqr = ((Vector3) ((IdealClusterSize * IdealClusterSize) / 4f));
        private ulong m_clusterObjectCounter;
        private List<MyCluster> m_clusters = new List<MyCluster>();
        private FastResourceLock m_clustersLock = new FastResourceLock();
        private FastResourceLock m_clustersReorderLock = new FastResourceLock();
        private MyDynamicAABBTreeD m_clusterTree = new MyDynamicAABBTreeD(Vector3D.Zero, 1.0);
        [ThreadStatic]
        private static List<MyLineSegmentOverlapResult<MyCluster>> m_lineResultListPerThread;
        [ThreadStatic]
        private static List<ulong> m_objectDataResultListPerThread;
        private Dictionary<ulong, MyObjectData> m_objectsData = new Dictionary<ulong, MyObjectData>();
        [ThreadStatic]
        private static List<MyCluster> m_resultListPerThread;
        private List<MyCluster> m_returnedClusters = new List<MyCluster>(1);
        private MyDynamicAABBTreeD m_staticTree = new MyDynamicAABBTreeD(Vector3D.Zero, 1.0);
        private bool m_suppressClusterReorder;
        private List<object> m_userObjects = new List<object>();
        public static Vector3 MaximumForSplit = ((Vector3) (IdealClusterSize * 2f));
        public static Vector3 MinimumDistanceFromBorder = ((Vector3) (IdealClusterSize / 10f));
        public Func<int, BoundingBoxD, object> OnClusterCreated;
        public Action<object> OnClusterRemoved;
        public Action OnClustersReordered;
        public Action<object> OnFinishBatch;
        public readonly BoundingBoxD? SingleCluster;

        public MyClusterTree(BoundingBoxD? singleCluster, bool forcedClusters)
        {
            this.SingleCluster = singleCluster;
            this.ForcedClusters = forcedClusters;
        }

        public ulong AddObject(BoundingBoxD bbox, IMyActivationHandler activationHandler, ulong? customId, string tag, long entityId, bool batch)
        {
            using (this.m_clustersLock.AcquireExclusiveUsing())
            {
                BoundingBoxD inflated;
                ulong num5;
                if (this.SingleCluster.HasValue && (this.m_clusters.Count == 0))
                {
                    BoundingBoxD clusterBB = this.SingleCluster.Value;
                    clusterBB.Inflate((double) 200.0);
                    this.CreateCluster(ref clusterBB);
                }
                if (this.SingleCluster.HasValue || this.ForcedClusters)
                {
                    inflated = bbox;
                }
                else
                {
                    inflated = bbox.GetInflated(MinimumDistanceFromBorder);
                }
                this.m_clusterTree.OverlapAllBoundingBox<MyCluster>(ref inflated, this.m_returnedClusters, 0, true);
                MyCluster cluster = null;
                bool flag = false;
                if (this.m_returnedClusters.Count == 1)
                {
                    if (this.m_returnedClusters[0].AABB.Contains(inflated) == ContainmentType.Contains)
                    {
                        cluster = this.m_returnedClusters[0];
                    }
                    else if ((this.m_returnedClusters[0].AABB.Contains(inflated) == ContainmentType.Intersects) && activationHandler.IsStaticForCluster)
                    {
                        if (this.m_returnedClusters[0].AABB.Contains(bbox) != ContainmentType.Disjoint)
                        {
                            cluster = this.m_returnedClusters[0];
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else if (this.m_returnedClusters.Count > 1)
                {
                    if (!activationHandler.IsStaticForCluster)
                    {
                        flag = true;
                    }
                }
                else if (this.m_returnedClusters.Count == 0)
                {
                    if (this.SingleCluster.HasValue)
                    {
                        return ulong.MaxValue;
                    }
                    if (!activationHandler.IsStaticForCluster)
                    {
                        BoundingBoxD xd3 = new BoundingBoxD(bbox.Center - ((Vector3D) (IdealClusterSize / 2f)), bbox.Center + ((Vector3D) (IdealClusterSize / 2f)));
                        this.m_clusterTree.OverlapAllBoundingBox<MyCluster>(ref xd3, this.m_returnedClusters, 0, true);
                        if (this.m_returnedClusters.Count == 0)
                        {
                            this.m_staticTree.OverlapAllBoundingBox<ulong>(ref xd3, m_objectDataResultList, 0, true);
                            cluster = this.CreateCluster(ref xd3);
                            foreach (ulong num in m_objectDataResultList)
                            {
                                if (this.m_objectsData[num].Cluster == null)
                                {
                                    this.AddObjectToCluster(cluster, num, false);
                                }
                            }
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                }
                ulong objectId = customId.HasValue ? customId.Value : num5;
                int num3 = -1;
                MyObjectData data = new MyObjectData {
                    Id = objectId,
                    Cluster = cluster,
                    ActivationHandler = activationHandler,
                    AABB = bbox,
                    StaticId = num3,
                    Tag = tag,
                    EntityId = entityId
                };
                this.m_objectsData[objectId] = data;
                if ((flag && !this.SingleCluster.HasValue) && !this.ForcedClusters)
                {
                    this.ReorderClusters(bbox, objectId);
                    bool isStaticForCluster = this.m_objectsData[objectId].ActivationHandler.IsStaticForCluster;
                }
                if (activationHandler.IsStaticForCluster)
                {
                    num3 = this.m_staticTree.AddProxy(ref bbox, objectId, 0, true);
                    this.m_objectsData[objectId].StaticId = num3;
                }
                if (cluster != null)
                {
                    return this.AddObjectToCluster(cluster, objectId, batch);
                }
                return objectId;
            }
        }

        private ulong AddObjectToCluster(MyCluster cluster, ulong objectId, bool batch)
        {
            cluster.Objects.Add(objectId);
            MyObjectData data = this.m_objectsData[objectId];
            this.m_objectsData[objectId].Id = objectId;
            this.m_objectsData[objectId].Cluster = cluster;
            if (batch)
            {
                if (data.ActivationHandler != null)
                {
                    data.ActivationHandler.ActivateBatch(cluster.UserData, objectId);
                }
                return objectId;
            }
            if (data.ActivationHandler != null)
            {
                data.ActivationHandler.Activate(cluster.UserData, objectId);
            }
            return objectId;
        }

        public static BoundingBoxD AdjustAABBByVelocity(BoundingBoxD aabb, Vector3 velocity, float inflate = 1.1f)
        {
            if (velocity.LengthSquared() > 0.001f)
            {
                velocity.Normalize();
            }
            aabb.Inflate((double) inflate);
            BoundingBoxD box = aabb;
            box += (BoundingBoxD) ((velocity * 2000f) * inflate);
            aabb.Include(box);
            return aabb;
        }

        public void CastRay(Vector3D from, Vector3D to, List<MyClusterQueryResult> results)
        {
            if ((this.m_clusterTree != null) && (results != null))
            {
                LineD line = new LineD(from, to);
                this.m_clusterTree.OverlapAllLineSegment<MyCluster>(ref line, m_lineResultList, true);
                foreach (MyLineSegmentOverlapResult<MyCluster> result in m_lineResultList)
                {
                    if (result.Element != null)
                    {
                        MyClusterQueryResult item = new MyClusterQueryResult {
                            AABB = result.Element.AABB,
                            UserData = result.Element.UserData
                        };
                        results.Add(item);
                    }
                }
            }
        }

        private MyCluster CreateCluster(ref BoundingBoxD clusterBB)
        {
            MyCluster userData = new MyCluster {
                AABB = clusterBB,
                Objects = new HashSet<ulong>()
            };
            userData.ClusterId = this.m_clusterTree.AddProxy(ref userData.AABB, userData, 0, true);
            if (this.OnClusterCreated != null)
            {
                userData.UserData = this.OnClusterCreated(userData.ClusterId, userData.AABB);
            }
            this.m_clusters.Add(userData);
            this.m_userObjects.Add(userData.UserData);
            return userData;
        }

        public void Deserialize(List<BoundingBoxD> list)
        {
            foreach (MyObjectData data in this.m_objectsData.Values)
            {
                if (data.Cluster != null)
                {
                    this.RemoveObjectFromCluster(data, true);
                }
            }
            foreach (MyObjectData data2 in this.m_objectsData.Values)
            {
                if (data2.Cluster != null)
                {
                    data2.ActivationHandler.FinishRemoveBatch(data2.Cluster.UserData);
                    data2.Cluster = null;
                }
            }
            foreach (MyCluster cluster in this.m_clusters)
            {
                if (this.OnFinishBatch != null)
                {
                    this.OnFinishBatch(cluster.UserData);
                }
            }
            while (this.m_clusters.Count > 0)
            {
                this.RemoveCluster(this.m_clusters[0]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                BoundingBoxD clusterBB = list[i];
                this.CreateCluster(ref clusterBB);
            }
            foreach (KeyValuePair<ulong, MyObjectData> pair in this.m_objectsData)
            {
                this.m_clusterTree.OverlapAllBoundingBox<MyCluster>(ref pair.Value.AABB, this.m_returnedClusters, 0, true);
                if ((this.m_returnedClusters.Count != 1) && !pair.Value.ActivationHandler.IsStaticForCluster)
                {
                    throw new Exception($"Inconsistent objects and deserialized clusters. Entity name: {pair.Value.Tag}, Found clusters: {this.m_returnedClusters.Count}, Replicable exists: {this.GetEntityReplicableExistsById(pair.Value.EntityId)}");
                }
                if (this.m_returnedClusters.Count == 1)
                {
                    this.AddObjectToCluster(this.m_returnedClusters[0], pair.Key, true);
                }
            }
            foreach (MyCluster cluster2 in this.m_clusters)
            {
                if (this.OnFinishBatch != null)
                {
                    this.OnFinishBatch(cluster2.UserData);
                }
                foreach (ulong num2 in cluster2.Objects)
                {
                    if (this.m_objectsData[num2].ActivationHandler != null)
                    {
                        this.m_objectsData[num2].ActivationHandler.FinishAddBatch();
                    }
                }
            }
        }

        public void Dispose()
        {
            foreach (MyCluster cluster in this.m_clusters)
            {
                if (this.OnClusterRemoved != null)
                {
                    this.OnClusterRemoved(cluster.UserData);
                }
            }
            this.m_clusters.Clear();
            this.m_userObjects.Clear();
            this.m_clusterTree.Clear();
            this.m_objectsData.Clear();
            this.m_staticTree.Clear();
            this.m_clusterObjectCounter = 0L;
        }

        public void EnsureClusterSpace(BoundingBoxD aabb)
        {
            if (!this.SingleCluster.HasValue && !this.ForcedClusters)
            {
                using (this.m_clustersLock.AcquireExclusiveUsing())
                {
                    this.m_clusterTree.OverlapAllBoundingBox<MyCluster>(ref aabb, this.m_returnedClusters, 0, true);
                    bool flag = true;
                    if ((this.m_returnedClusters.Count == 1) && (this.m_returnedClusters[0].AABB.Contains(aabb) == ContainmentType.Contains))
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        ulong num3;
                        this.m_clusterObjectCounter = (num3 = this.m_clusterObjectCounter) + ((ulong) 1L);
                        ulong objectId = num3;
                        int num2 = -1;
                        MyObjectData data = new MyObjectData {
                            Id = objectId,
                            Cluster = null,
                            ActivationHandler = null,
                            AABB = aabb,
                            StaticId = num2
                        };
                        this.m_objectsData[objectId] = data;
                        this.ReorderClusters(aabb, objectId);
                        this.RemoveObjectFromCluster(this.m_objectsData[objectId], false);
                        this.m_objectsData.Remove(objectId);
                    }
                }
            }
        }

        public void GetAll(List<MyClusterQueryResult> results)
        {
            this.m_clusterTree.GetAll<MyCluster>(m_resultList, true, null);
            foreach (MyCluster cluster in m_resultList)
            {
                MyClusterQueryResult item = new MyClusterQueryResult {
                    AABB = cluster.AABB,
                    UserData = cluster.UserData
                };
                results.Add(item);
            }
        }

        public void GetAllStaticObjects(List<BoundingBoxD> staticObjects)
        {
            this.m_staticTree.GetAll<ulong>(m_objectDataResultList, true, null);
            staticObjects.Clear();
            foreach (ulong num in m_objectDataResultList)
            {
                staticObjects.Add(this.m_objectsData[num].AABB);
            }
        }

        public object GetClusterForPosition(Vector3D pos)
        {
            BoundingSphereD sphere = new BoundingSphereD(pos, 1.0);
            this.m_clusterTree.OverlapAllBoundingSphere<MyCluster>(ref sphere, this.m_returnedClusters, true);
            if (this.m_returnedClusters.Count <= 0)
            {
                return null;
            }
            return this.m_returnedClusters.Single<MyCluster>().UserData;
        }

        public ListReader<MyCluster> GetClusters() => 
            this.m_clusters;

        public ListReader<object> GetList() => 
            new ListReader<object>(this.m_userObjects);

        public ListReader<object> GetListCopy() => 
            new ListReader<object>(new List<object>(this.m_userObjects));

        public Vector3D GetObjectOffset(ulong id)
        {
            MyObjectData data;
            if (!this.m_objectsData.TryGetValue(id, out data))
            {
                return Vector3D.Zero;
            }
            if (data.Cluster == null)
            {
                return Vector3D.Zero;
            }
            return data.Cluster.AABB.Center;
        }

        public void Intersects(Vector3D translation, List<MyClusterQueryResult> results)
        {
            BoundingBoxD bbox = new BoundingBoxD(translation - new Vector3D(1.0), translation + new Vector3D(1.0));
            this.m_clusterTree.OverlapAllBoundingBox<MyCluster>(ref bbox, m_resultList, 0, true);
            foreach (MyCluster cluster in m_resultList)
            {
                MyClusterQueryResult item = new MyClusterQueryResult {
                    AABB = cluster.AABB,
                    UserData = cluster.UserData
                };
                results.Add(item);
            }
        }

        public void MoveObject(ulong id, BoundingBoxD aabb, Vector3 velocity)
        {
            using (this.m_clustersLock.AcquireExclusiveUsing())
            {
                MyObjectData data;
                if (this.m_objectsData.TryGetValue(id, out data))
                {
                    BoundingBoxD aABB = data.AABB;
                    data.AABB = aabb;
                    if (!this.m_suppressClusterReorder)
                    {
                        aabb = AdjustAABBByVelocity(aabb, velocity, 0f);
                        ContainmentType type = data.Cluster.AABB.Contains(aabb);
                        if (((type != ContainmentType.Contains) && !this.SingleCluster.HasValue) && !this.ForcedClusters)
                        {
                            if (type == ContainmentType.Disjoint)
                            {
                                this.m_clusterTree.OverlapAllBoundingBox<MyCluster>(ref aabb, this.m_returnedClusters, 0, true);
                                if ((this.m_returnedClusters.Count == 1) && (this.m_returnedClusters[0].AABB.Contains(aabb) == ContainmentType.Contains))
                                {
                                    MyCluster cluster = data.Cluster;
                                    this.RemoveObjectFromCluster(data, false);
                                    if (cluster.Objects.Count == 0)
                                    {
                                        this.RemoveCluster(cluster);
                                    }
                                    this.AddObjectToCluster(this.m_returnedClusters[0], data.Id, false);
                                }
                                else
                                {
                                    aabb.InflateToMinimum(IdealClusterSize);
                                    this.ReorderClusters(aabb.Include(aABB), id);
                                }
                            }
                            else
                            {
                                aabb.InflateToMinimum(IdealClusterSize);
                                this.ReorderClusters(aabb.Include(aABB), id);
                            }
                        }
                    }
                }
            }
        }

        private void RemoveCluster(MyCluster cluster)
        {
            this.m_clusterTree.RemoveProxy(cluster.ClusterId);
            this.m_clusters.Remove(cluster);
            this.m_userObjects.Remove(cluster.UserData);
            if (this.OnClusterRemoved != null)
            {
                this.OnClusterRemoved(cluster.UserData);
            }
        }

        public void RemoveObject(ulong id)
        {
            MyObjectData data;
            if (this.m_objectsData.TryGetValue(id, out data))
            {
                MyCluster cluster = data.Cluster;
                if (cluster != null)
                {
                    this.RemoveObjectFromCluster(data, false);
                    if (cluster.Objects.Count == 0)
                    {
                        this.RemoveCluster(cluster);
                    }
                }
                if (data.StaticId != -1)
                {
                    this.m_staticTree.RemoveProxy(data.StaticId);
                    data.StaticId = -1;
                }
                this.m_objectsData.Remove(id);
            }
        }

        private void RemoveObjectFromCluster(MyObjectData objectData, bool batch)
        {
            objectData.Cluster.Objects.Remove(objectData.Id);
            if (batch)
            {
                if (objectData.ActivationHandler != null)
                {
                    objectData.ActivationHandler.DeactivateBatch(objectData.Cluster.UserData);
                }
            }
            else
            {
                if (objectData.ActivationHandler != null)
                {
                    objectData.ActivationHandler.Deactivate(objectData.Cluster.UserData);
                }
                this.m_objectsData[objectData.Id].Cluster = null;
            }
        }

        public void ReorderClusters(BoundingBoxD aabb, ulong objectId = 18446744073709551615L)
        {
            using (this.m_clustersReorderLock.AcquireExclusiveUsing())
            {
                aabb.InflateToMinimum(IdealClusterSize);
                bool flag = false;
                BoundingBoxD bbox = aabb;
                this.m_clusterTree.OverlapAllBoundingBox<MyCluster>(ref bbox, m_resultList, 0, true);
                HashSet<MyObjectData> source = new HashSet<MyObjectData>();
                while (!flag)
                {
                    source.Clear();
                    if (objectId != ulong.MaxValue)
                    {
                        source.Add(this.m_objectsData[objectId]);
                    }
                    using (List<MyCluster>.Enumerator enumerator = m_resultList.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            Func<KeyValuePair<ulong, MyObjectData>, bool> predicate = null;
                            MyCluster collidedCluster = enumerator.Current;
                            bbox.Include(collidedCluster.AABB);
                            if (predicate == null)
                            {
                                predicate = x => collidedCluster.Objects.Contains(x.Key);
                            }
                            foreach (MyObjectData data in from x in this.m_objectsData.Where<KeyValuePair<ulong, MyObjectData>>(predicate) select x.Value)
                            {
                                source.Add(data);
                            }
                        }
                    }
                    int num = m_resultList.Count;
                    this.m_clusterTree.OverlapAllBoundingBox<MyCluster>(ref bbox, m_resultList, 0, true);
                    flag = num == m_resultList.Count;
                    this.m_staticTree.OverlapAllBoundingBox<ulong>(ref bbox, m_objectDataResultList, 0, true);
                    foreach (ulong num2 in m_objectDataResultList)
                    {
                        if ((this.m_objectsData[num2].Cluster != null) && !m_resultList.Contains(this.m_objectsData[num2].Cluster))
                        {
                            bbox.Include(this.m_objectsData[num2].Cluster.AABB);
                            flag = false;
                        }
                    }
                }
                this.m_staticTree.OverlapAllBoundingBox<ulong>(ref bbox, m_objectDataResultList, 0, true);
                foreach (ulong num3 in m_objectDataResultList)
                {
                    source.Add(this.m_objectsData[num3]);
                }
                Stack<MyClusterDescription> stack = new Stack<MyClusterDescription>();
                List<MyClusterDescription> list = new List<MyClusterDescription>();
                MyClusterDescription item = new MyClusterDescription {
                    AABB = bbox,
                    DynamicObjects = source.Where<MyObjectData>(delegate (MyObjectData x) {
                        if (x.ActivationHandler != null)
                        {
                            return !x.ActivationHandler.IsStaticForCluster;
                        }
                        return true;
                    }).ToList<MyObjectData>(),
                    StaticObjects = (from x in source
                        where (x.ActivationHandler != null) && x.ActivationHandler.IsStaticForCluster
                        select x).ToList<MyObjectData>()
                };
                stack.Push(item);
                List<MyObjectData> list2 = (from x in item.StaticObjects
                    where x.Cluster != null
                    select x).ToList<MyObjectData>();
                int count = item.StaticObjects.Count;
                while (stack.Count > 0)
                {
                    MyClusterDescription description2 = stack.Pop();
                    if (description2.DynamicObjects.Count != 0)
                    {
                        BoundingBoxD xd2 = BoundingBoxD.CreateInvalid();
                        for (int i = 0; i < description2.DynamicObjects.Count; i++)
                        {
                            MyObjectData data2 = description2.DynamicObjects[i];
                            BoundingBoxD inflated = data2.AABB.GetInflated((Vector3) (IdealClusterSize / 2f));
                            xd2.Include(inflated);
                        }
                        BoundingBoxD xd4 = xd2;
                        Vector3D max = xd2.Max;
                        int num5 = xd2.Size.AbsMaxComponent();
                        switch (num5)
                        {
                            case 0:
                                description2.DynamicObjects.Sort(AABBComparerX.Static);
                                break;

                            case 1:
                                description2.DynamicObjects.Sort(AABBComparerY.Static);
                                break;

                            case 2:
                                description2.DynamicObjects.Sort(AABBComparerZ.Static);
                                break;
                        }
                        bool flag2 = false;
                        if (xd2.Size.AbsMax() >= MaximumForSplit.AbsMax())
                        {
                            for (int j = 1; j < description2.DynamicObjects.Count; j++)
                            {
                                MyObjectData data3 = description2.DynamicObjects[j - 1];
                                MyObjectData data4 = description2.DynamicObjects[j];
                                BoundingBoxD xd5 = data3.AABB.GetInflated((Vector3) (IdealClusterSize / 2f));
                                if ((data4.AABB.GetInflated((Vector3) (IdealClusterSize / 2f)).Min.GetDim(num5) - xd5.Max.GetDim(num5)) > 0.0)
                                {
                                    flag2 = true;
                                    max.SetDim(num5, xd5.Max.GetDim(num5));
                                    break;
                                }
                            }
                        }
                        xd4.Max = max;
                        xd4.InflateToMinimum(IdealClusterSize);
                        MyClusterDescription description3 = new MyClusterDescription {
                            AABB = xd4,
                            DynamicObjects = new List<MyObjectData>(),
                            StaticObjects = new List<MyObjectData>()
                        };
                        foreach (MyObjectData data5 in description2.DynamicObjects.ToList<MyObjectData>())
                        {
                            if (xd4.Contains(data5.AABB) == ContainmentType.Contains)
                            {
                                description3.DynamicObjects.Add(data5);
                                description2.DynamicObjects.Remove(data5);
                            }
                        }
                        foreach (MyObjectData data6 in description2.StaticObjects.ToList<MyObjectData>())
                        {
                            switch (xd4.Contains(data6.AABB))
                            {
                                case ContainmentType.Contains:
                                case ContainmentType.Intersects:
                                    description3.StaticObjects.Add(data6);
                                    description2.StaticObjects.Remove(data6);
                                    break;
                            }
                        }
                        description3.AABB = xd4;
                        if (description2.DynamicObjects.Count > 0)
                        {
                            BoundingBoxD xd7 = BoundingBoxD.CreateInvalid();
                            foreach (MyObjectData data7 in description2.DynamicObjects)
                            {
                                xd7.Include(data7.AABB.GetInflated(MinimumDistanceFromBorder));
                            }
                            xd7.InflateToMinimum(IdealClusterSize);
                            MyClusterDescription description4 = new MyClusterDescription {
                                AABB = xd7,
                                DynamicObjects = description2.DynamicObjects.ToList<MyObjectData>(),
                                StaticObjects = description2.StaticObjects.ToList<MyObjectData>()
                            };
                            if (description4.AABB.Size.AbsMax() > (2f * IdealClusterSize.AbsMax()))
                            {
                                stack.Push(description4);
                            }
                            else
                            {
                                list.Add(description4);
                            }
                        }
                        if ((description3.AABB.Size.AbsMax() > (2f * IdealClusterSize.AbsMax())) && flag2)
                        {
                            stack.Push(description3);
                        }
                        else
                        {
                            list.Add(description3);
                        }
                    }
                }
                HashSet<MyCluster> set2 = new HashSet<MyCluster>();
                HashSet<MyCluster> set3 = new HashSet<MyCluster>();
                foreach (MyObjectData data8 in list2)
                {
                    if (data8.Cluster != null)
                    {
                        set2.Add(data8.Cluster);
                        this.RemoveObjectFromCluster(data8, true);
                    }
                }
                foreach (MyObjectData data9 in list2)
                {
                    if (data9.Cluster != null)
                    {
                        data9.ActivationHandler.FinishRemoveBatch(data9.Cluster.UserData);
                        data9.Cluster = null;
                    }
                }
                int num7 = 0;
                foreach (MyClusterDescription description7 in list)
                {
                    BoundingBoxD aABB = description7.AABB;
                    MyCluster cluster = this.CreateCluster(ref aABB);
                    foreach (MyObjectData data10 in description7.DynamicObjects)
                    {
                        if (data10.Cluster != null)
                        {
                            set2.Add(data10.Cluster);
                            this.RemoveObjectFromCluster(data10, true);
                        }
                    }
                    foreach (MyObjectData data11 in description7.DynamicObjects)
                    {
                        if (data11.Cluster != null)
                        {
                            data11.ActivationHandler.FinishRemoveBatch(data11.Cluster.UserData);
                            data11.Cluster = null;
                        }
                    }
                    foreach (MyCluster cluster2 in set2)
                    {
                        if (this.OnFinishBatch != null)
                        {
                            this.OnFinishBatch(cluster2.UserData);
                        }
                    }
                    foreach (MyObjectData data12 in description7.DynamicObjects)
                    {
                        this.AddObjectToCluster(cluster, data12.Id, true);
                    }
                    foreach (MyObjectData data13 in description7.StaticObjects)
                    {
                        if (cluster.AABB.Contains(data13.AABB) != ContainmentType.Disjoint)
                        {
                            this.AddObjectToCluster(cluster, data13.Id, true);
                            num7++;
                        }
                    }
                    set3.Add(cluster);
                }
                foreach (MyCluster cluster3 in set2)
                {
                    this.RemoveCluster(cluster3);
                }
                foreach (MyCluster cluster4 in set3)
                {
                    if (this.OnFinishBatch != null)
                    {
                        this.OnFinishBatch(cluster4.UserData);
                    }
                    foreach (ulong num8 in cluster4.Objects)
                    {
                        if (this.m_objectsData[num8].ActivationHandler != null)
                        {
                            this.m_objectsData[num8].ActivationHandler.FinishAddBatch();
                        }
                    }
                }
                if (this.OnClustersReordered != null)
                {
                    this.OnClustersReordered();
                }
            }
        }

        public void Serialize(List<BoundingBoxD> list)
        {
            foreach (MyCluster cluster in this.m_clusters)
            {
                list.Add(cluster.AABB);
            }
        }

        private static List<MyLineSegmentOverlapResult<MyCluster>> m_lineResultList
        {
            get
            {
                if (m_lineResultListPerThread == null)
                {
                    m_lineResultListPerThread = new List<MyLineSegmentOverlapResult<MyCluster>>();
                }
                return m_lineResultListPerThread;
            }
        }

        private static List<ulong> m_objectDataResultList
        {
            get
            {
                if (m_objectDataResultListPerThread == null)
                {
                    m_objectDataResultListPerThread = new List<ulong>();
                }
                return m_objectDataResultListPerThread;
            }
        }

        private static List<MyCluster> m_resultList
        {
            get
            {
                if (m_resultListPerThread == null)
                {
                    m_resultListPerThread = new List<MyCluster>();
                }
                return m_resultListPerThread;
            }
        }

        public bool SuppressClusterReorder
        {
            get => 
                this.m_suppressClusterReorder;
            set
            {
                this.m_suppressClusterReorder = value;
            }
        }

        private class AABBComparerX : IComparer<MyClusterTree.MyObjectData>
        {
            public static MyClusterTree.AABBComparerX Static = new MyClusterTree.AABBComparerX();

            public int Compare(MyClusterTree.MyObjectData x, MyClusterTree.MyObjectData y) => 
                x.AABB.Min.X.CompareTo(y.AABB.Min.X);
        }

        private class AABBComparerY : IComparer<MyClusterTree.MyObjectData>
        {
            public static MyClusterTree.AABBComparerY Static = new MyClusterTree.AABBComparerY();

            public int Compare(MyClusterTree.MyObjectData x, MyClusterTree.MyObjectData y) => 
                x.AABB.Min.Y.CompareTo(y.AABB.Min.Y);
        }

        private class AABBComparerZ : IComparer<MyClusterTree.MyObjectData>
        {
            public static MyClusterTree.AABBComparerZ Static = new MyClusterTree.AABBComparerZ();

            public int Compare(MyClusterTree.MyObjectData x, MyClusterTree.MyObjectData y) => 
                x.AABB.Min.Z.CompareTo(y.AABB.Min.Z);
        }

        public interface IMyActivationHandler
        {
            void Activate(object userData, ulong clusterObjectID);
            void ActivateBatch(object userData, ulong clusterObjectID);
            void Deactivate(object userData);
            void DeactivateBatch(object userData);
            void FinishAddBatch();
            void FinishRemoveBatch(object userData);

            bool IsStaticForCluster { get; }
        }

        public class MyCluster
        {
            public BoundingBoxD AABB;
            public int ClusterId;
            public HashSet<ulong> Objects;
            public object UserData;

            public override string ToString() => 
                string.Concat(new object[] { "MyCluster", this.ClusterId, ": ", this.AABB.Center });
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MyClusterDescription
        {
            public BoundingBoxD AABB;
            public List<MyClusterTree.MyObjectData> DynamicObjects;
            public List<MyClusterTree.MyObjectData> StaticObjects;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MyClusterQueryResult
        {
            public BoundingBoxD AABB;
            public object UserData;
        }

        private class MyObjectData
        {
            public BoundingBoxD AABB;
            public MyClusterTree.IMyActivationHandler ActivationHandler;
            public MyClusterTree.MyCluster Cluster;
            public long EntityId;
            public ulong Id;
            public int StaticId;
            public string Tag;
        }
    }
}

