namespace VRageMath.Spatial
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using VRageMath;

    public class MyVector3Grid<T>
    {
        private Dictionary<Vector3I, int> m_bins;
        private float m_cellSize;
        private int m_count;
        private float m_divisor;
        private IEqualityComparer<T> m_equalityComparer;
        private int m_nextFreeEntry;
        private List<Entry<T>> m_storage;

        public MyVector3Grid(float cellSize) : this(cellSize, EqualityComparer<T>.Default)
        {
        }

        public MyVector3Grid(float cellSize, IEqualityComparer<T> comparer)
        {
            this.m_cellSize = cellSize;
            this.m_divisor = 1f / this.m_cellSize;
            this.m_storage = new List<Entry<T>>();
            this.m_bins = new Dictionary<Vector3I, int>();
            this.m_equalityComparer = comparer;
            this.Clear();
        }

        private int AddNewEntry(ref Vector3 point, T data)
        {
            this.m_count++;
            if (this.m_nextFreeEntry == this.m_storage.Count)
            {
                Entry<T> item = new Entry<T> {
                    Point = point,
                    Data = data,
                    NextEntry = this.InvalidIndex
                };
                this.m_storage.Add(item);
                return this.m_nextFreeEntry++;
            }
            if (((ulong) this.m_nextFreeEntry) > this.m_storage.Count)
            {
                return -1;
            }
            int nextFreeEntry = this.m_nextFreeEntry;
            this.m_nextFreeEntry = this.m_storage[this.m_nextFreeEntry].NextEntry;
            Entry<T> entry2 = new Entry<T> {
                Point = point,
                Data = data,
                NextEntry = this.InvalidIndex
            };
            this.m_storage[nextFreeEntry] = entry2;
            return nextFreeEntry;
        }

        public void AddPoint(ref Vector3 point, T data)
        {
            int num;
            Vector3I binIndex = this.GetBinIndex(ref point);
            if (!this.m_bins.TryGetValue(binIndex, out num))
            {
                int num2 = this.AddNewEntry(ref point, data);
                this.m_bins.Add(binIndex, num2);
            }
            else
            {
                Entry<T> entry = this.m_storage[num];
                for (int i = entry.NextEntry; i != this.InvalidIndex; i = entry.NextEntry)
                {
                    num = i;
                    entry = this.m_storage[num];
                }
                int num4 = this.AddNewEntry(ref point, data);
                entry.NextEntry = num4;
                this.m_storage[num] = entry;
            }
        }

        [Conditional("DEBUG")]
        private void CheckIndexIsValid(int index)
        {
            for (int i = this.m_nextFreeEntry; (i != this.InvalidIndex) && (i != this.m_storage.Count); i = this.m_storage[i].NextEntry)
            {
            }
        }

        public void Clear()
        {
            this.m_nextFreeEntry = 0;
            this.m_count = 0;
            this.m_storage.Clear();
            this.m_bins.Clear();
        }

        public void ClearFast()
        {
            this.m_nextFreeEntry = 0;
            this.m_count = 0;
            this.m_storage.SetSize<Entry<T>>(0);
            this.m_bins.Clear();
        }

        public void CollectEntireStorage(List<T> output)
        {
            output.Clear();
            foreach (KeyValuePair<Vector3I, int> pair in this.m_bins)
            {
                int nextEntry = pair.Value;
                do
                {
                    Entry<T> entry = this.m_storage[nextEntry];
                    output.Add(entry.Data);
                    nextEntry = entry.NextEntry;
                }
                while (nextEntry != this.InvalidIndex);
            }
        }

        public void CollectStorage(int startingIndex, ref List<T> output)
        {
            output.Clear();
            Entry<T> entry = this.m_storage[startingIndex];
            output.Add(entry.Data);
            while (entry.NextEntry != this.InvalidIndex)
            {
                entry = this.m_storage[entry.NextEntry];
                output.Add(entry.Data);
            }
        }

        public Dictionary<Vector3I, int>.Enumerator EnumerateBins() => 
            this.m_bins.GetEnumerator();

        public int FindPointIndex(ref Vector3 point, T data)
        {
            Vector3I binIndex = this.GetBinIndex(ref point);
            int invalidIndex = this.InvalidIndex;
            this.m_bins.TryGetValue(binIndex, out invalidIndex);
            while (invalidIndex != this.InvalidIndex)
            {
                Entry<T> entry = this.m_storage[invalidIndex];
                if ((entry.Point == point) && this.m_equalityComparer.Equals(entry.Data, data))
                {
                    return invalidIndex;
                }
                invalidIndex = entry.NextEntry;
            }
            return invalidIndex;
        }

        private Vector3I GetBinIndex(ref Vector3 point) => 
            Vector3I.Floor((Vector3) (point * this.m_divisor));

        private Vector3I GetBinIndex(Vector3 point) => 
            this.GetBinIndex(ref point);

        public T GetData(int index) => 
            this.m_storage[index].Data;

        public void GetLocalBinBB(ref Vector3I binPosition, out BoundingBoxD output)
        {
            output.Min = (Vector3D) (binPosition * this.m_cellSize);
            output.Max = output.Min + new Vector3(this.m_cellSize);
        }

        public int GetNextBinIndex(int currentIndex)
        {
            if (currentIndex == this.InvalidIndex)
            {
                return this.InvalidIndex;
            }
            return this.m_storage[currentIndex].NextEntry;
        }

        public Vector3 GetPoint(int index) => 
            this.m_storage[index].Point;

        public void MovePoint(int index, ref Vector3 newPosition)
        {
            Entry<T> entry = this.m_storage[index];
            Vector3I binIndex = this.GetBinIndex(this.m_storage[index].Point);
            Vector3I vectori2 = this.GetBinIndex(ref newPosition);
            if (binIndex == vectori2)
            {
                entry.Point = newPosition;
                this.m_storage[index] = entry;
            }
            else
            {
                int num = this.m_bins[binIndex];
                if (index == num)
                {
                    int num2 = this.RemoveEntry(index);
                    if (num2 == this.InvalidIndex)
                    {
                        this.m_bins.Remove(binIndex);
                    }
                    else
                    {
                        this.m_bins[binIndex] = num2;
                    }
                }
                else
                {
                    int nextEntry;
                    for (int i = num; i != this.InvalidIndex; i = nextEntry)
                    {
                        Entry<T> entry2 = this.m_storage[i];
                        nextEntry = entry2.NextEntry;
                        if (nextEntry == index)
                        {
                            entry2.NextEntry = this.RemoveEntry(index);
                            this.m_storage[i] = entry2;
                            break;
                        }
                    }
                }
                this.AddPoint(ref newPosition, entry.Data);
            }
        }

        public SphereQuery<T> QueryPointsSphere(ref Vector3 point, float dist) => 
            new SphereQuery<T>((MyVector3Grid<T>) this, ref point, dist);

        private int RemoveEntry(int toRemove)
        {
            this.m_count--;
            Entry<T> entry = this.m_storage[toRemove];
            int nextEntry = entry.NextEntry;
            entry.NextEntry = this.m_nextFreeEntry;
            entry.Data = default(T);
            this.m_nextFreeEntry = toRemove;
            this.m_storage[toRemove] = entry;
            return nextEntry;
        }

        public void RemovePoint(ref Vector3 point)
        {
            int nextEntry;
            Vector3I binIndex = this.GetBinIndex(ref point);
            if (this.m_bins.TryGetValue(binIndex, out nextEntry))
            {
                int invalidIndex = this.InvalidIndex;
                int num3 = nextEntry;
                Entry<T> entry = new Entry<T>();
                while (nextEntry != this.InvalidIndex)
                {
                    Entry<T> entry2 = this.m_storage[nextEntry];
                    if (entry2.Point == point)
                    {
                        int num4 = this.RemoveEntry(nextEntry);
                        if (num3 == nextEntry)
                        {
                            num3 = num4;
                        }
                        else
                        {
                            entry.NextEntry = num4;
                            this.m_storage[invalidIndex] = entry;
                        }
                        nextEntry = num4;
                    }
                    else
                    {
                        invalidIndex = nextEntry;
                        entry = entry2;
                        nextEntry = entry2.NextEntry;
                    }
                }
                if (num3 == this.InvalidIndex)
                {
                    this.m_bins.Remove(binIndex);
                }
                else
                {
                    this.m_bins[binIndex] = num3;
                }
            }
        }

        public void RemoveTwo(ref SphereQuery<T> en0, ref SphereQuery<T> en1)
        {
            if (en0.CurrentBin == en1.CurrentBin)
            {
                if (en0.StorageIndex == en1.PreviousIndex)
                {
                    en1.RemoveCurrent();
                    en0.RemoveCurrent();
                    en1 = en0;
                }
                else if (en1.StorageIndex == en0.PreviousIndex)
                {
                    en0.RemoveCurrent();
                    en1.RemoveCurrent();
                    en0 = en1;
                }
                else if (en0.StorageIndex == en1.StorageIndex)
                {
                    en0.RemoveCurrent();
                    en1 = en0;
                }
                else
                {
                    en0.RemoveCurrent();
                    en1.RemoveCurrent();
                }
            }
            else
            {
                en0.RemoveCurrent();
                en1.RemoveCurrent();
            }
        }

        public int Count =>
            this.m_count;

        public int InvalidIndex =>
            -1;

        [StructLayout(LayoutKind.Sequential)]
        private struct Entry
        {
            public Vector3 Point;
            public T Data;
            public int NextEntry;
            public override string ToString() => 
                (this.Point.ToString() + ", -> " + this.NextEntry.ToString() + ", Data: " + this.Data.ToString());
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SphereQuery
        {
            private MyVector3Grid<T> m_parent;
            private Vector3 m_point;
            private float m_distSq;
            private int m_previousIndex;
            private int m_storageIndex;
            private Vector3I_RangeIterator m_rangeIterator;
            public SphereQuery(MyVector3Grid<T> parent, ref Vector3 point, float dist)
            {
                this.m_parent = parent;
                this.m_point = point;
                this.m_distSq = dist * dist;
                Vector3 vector = new Vector3(dist);
                Vector3I binIndex = this.m_parent.GetBinIndex(((Vector3) point) - vector);
                Vector3I end = this.m_parent.GetBinIndex(((Vector3) point) + vector);
                this.m_rangeIterator = new Vector3I_RangeIterator(ref binIndex, ref end);
                this.m_previousIndex = -1;
                this.m_storageIndex = -1;
            }

            public T Current =>
                this.m_parent.m_storage[this.m_storageIndex].Data;
            public Vector3I CurrentBin =>
                this.m_rangeIterator.Current;
            public int PreviousIndex =>
                this.m_previousIndex;
            public int StorageIndex =>
                this.m_storageIndex;
            public bool RemoveCurrent()
            {
                this.m_storageIndex = this.m_parent.RemoveEntry(this.m_storageIndex);
                if (this.m_previousIndex == -1)
                {
                    if (this.m_storageIndex == -1)
                    {
                        this.m_parent.m_bins.Remove(this.m_rangeIterator.Current);
                    }
                    else
                    {
                        this.m_parent.m_bins[this.m_rangeIterator.Current] = this.m_storageIndex;
                    }
                }
                else
                {
                    MyVector3Grid<T>.Entry entry = this.m_parent.m_storage[this.m_previousIndex];
                    entry.NextEntry = this.m_storageIndex;
                    this.m_parent.m_storage[this.m_previousIndex] = entry;
                }
                return this.FindFirstAcceptableEntry();
            }

            public bool MoveNext()
            {
                if (this.m_storageIndex == -1)
                {
                    if (!this.FindNextNonemptyBin())
                    {
                        return false;
                    }
                }
                else
                {
                    this.m_previousIndex = this.m_storageIndex;
                    this.m_storageIndex = this.m_parent.m_storage[this.m_storageIndex].NextEntry;
                }
                return this.FindFirstAcceptableEntry();
            }

            private bool FindFirstAcceptableEntry()
            {
                do
                {
                    while (this.m_storageIndex != -1)
                    {
                        MyVector3Grid<T>.Entry entry = this.m_parent.m_storage[this.m_storageIndex];
                        Vector3 vector = entry.Point - this.m_point;
                        if (vector.LengthSquared() < this.m_distSq)
                        {
                            return true;
                        }
                        this.m_previousIndex = this.m_storageIndex;
                        this.m_storageIndex = entry.NextEntry;
                    }
                    this.m_rangeIterator.MoveNext();
                }
                while (this.FindNextNonemptyBin());
                return false;
            }

            private bool FindNextNonemptyBin()
            {
                this.m_previousIndex = -1;
                if (!this.m_rangeIterator.IsValid())
                {
                    return false;
                }
                Vector3I current = this.m_rangeIterator.Current;
                while (!this.m_parent.m_bins.TryGetValue(current, out this.m_storageIndex))
                {
                    this.m_rangeIterator.GetNext(out current);
                    if (!this.m_rangeIterator.IsValid())
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}

