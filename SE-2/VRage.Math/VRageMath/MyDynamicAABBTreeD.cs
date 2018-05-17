namespace VRageMath
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage;

    public class MyDynamicAABBTreeD
    {
        private double m_aabbMultiplier;
        private Vector3D m_extension;
        private int m_freeList;
        private Dictionary<int, DynamicTreeNode> m_leafElementCache;
        private int m_nodeCapacity;
        private int m_nodeCount;
        private DynamicTreeNode[] m_nodes;
        [ThreadStatic]
        private static Stack<int> m_queryStack;
        private int m_root;
        private FastResourceLock m_rwLock;
        private static List<Stack<int>> m_StackCacheCollection = new List<Stack<int>>();
        public const int NullNode = -1;

        public MyDynamicAABBTreeD()
        {
            this.m_rwLock = new FastResourceLock();
            this.Init(Vector3D.One, 1.0);
        }

        public MyDynamicAABBTreeD(Vector3D extension, double aabbMultiplier = 1.0)
        {
            this.m_rwLock = new FastResourceLock();
            this.Init(extension, aabbMultiplier);
        }

        public int AddProxy(ref BoundingBoxD aabb, object userData, uint userFlags, bool rebalance = true)
        {
            using (this.m_rwLock.AcquireExclusiveUsing())
            {
                int index = this.AllocateNode();
                this.m_nodes[index].Aabb = aabb;
                this.m_nodes[index].Aabb.Min -= this.m_extension;
                this.m_nodes[index].Aabb.Max += this.m_extension;
                this.m_nodes[index].UserData = userData;
                this.m_nodes[index].UserFlag = userFlags;
                this.m_nodes[index].Height = 0;
                this.m_leafElementCache[index] = this.m_nodes[index];
                this.InsertLeaf(index, rebalance);
                return index;
            }
        }

        private int AllocateNode()
        {
            if (this.m_freeList == -1)
            {
                DynamicTreeNode[] nodes = this.m_nodes;
                this.m_nodeCapacity *= 2;
                this.m_nodes = new DynamicTreeNode[this.m_nodeCapacity];
                Array.Copy(nodes, this.m_nodes, this.m_nodeCount);
                for (int i = this.m_nodeCount; i < (this.m_nodeCapacity - 1); i++)
                {
                    this.m_nodes[i] = new DynamicTreeNode { 
                        ParentOrNext = i + 1,
                        Height = 1
                    };
                }
                DynamicTreeNode node2 = new DynamicTreeNode {
                    ParentOrNext = -1,
                    Height = 1
                };
                this.m_nodes[this.m_nodeCapacity - 1] = node2;
                this.m_freeList = this.m_nodeCount;
            }
            int freeList = this.m_freeList;
            this.m_freeList = this.m_nodes[freeList].ParentOrNext;
            this.m_nodes[freeList].ParentOrNext = -1;
            this.m_nodes[freeList].Child1 = -1;
            this.m_nodes[freeList].Child2 = -1;
            this.m_nodes[freeList].Height = 0;
            this.m_nodes[freeList].UserData = null;
            this.m_nodeCount++;
            return freeList;
        }

        public int Balance(int iA)
        {
            DynamicTreeNode node = this.m_nodes[iA];
            if (node.IsLeaf() || (node.Height < 2))
            {
                return iA;
            }
            int index = node.Child1;
            int num2 = node.Child2;
            DynamicTreeNode node2 = this.m_nodes[index];
            DynamicTreeNode node3 = this.m_nodes[num2];
            int num3 = node3.Height - node2.Height;
            if (num3 > 1)
            {
                int num4 = node3.Child1;
                int num5 = node3.Child2;
                DynamicTreeNode node4 = this.m_nodes[num4];
                DynamicTreeNode node5 = this.m_nodes[num5];
                node3.Child1 = iA;
                node3.ParentOrNext = node.ParentOrNext;
                node.ParentOrNext = num2;
                if (node3.ParentOrNext != -1)
                {
                    if (this.m_nodes[node3.ParentOrNext].Child1 == iA)
                    {
                        this.m_nodes[node3.ParentOrNext].Child1 = num2;
                    }
                    else
                    {
                        this.m_nodes[node3.ParentOrNext].Child2 = num2;
                    }
                }
                else
                {
                    this.m_root = num2;
                }
                if (node4.Height > node5.Height)
                {
                    node3.Child2 = num4;
                    node.Child2 = num5;
                    node5.ParentOrNext = iA;
                    BoundingBoxD.CreateMerged(ref node2.Aabb, ref node5.Aabb, out node.Aabb);
                    BoundingBoxD.CreateMerged(ref node.Aabb, ref node4.Aabb, out node3.Aabb);
                    node.Height = 1 + Math.Max(node2.Height, node5.Height);
                    node3.Height = 1 + Math.Max(node.Height, node4.Height);
                    return num2;
                }
                node3.Child2 = num5;
                node.Child2 = num4;
                node4.ParentOrNext = iA;
                BoundingBoxD.CreateMerged(ref node2.Aabb, ref node4.Aabb, out node.Aabb);
                BoundingBoxD.CreateMerged(ref node.Aabb, ref node5.Aabb, out node3.Aabb);
                node.Height = 1 + Math.Max(node2.Height, node4.Height);
                node3.Height = 1 + Math.Max(node.Height, node5.Height);
                return num2;
            }
            if (num3 >= -1)
            {
                return iA;
            }
            int num6 = node2.Child1;
            int num7 = node2.Child2;
            DynamicTreeNode node6 = this.m_nodes[num6];
            DynamicTreeNode node7 = this.m_nodes[num7];
            node2.Child1 = iA;
            node2.ParentOrNext = node.ParentOrNext;
            node.ParentOrNext = index;
            if (node2.ParentOrNext != -1)
            {
                if (this.m_nodes[node2.ParentOrNext].Child1 == iA)
                {
                    this.m_nodes[node2.ParentOrNext].Child1 = index;
                }
                else
                {
                    this.m_nodes[node2.ParentOrNext].Child2 = index;
                }
            }
            else
            {
                this.m_root = index;
            }
            if (node6.Height > node7.Height)
            {
                node2.Child2 = num6;
                node.Child1 = num7;
                node7.ParentOrNext = iA;
                BoundingBoxD.CreateMerged(ref node3.Aabb, ref node7.Aabb, out node.Aabb);
                BoundingBoxD.CreateMerged(ref node.Aabb, ref node6.Aabb, out node2.Aabb);
                node.Height = 1 + Math.Max(node3.Height, node7.Height);
                node2.Height = 1 + Math.Max(node.Height, node6.Height);
                return index;
            }
            node2.Child2 = num7;
            node.Child1 = num6;
            node6.ParentOrNext = iA;
            BoundingBoxD.CreateMerged(ref node3.Aabb, ref node6.Aabb, out node.Aabb);
            BoundingBoxD.CreateMerged(ref node.Aabb, ref node7.Aabb, out node2.Aabb);
            node.Height = 1 + Math.Max(node3.Height, node6.Height);
            node2.Height = 1 + Math.Max(node.Height, node7.Height);
            return index;
        }

        public void Clear()
        {
            using (this.m_rwLock.AcquireExclusiveUsing())
            {
                if ((this.m_nodeCapacity < 0x100) || (this.m_nodeCapacity > 0x200))
                {
                    this.m_nodeCapacity = 0x100;
                    this.m_nodes = new DynamicTreeNode[this.m_nodeCapacity];
                    this.m_leafElementCache = new Dictionary<int, DynamicTreeNode>(this.m_nodeCapacity / 4);
                    for (int i = 0; i < this.m_nodeCapacity; i++)
                    {
                        this.m_nodes[i] = new DynamicTreeNode();
                    }
                }
                this.ResetNodes();
            }
        }

        public int CountLeaves(int nodeId)
        {
            using (this.m_rwLock.AcquireSharedUsing())
            {
                if (nodeId == -1)
                {
                    return 0;
                }
                DynamicTreeNode node = this.m_nodes[nodeId];
                if (node.IsLeaf())
                {
                    return 1;
                }
                int num = this.CountLeaves(node.Child1);
                int num2 = this.CountLeaves(node.Child2);
                return (num + num2);
            }
        }

        public static void Dispose()
        {
            lock (m_StackCacheCollection)
            {
                m_StackCacheCollection.Clear();
            }
        }

        private void FreeNode(int nodeId)
        {
            this.m_nodes[nodeId].ParentOrNext = this.m_freeList;
            this.m_nodes[nodeId].Height = -1;
            this.m_nodes[nodeId].UserData = null;
            this.m_freeList = nodeId;
            this.m_nodeCount--;
        }

        public BoundingBoxD GetAabb(int proxyId) => 
            this.m_nodes[proxyId].Aabb;

        public void GetAll<T>(Action<T> add)
        {
            using (this.m_rwLock.AcquireSharedUsing())
            {
                foreach (KeyValuePair<int, DynamicTreeNode> pair in this.m_leafElementCache)
                {
                    T userData = (T) pair.Value.UserData;
                    add(userData);
                }
            }
        }

        public void GetAll<T>(Action<T, BoundingBoxD> add)
        {
            using (this.m_rwLock.AcquireSharedUsing())
            {
                foreach (KeyValuePair<int, DynamicTreeNode> pair in this.m_leafElementCache)
                {
                    T userData = (T) pair.Value.UserData;
                    add(userData, pair.Value.Aabb);
                }
            }
        }

        public void GetAll<T>(List<T> elementsList, bool clear, List<BoundingBoxD> boxsList = null)
        {
            if (clear)
            {
                elementsList.Clear();
                if (boxsList != null)
                {
                    boxsList.Clear();
                }
            }
            using (this.m_rwLock.AcquireSharedUsing())
            {
                foreach (KeyValuePair<int, DynamicTreeNode> pair in this.m_leafElementCache)
                {
                    elementsList.Add((T) pair.Value.UserData);
                }
                if (boxsList != null)
                {
                    foreach (KeyValuePair<int, DynamicTreeNode> pair2 in this.m_leafElementCache)
                    {
                        boxsList.Add(pair2.Value.Aabb);
                    }
                }
            }
        }

        public void GetAllNodeBounds(List<BoundingBoxD> boxsList)
        {
            using (this.m_rwLock.AcquireSharedUsing())
            {
                int index = 0;
                int num2 = 0;
                while ((index < this.m_nodeCapacity) && (num2 < this.m_nodeCount))
                {
                    if (this.m_nodes[index].Height != -1)
                    {
                        num2++;
                        boxsList.Add(this.m_nodes[index].Aabb);
                    }
                    index++;
                }
            }
        }

        public void GetAproximateClustersForAabb(ref BoundingBoxD bbox, double minSize, List<BoundingBoxD> boundList)
        {
            if (this.m_root != -1)
            {
                using (this.m_rwLock.AcquireSharedUsing())
                {
                    Stack<int> stack = this.GetStack();
                    stack.Push(this.m_root);
                    while (stack.Count > 0)
                    {
                        int index = stack.Pop();
                        if (index != -1)
                        {
                            DynamicTreeNode node = this.m_nodes[index];
                            if (node.Aabb.Intersects((BoundingBoxD) bbox))
                            {
                                if (node.IsLeaf() || (node.Aabb.Size.Max() <= minSize))
                                {
                                    boundList.Add(node.Aabb);
                                }
                                else
                                {
                                    stack.Push(node.Child1);
                                    stack.Push(node.Child2);
                                }
                            }
                        }
                    }
                    this.PushStack(stack);
                }
            }
        }

        public void GetChildren(int proxyId, out int left, out int right)
        {
            left = this.m_nodes[proxyId].Child1;
            right = this.m_nodes[proxyId].Child2;
        }

        public void GetFatAABB(int proxyId, out BoundingBoxD fatAABB)
        {
            using (this.m_rwLock.AcquireSharedUsing())
            {
                fatAABB = this.m_nodes[proxyId].Aabb;
            }
        }

        public int GetHeight()
        {
            using (this.m_rwLock.AcquireSharedUsing())
            {
                if (this.m_root == -1)
                {
                    return 0;
                }
                return this.m_nodes[this.m_root].Height;
            }
        }

        public int GetLeafCount(int proxyId)
        {
            int num = 0;
            Stack<int> stack = this.GetStack();
            stack.Push(proxyId);
            while (stack.Count > 0)
            {
                int index = stack.Pop();
                if (index != -1)
                {
                    DynamicTreeNode node = this.m_nodes[index];
                    if (node.IsLeaf())
                    {
                        num++;
                    }
                    else
                    {
                        stack.Push(node.Child1);
                        stack.Push(node.Child2);
                    }
                }
            }
            this.PushStack(stack);
            return num;
        }

        public void GetNodeLeaves(int proxyId, List<int> children)
        {
            Stack<int> stack = this.GetStack();
            stack.Push(proxyId);
            while (stack.Count > 0)
            {
                int index = stack.Pop();
                if (index != -1)
                {
                    DynamicTreeNode node = this.m_nodes[index];
                    if (node.IsLeaf())
                    {
                        children.Add(index);
                    }
                    else
                    {
                        stack.Push(node.Child1);
                        stack.Push(node.Child2);
                    }
                }
            }
            this.PushStack(stack);
        }

        public int GetRoot() => 
            this.m_root;

        private Stack<int> GetStack()
        {
            Stack<int> currentThreadStack = this.CurrentThreadStack;
            currentThreadStack.Clear();
            return currentThreadStack;
        }

        public T GetUserData<T>(int proxyId) => 
            ((T) this.m_nodes[proxyId].UserData);

        private uint GetUserFlag(int proxyId) => 
            this.m_nodes[proxyId].UserFlag;

        private void Init(Vector3D extension, double aabbMultiplier)
        {
            this.m_extension = extension;
            this.m_aabbMultiplier = aabbMultiplier;
            Stack<int> currentThreadStack = this.CurrentThreadStack;
            this.Clear();
        }

        private void InsertLeaf(int leaf, bool rebalance)
        {
            if (this.m_root == -1)
            {
                this.m_root = leaf;
                this.m_nodes[this.m_root].ParentOrNext = -1;
            }
            else
            {
                BoundingBoxD aabb = this.m_nodes[leaf].Aabb;
                int root = this.m_root;
                while (!this.m_nodes[root].IsLeaf())
                {
                    int num2 = this.m_nodes[root].Child1;
                    int num3 = this.m_nodes[root].Child2;
                    if (rebalance)
                    {
                        double num8;
                        double num11;
                        double perimeter = this.m_nodes[root].Aabb.Perimeter;
                        double num5 = BoundingBoxD.CreateMerged(this.m_nodes[root].Aabb, aabb).Perimeter;
                        double num6 = 2.0 * num5;
                        double num7 = 2.0 * (num5 - perimeter);
                        if (this.m_nodes[num2].IsLeaf())
                        {
                            BoundingBoxD xd3;
                            BoundingBoxD.CreateMerged(ref aabb, ref this.m_nodes[num2].Aabb, out xd3);
                            num8 = xd3.Perimeter + num7;
                        }
                        else
                        {
                            BoundingBoxD xd4;
                            BoundingBoxD.CreateMerged(ref aabb, ref this.m_nodes[num2].Aabb, out xd4);
                            double num9 = this.m_nodes[num2].Aabb.Perimeter;
                            num8 = (xd4.Perimeter - num9) + num7;
                        }
                        if (this.m_nodes[num3].IsLeaf())
                        {
                            BoundingBoxD xd5;
                            BoundingBoxD.CreateMerged(ref aabb, ref this.m_nodes[num3].Aabb, out xd5);
                            num11 = xd5.Perimeter + num7;
                        }
                        else
                        {
                            BoundingBoxD xd6;
                            BoundingBoxD.CreateMerged(ref aabb, ref this.m_nodes[num3].Aabb, out xd6);
                            double num12 = this.m_nodes[num3].Aabb.Perimeter;
                            num11 = (xd6.Perimeter - num12) + num7;
                        }
                        if ((num6 < num8) && (num8 < num11))
                        {
                            break;
                        }
                        if (num8 < num11)
                        {
                            root = num2;
                        }
                        else
                        {
                            root = num3;
                        }
                    }
                    else
                    {
                        BoundingBoxD xd7;
                        BoundingBoxD xd8;
                        BoundingBoxD.CreateMerged(ref aabb, ref this.m_nodes[num2].Aabb, out xd7);
                        BoundingBoxD.CreateMerged(ref aabb, ref this.m_nodes[num3].Aabb, out xd8);
                        double num14 = (this.m_nodes[num2].Height + 1) * xd7.Perimeter;
                        double num15 = (this.m_nodes[num3].Height + 1) * xd8.Perimeter;
                        if (num14 < num15)
                        {
                            root = num2;
                        }
                        else
                        {
                            root = num3;
                        }
                    }
                }
                int index = root;
                int parentOrNext = this.m_nodes[root].ParentOrNext;
                int num18 = this.AllocateNode();
                this.m_nodes[num18].ParentOrNext = parentOrNext;
                this.m_nodes[num18].UserData = null;
                this.m_nodes[num18].Aabb = BoundingBoxD.CreateMerged(aabb, this.m_nodes[index].Aabb);
                this.m_nodes[num18].Height = this.m_nodes[index].Height + 1;
                if (parentOrNext != -1)
                {
                    if (this.m_nodes[parentOrNext].Child1 == index)
                    {
                        this.m_nodes[parentOrNext].Child1 = num18;
                    }
                    else
                    {
                        this.m_nodes[parentOrNext].Child2 = num18;
                    }
                    this.m_nodes[num18].Child1 = index;
                    this.m_nodes[num18].Child2 = leaf;
                    this.m_nodes[root].ParentOrNext = num18;
                    this.m_nodes[leaf].ParentOrNext = num18;
                }
                else
                {
                    this.m_nodes[num18].Child1 = index;
                    this.m_nodes[num18].Child2 = leaf;
                    this.m_nodes[root].ParentOrNext = num18;
                    this.m_nodes[leaf].ParentOrNext = num18;
                    this.m_root = num18;
                }
                for (root = this.m_nodes[leaf].ParentOrNext; root != -1; root = this.m_nodes[root].ParentOrNext)
                {
                    if (rebalance)
                    {
                        root = this.Balance(root);
                    }
                    int num19 = this.m_nodes[root].Child1;
                    int num20 = this.m_nodes[root].Child2;
                    this.m_nodes[root].Height = 1 + Math.Max(this.m_nodes[num19].Height, this.m_nodes[num20].Height);
                    BoundingBoxD.CreateMerged(ref this.m_nodes[num19].Aabb, ref this.m_nodes[num20].Aabb, out this.m_nodes[root].Aabb);
                }
            }
        }

        public bool MoveProxy(int proxyId, ref BoundingBoxD aabb, Vector3D displacement)
        {
            using (this.m_rwLock.AcquireExclusiveUsing())
            {
                if (this.m_nodes[proxyId].Aabb.Contains(aabb) == ContainmentType.Contains)
                {
                    return false;
                }
                this.RemoveLeaf(proxyId);
                BoundingBoxD xd = aabb;
                Vector3D extension = this.m_extension;
                xd.Min -= extension;
                xd.Max += extension;
                Vector3D vectord2 = (Vector3D) (this.m_aabbMultiplier * displacement);
                if (vectord2.X < 0.0)
                {
                    xd.Min.X += vectord2.X;
                }
                else
                {
                    xd.Max.X += vectord2.X;
                }
                if (vectord2.Y < 0.0)
                {
                    xd.Min.Y += vectord2.Y;
                }
                else
                {
                    xd.Max.Y += vectord2.Y;
                }
                if (vectord2.Z < 0.0)
                {
                    xd.Min.Z += vectord2.Z;
                }
                else
                {
                    xd.Max.Z += vectord2.Z;
                }
                this.m_nodes[proxyId].Aabb = xd;
                this.InsertLeaf(proxyId, true);
            }
            return true;
        }

        public void OverlapAllBoundingBox<T>(ref BoundingBoxD bbox, List<T> elementsList, uint requiredFlags = 0, bool clear = true)
        {
            if (clear)
            {
                elementsList.Clear();
            }
            if (this.m_root != -1)
            {
                using (this.m_rwLock.AcquireSharedUsing())
                {
                    Stack<int> stack = this.GetStack();
                    stack.Push(this.m_root);
                    while (stack.Count > 0)
                    {
                        int index = stack.Pop();
                        if (index != -1)
                        {
                            DynamicTreeNode node = this.m_nodes[index];
                            if (node.Aabb.Intersects((BoundingBoxD) bbox))
                            {
                                if (node.IsLeaf())
                                {
                                    if ((this.GetUserFlag(index) & requiredFlags) == requiredFlags)
                                    {
                                        elementsList.Add(this.GetUserData<T>(index));
                                    }
                                }
                                else
                                {
                                    stack.Push(node.Child1);
                                    stack.Push(node.Child2);
                                }
                            }
                        }
                    }
                    this.PushStack(stack);
                }
            }
        }

        public void OverlapAllBoundingSphere<T>(ref BoundingSphereD sphere, Action<T> addAction)
        {
            if (this.m_root != -1)
            {
                using (this.m_rwLock.AcquireSharedUsing())
                {
                    Stack<int> stack = this.GetStack();
                    stack.Push(this.m_root);
                    while (stack.Count > 0)
                    {
                        int index = stack.Pop();
                        if (index != -1)
                        {
                            DynamicTreeNode node = this.m_nodes[index];
                            if (node.Aabb.Intersects((BoundingSphereD) sphere))
                            {
                                if (node.IsLeaf())
                                {
                                    addAction(this.GetUserData<T>(index));
                                }
                                else
                                {
                                    stack.Push(node.Child1);
                                    stack.Push(node.Child2);
                                }
                            }
                        }
                    }
                    this.PushStack(stack);
                }
            }
        }

        public void OverlapAllBoundingSphere<T>(ref BoundingSphereD sphere, List<T> overlapElementsList, bool clear = true)
        {
            if (clear)
            {
                overlapElementsList.Clear();
            }
            this.OverlapAllBoundingSphere<T>(ref sphere, new Action<T>(overlapElementsList.Add));
        }

        public void OverlapAllFrustum<T>(ref BoundingFrustumD frustum, Action<T, bool> add)
        {
            if (this.m_root != -1)
            {
                using (this.m_rwLock.AcquireSharedUsing())
                {
                    Stack<int> stack = this.GetStack();
                    stack.Push(this.m_root);
                    while (stack.Count > 0)
                    {
                        int index = stack.Pop();
                        if (index != -1)
                        {
                            ContainmentType type;
                            DynamicTreeNode node = this.m_nodes[index];
                            frustum.Contains(ref node.Aabb, out type);
                            switch (type)
                            {
                                case ContainmentType.Contains:
                                {
                                    int count = stack.Count;
                                    stack.Push(index);
                                    while (stack.Count > count)
                                    {
                                        int num3 = stack.Pop();
                                        DynamicTreeNode node2 = this.m_nodes[num3];
                                        if (node2.IsLeaf())
                                        {
                                            add(this.GetUserData<T>(num3), true);
                                        }
                                        else
                                        {
                                            if (node2.Child1 != -1)
                                            {
                                                stack.Push(node2.Child1);
                                            }
                                            if (node2.Child2 != -1)
                                            {
                                                stack.Push(node2.Child2);
                                            }
                                        }
                                    }
                                    continue;
                                }
                                case ContainmentType.Intersects:
                                    if (node.IsLeaf())
                                    {
                                        add(this.GetUserData<T>(index), false);
                                        continue;
                                    }
                                    stack.Push(node.Child1);
                                    stack.Push(node.Child2);
                                    break;
                            }
                        }
                    }
                    this.PushStack(stack);
                }
            }
        }

        public void OverlapAllFrustum<T, TU>(ref BoundingFrustumD frustum, TU results) where T: TreeUserAction<TU>
        {
            if (this.m_root != -1)
            {
                using (this.m_rwLock.AcquireSharedUsing())
                {
                    Stack<int> stack = this.GetStack();
                    stack.Push(this.m_root);
                    while (stack.Count > 0)
                    {
                        int index = stack.Pop();
                        if (index != -1)
                        {
                            ContainmentType type;
                            DynamicTreeNode node = this.m_nodes[index];
                            frustum.Contains(ref node.Aabb, out type);
                            switch (type)
                            {
                                case ContainmentType.Contains:
                                {
                                    int count = stack.Count;
                                    stack.Push(index);
                                    while (stack.Count > count)
                                    {
                                        int num3 = stack.Pop();
                                        DynamicTreeNode node2 = this.m_nodes[num3];
                                        if (node2.IsLeaf())
                                        {
                                            this.GetUserData<T>(num3).Add(results, true);
                                        }
                                        else
                                        {
                                            if (node2.Child1 != -1)
                                            {
                                                stack.Push(node2.Child1);
                                            }
                                            if (node2.Child2 != -1)
                                            {
                                                stack.Push(node2.Child2);
                                            }
                                        }
                                    }
                                    continue;
                                }
                                case ContainmentType.Intersects:
                                    if (node.IsLeaf())
                                    {
                                        this.GetUserData<T>(index).Add(results, false);
                                        continue;
                                    }
                                    stack.Push(node.Child1);
                                    stack.Push(node.Child2);
                                    break;
                            }
                        }
                    }
                    this.PushStack(stack);
                }
            }
        }

        public void OverlapAllFrustum<T>(ref BoundingFrustumD frustum, List<T> elementsList, bool clear = true)
        {
            this.OverlapAllFrustum<T>(ref frustum, elementsList, (uint) 0, clear);
        }

        public void OverlapAllFrustum<T>(ref BoundingFrustumD frustum, Action<T, bool> add, float projectionFactor, float ignoreThr)
        {
            if (this.m_root != -1)
            {
                using (this.m_rwLock.AcquireSharedUsing())
                {
                    Stack<int> stack = this.GetStack();
                    stack.Push(this.m_root);
                    float num = projectionFactor * projectionFactor;
                    float num2 = ignoreThr * ignoreThr;
                    while (stack.Count > 0)
                    {
                        int index = stack.Pop();
                        if (index != -1)
                        {
                            ContainmentType type;
                            DynamicTreeNode node = this.m_nodes[index];
                            frustum.Contains(ref node.Aabb, out type);
                            switch (type)
                            {
                                case ContainmentType.Contains:
                                {
                                    int count = stack.Count;
                                    stack.Push(index);
                                    while (stack.Count > count)
                                    {
                                        int num5 = stack.Pop();
                                        DynamicTreeNode node2 = this.m_nodes[num5];
                                        if (node2.IsLeaf())
                                        {
                                            if ((node2.Aabb.Size.LengthSquared() * num) > num2)
                                            {
                                                add(this.GetUserData<T>(num5), true);
                                            }
                                        }
                                        else
                                        {
                                            if (node2.Child1 != -1)
                                            {
                                                stack.Push(node2.Child1);
                                            }
                                            if (node2.Child2 != -1)
                                            {
                                                stack.Push(node2.Child2);
                                            }
                                        }
                                    }
                                    continue;
                                }
                                case ContainmentType.Intersects:
                                    if (node.IsLeaf())
                                    {
                                        if ((node.Aabb.Size.LengthSquared() * num) > num2)
                                        {
                                            add(this.GetUserData<T>(index), false);
                                        }
                                        continue;
                                    }
                                    stack.Push(node.Child1);
                                    stack.Push(node.Child2);
                                    break;
                            }
                        }
                    }
                    this.PushStack(stack);
                }
            }
        }

        public void OverlapAllFrustum<T>(ref BoundingFrustumD frustum, List<T> elementsList, List<bool> isInsideList, bool clear = true)
        {
            if (clear)
            {
                elementsList.Clear();
                isInsideList.Clear();
            }
            this.OverlapAllFrustum<T>(ref frustum, delegate (T x, bool y) {
                elementsList.Add(x);
                isInsideList.Add(y);
            });
        }

        public void OverlapAllFrustum<T, TU>(ref BoundingFrustumD frustum, TU results, float projectionFactor, float ignoreThr) where T: TreeUserAction<TU>
        {
            if (this.m_root != -1)
            {
                using (this.m_rwLock.AcquireSharedUsing())
                {
                    Stack<int> stack = this.GetStack();
                    stack.Push(this.m_root);
                    float num = projectionFactor * projectionFactor;
                    float num2 = ignoreThr * ignoreThr;
                    while (stack.Count > 0)
                    {
                        int index = stack.Pop();
                        if (index != -1)
                        {
                            ContainmentType type;
                            DynamicTreeNode node = this.m_nodes[index];
                            frustum.Contains(ref node.Aabb, out type);
                            switch (type)
                            {
                                case ContainmentType.Contains:
                                {
                                    int count = stack.Count;
                                    stack.Push(index);
                                    while (stack.Count > count)
                                    {
                                        int num5 = stack.Pop();
                                        DynamicTreeNode node2 = this.m_nodes[num5];
                                        if (node2.IsLeaf())
                                        {
                                            if ((node2.Aabb.Size.LengthSquared() * num) > num2)
                                            {
                                                this.GetUserData<T>(num5).Add(results, true);
                                            }
                                        }
                                        else
                                        {
                                            if (node2.Child1 != -1)
                                            {
                                                stack.Push(node2.Child1);
                                            }
                                            if (node2.Child2 != -1)
                                            {
                                                stack.Push(node2.Child2);
                                            }
                                        }
                                    }
                                    continue;
                                }
                                case ContainmentType.Intersects:
                                    if (node.IsLeaf())
                                    {
                                        if ((node.Aabb.Size.LengthSquared() * num) > num2)
                                        {
                                            this.GetUserData<T>(index).Add(results, false);
                                        }
                                        continue;
                                    }
                                    stack.Push(node.Child1);
                                    stack.Push(node.Child2);
                                    break;
                            }
                        }
                    }
                    this.PushStack(stack);
                }
            }
        }

        public void OverlapAllFrustum<T>(ref BoundingFrustumD frustum, List<T> elementsList, uint requiredFlags, bool clear = true)
        {
            if (clear)
            {
                elementsList.Clear();
            }
            if (this.m_root != -1)
            {
                using (this.m_rwLock.AcquireSharedUsing())
                {
                    Stack<int> stack = this.GetStack();
                    stack.Push(this.m_root);
                    while (stack.Count > 0)
                    {
                        int index = stack.Pop();
                        if (index != -1)
                        {
                            ContainmentType type;
                            DynamicTreeNode node = this.m_nodes[index];
                            frustum.Contains(ref node.Aabb, out type);
                            switch (type)
                            {
                                case ContainmentType.Contains:
                                {
                                    int count = stack.Count;
                                    stack.Push(index);
                                    while (stack.Count > count)
                                    {
                                        int num3 = stack.Pop();
                                        DynamicTreeNode node2 = this.m_nodes[num3];
                                        if (node2.IsLeaf())
                                        {
                                            if ((this.GetUserFlag(num3) & requiredFlags) == requiredFlags)
                                            {
                                                elementsList.Add(this.GetUserData<T>(num3));
                                            }
                                        }
                                        else
                                        {
                                            if (node2.Child1 != -1)
                                            {
                                                stack.Push(node2.Child1);
                                            }
                                            if (node2.Child2 != -1)
                                            {
                                                stack.Push(node2.Child2);
                                            }
                                        }
                                    }
                                    continue;
                                }
                                case ContainmentType.Intersects:
                                    if (node.IsLeaf())
                                    {
                                        if ((this.GetUserFlag(index) & requiredFlags) == requiredFlags)
                                        {
                                            elementsList.Add(this.GetUserData<T>(index));
                                        }
                                        continue;
                                    }
                                    stack.Push(node.Child1);
                                    stack.Push(node.Child2);
                                    break;
                            }
                        }
                    }
                    this.PushStack(stack);
                }
            }
        }

        public void OverlapAllFrustum<T>(ref BoundingFrustumD frustum, List<T> elementsList, List<bool> isInsideList, float projectionFactor, float ignoreThr, bool clear = true)
        {
            if (clear)
            {
                elementsList.Clear();
                isInsideList.Clear();
            }
            this.OverlapAllFrustum<T>(ref frustum, delegate (T x, bool y) {
                elementsList.Add(x);
                isInsideList.Add(y);
            }, projectionFactor, ignoreThr);
        }

        public void OverlapAllFrustumAny<T>(ref BoundingFrustumD frustum, List<T> elementsList, bool clear = true)
        {
            if (clear)
            {
                elementsList.Clear();
            }
            if (this.m_root != -1)
            {
                using (this.m_rwLock.AcquireSharedUsing())
                {
                    Stack<int> stack = this.GetStack();
                    stack.Push(this.m_root);
                    while (stack.Count > 0)
                    {
                        int index = stack.Pop();
                        if (index != -1)
                        {
                            ContainmentType type;
                            DynamicTreeNode node = this.m_nodes[index];
                            frustum.Contains(ref node.Aabb, out type);
                            switch (type)
                            {
                                case ContainmentType.Contains:
                                {
                                    int count = stack.Count;
                                    stack.Push(index);
                                    while (stack.Count > count)
                                    {
                                        int num3 = stack.Pop();
                                        DynamicTreeNode node2 = this.m_nodes[num3];
                                        if (node2.IsLeaf())
                                        {
                                            T userData = this.GetUserData<T>(num3);
                                            elementsList.Add(userData);
                                        }
                                        else
                                        {
                                            if (node2.Child1 != -1)
                                            {
                                                stack.Push(node2.Child1);
                                            }
                                            if (node2.Child2 != -1)
                                            {
                                                stack.Push(node2.Child2);
                                            }
                                        }
                                    }
                                    continue;
                                }
                                case ContainmentType.Intersects:
                                    if (node.IsLeaf())
                                    {
                                        T item = this.GetUserData<T>(index);
                                        elementsList.Add(item);
                                        continue;
                                    }
                                    stack.Push(node.Child1);
                                    stack.Push(node.Child2);
                                    break;
                            }
                        }
                    }
                    this.PushStack(stack);
                }
            }
        }

        public void OverlapAllLineSegment<T>(ref LineD line, List<MyLineSegmentOverlapResult<T>> elementsList, bool clear = true)
        {
            this.OverlapAllLineSegment<T>(ref line, elementsList, 0, clear);
        }

        public void OverlapAllLineSegment<T>(ref LineD line, List<MyLineSegmentOverlapResult<T>> elementsList, uint requiredFlags, bool clear = true)
        {
            if (clear)
            {
                elementsList.Clear();
            }
            if (this.m_root != -1)
            {
                using (this.m_rwLock.AcquireSharedUsing())
                {
                    Stack<int> stack = this.GetStack();
                    stack.Push(this.m_root);
                    BoundingBoxD box = BoundingBoxD.CreateInvalid();
                    box.Include(ref line);
                    RayD ray = new RayD(line.From, line.Direction);
                    while (stack.Count > 0)
                    {
                        int index = stack.Pop();
                        if (index != -1)
                        {
                            DynamicTreeNode node = this.m_nodes[index];
                            if (node.Aabb.Intersects(box))
                            {
                                double? nullable = node.Aabb.Intersects(ray);
                                if ((nullable.HasValue && (nullable.Value <= line.Length)) && (nullable.Value >= 0.0))
                                {
                                    if (node.IsLeaf())
                                    {
                                        if ((this.GetUserFlag(index) & requiredFlags) == requiredFlags)
                                        {
                                            MyLineSegmentOverlapResult<T> item = new MyLineSegmentOverlapResult<T> {
                                                Element = this.GetUserData<T>(index),
                                                Distance = nullable.Value
                                            };
                                            elementsList.Add(item);
                                        }
                                    }
                                    else
                                    {
                                        stack.Push(node.Child1);
                                        stack.Push(node.Child2);
                                    }
                                }
                            }
                        }
                    }
                    this.PushStack(stack);
                }
            }
        }

        public bool OverlapsAnyLeafBoundingBox(ref BoundingBoxD bbox)
        {
            if (this.m_root != -1)
            {
                using (this.m_rwLock.AcquireSharedUsing())
                {
                    Stack<int> stack = this.GetStack();
                    stack.Push(this.m_root);
                    while (stack.Count > 0)
                    {
                        int index = stack.Pop();
                        if (index != -1)
                        {
                            DynamicTreeNode node = this.m_nodes[index];
                            if (node.Aabb.Intersects((BoundingBoxD) bbox))
                            {
                                if (node.IsLeaf())
                                {
                                    return true;
                                }
                                stack.Push(node.Child1);
                                stack.Push(node.Child2);
                            }
                        }
                    }
                    this.PushStack(stack);
                }
            }
            return false;
        }

        private void PushStack(Stack<int> stack)
        {
        }

        public void Query(Func<int, bool> callback, ref BoundingBoxD aabb)
        {
            using (this.m_rwLock.AcquireSharedUsing())
            {
                Stack<int> stack = this.GetStack();
                stack.Push(this.m_root);
                while (stack.Count > 0)
                {
                    int index = stack.Pop();
                    if (index != -1)
                    {
                        DynamicTreeNode node = this.m_nodes[index];
                        if (node.Aabb.Intersects((BoundingBoxD) aabb))
                        {
                            if (node.IsLeaf())
                            {
                                if (callback(index))
                                {
                                    continue;
                                }
                                return;
                            }
                            stack.Push(node.Child1);
                            stack.Push(node.Child2);
                        }
                    }
                }
            }
        }

        private void RemoveLeaf(int leaf)
        {
            if (this.m_root != -1)
            {
                if (leaf == this.m_root)
                {
                    this.m_root = -1;
                }
                else
                {
                    int num3;
                    int parentOrNext = this.m_nodes[leaf].ParentOrNext;
                    int index = this.m_nodes[parentOrNext].ParentOrNext;
                    if (this.m_nodes[parentOrNext].Child1 == leaf)
                    {
                        num3 = this.m_nodes[parentOrNext].Child2;
                    }
                    else
                    {
                        num3 = this.m_nodes[parentOrNext].Child1;
                    }
                    if (index != -1)
                    {
                        if (this.m_nodes[index].Child1 == parentOrNext)
                        {
                            this.m_nodes[index].Child1 = num3;
                        }
                        else
                        {
                            this.m_nodes[index].Child2 = num3;
                        }
                        this.m_nodes[num3].ParentOrNext = index;
                        this.FreeNode(parentOrNext);
                        for (int i = index; i != -1; i = this.m_nodes[i].ParentOrNext)
                        {
                            i = this.Balance(i);
                            int num5 = this.m_nodes[i].Child1;
                            int num6 = this.m_nodes[i].Child2;
                            this.m_nodes[i].Aabb = BoundingBoxD.CreateMerged(this.m_nodes[num5].Aabb, this.m_nodes[num6].Aabb);
                            this.m_nodes[i].Height = 1 + Math.Max(this.m_nodes[num5].Height, this.m_nodes[num6].Height);
                        }
                    }
                    else
                    {
                        this.m_root = num3;
                        this.m_nodes[num3].ParentOrNext = -1;
                        this.FreeNode(parentOrNext);
                    }
                }
            }
        }

        public void RemoveProxy(int proxyId)
        {
            using (this.m_rwLock.AcquireExclusiveUsing())
            {
                this.m_leafElementCache.Remove(proxyId);
                this.RemoveLeaf(proxyId);
                this.FreeNode(proxyId);
            }
        }

        private void ResetNodes()
        {
            this.m_leafElementCache.Clear();
            this.m_root = -1;
            this.m_nodeCount = 0;
            for (int i = 0; i < (this.m_nodeCapacity - 1); i++)
            {
                this.m_nodes[i].ParentOrNext = i + 1;
                this.m_nodes[i].Height = 1;
                this.m_nodes[i].UserData = null;
            }
            this.m_nodes[this.m_nodeCapacity - 1].ParentOrNext = -1;
            this.m_nodes[this.m_nodeCapacity - 1].Height = 1;
            this.m_freeList = 0;
        }

        private Stack<int> CurrentThreadStack
        {
            get
            {
                if (m_queryStack == null)
                {
                    m_queryStack = new Stack<int>(0x20);
                    lock (m_StackCacheCollection)
                    {
                        m_StackCacheCollection.Add(m_queryStack);
                    }
                }
                return m_queryStack;
            }
        }

        internal class DynamicTreeNode
        {
            internal BoundingBoxD Aabb;
            internal int Child1;
            internal int Child2;
            internal int Height;
            internal int ParentOrNext;
            internal object UserData;
            internal uint UserFlag;

            internal bool IsLeaf() => 
                (this.Child1 == -1);
        }
    }
}

