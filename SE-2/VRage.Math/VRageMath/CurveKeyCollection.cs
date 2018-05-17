namespace VRageMath
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    [Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
    public class CurveKeyCollection : ICollection<CurveKey>, IEnumerable<CurveKey>, IEnumerable
    {
        internal float InvTimeRange;
        internal bool IsCacheAvailable = true;
        private List<CurveKey> Keys = new List<CurveKey>();
        internal float TimeRange;

        public void Add(object tmp)
        {
        }

        public void Add(CurveKey item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            int index = this.Keys.BinarySearch(item);
            if (index >= 0)
            {
                while ((index < this.Keys.Count) && (item.Position == this.Keys[index].Position))
                {
                    index++;
                }
            }
            else
            {
                index = ~index;
            }
            this.Keys.Insert(index, item);
            this.IsCacheAvailable = false;
        }

        public void Clear()
        {
            this.Keys.Clear();
            this.TimeRange = this.InvTimeRange = 0f;
            this.IsCacheAvailable = false;
        }

        public CurveKeyCollection Clone() => 
            new CurveKeyCollection { 
                Keys = new List<CurveKey>(this.Keys),
                InvTimeRange = this.InvTimeRange,
                TimeRange = this.TimeRange,
                IsCacheAvailable = true
            };

        internal void ComputeCacheValues()
        {
            this.TimeRange = this.InvTimeRange = 0f;
            if (this.Keys.Count > 1)
            {
                this.TimeRange = this.Keys[this.Keys.Count - 1].Position - this.Keys[0].Position;
                if (this.TimeRange > 1.40129846432482E-45)
                {
                    this.InvTimeRange = 1f / this.TimeRange;
                }
            }
            this.IsCacheAvailable = true;
        }

        public bool Contains(CurveKey item) => 
            this.Keys.Contains(item);

        public void CopyTo(CurveKey[] array, int arrayIndex)
        {
            this.Keys.CopyTo(array, arrayIndex);
            this.IsCacheAvailable = false;
        }

        public IEnumerator<CurveKey> GetEnumerator() => 
            this.Keys.GetEnumerator();

        public int IndexOf(CurveKey item) => 
            this.Keys.IndexOf(item);

        public bool Remove(CurveKey item)
        {
            this.IsCacheAvailable = false;
            return this.Keys.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.Keys.RemoveAt(index);
            this.IsCacheAvailable = false;
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.Keys.GetEnumerator();

        public int Count =>
            this.Keys.Count;

        public bool IsReadOnly =>
            false;

        public CurveKey this[int index]
        {
            get => 
                this.Keys[index];
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                if (this.Keys[index].Position == value.Position)
                {
                    this.Keys[index] = value;
                }
                else
                {
                    this.Keys.RemoveAt(index);
                    this.Add(value);
                }
            }
        }
    }
}

