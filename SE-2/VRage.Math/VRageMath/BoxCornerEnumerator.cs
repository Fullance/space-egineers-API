namespace VRageMath
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct BoxCornerEnumerator : IEnumerator<Vector3>, IDisposable, IEnumerator, IEnumerable<Vector3>, IEnumerable
    {
        private unsafe static Vector3B* m_indices;
        private TwoVectors m_minMax;
        private int m_index;
        static unsafe BoxCornerEnumerator()
        {
            m_indices = (Vector3B*) Marshal.AllocHGlobal(0x18);
            m_indices[0] = new Vector3B(0, 4, 5);
            m_indices[1] = new Vector3B(3, 4, 5);
            m_indices[2] = new Vector3B(3, 1, 5);
            m_indices[3] = new Vector3B(0, 1, 5);
            m_indices[4] = new Vector3B(0, 4, 2);
            m_indices[5] = new Vector3B(3, 4, 2);
            m_indices[6] = new Vector3B(3, 1, 2);
            m_indices[7] = new Vector3B(0, 1, 2);
        }

        public BoxCornerEnumerator(Vector3 min, Vector3 max)
        {
            this.m_minMax.Min = min;
            this.m_minMax.Max = max;
            this.m_index = -1;
        }

        public void Add(object tmp)
        {
        }

        public Vector3 Current
        {
            get
            {
                float* numPtr = (float*) &this.m_minMax;
                Vector3B vectorb = m_indices[this.m_index];
                return new Vector3(numPtr[vectorb.X * 4], numPtr[vectorb.Y * 4], numPtr[vectorb.Z * 4]);
            }
        }
        public bool MoveNext() => 
            (++this.m_index < 8);

        void IDisposable.Dispose()
        {
        }

        object IEnumerator.Current =>
            this.Current;
        void IEnumerator.Reset()
        {
            this.m_index = -1;
        }

        public BoxCornerEnumerator GetEnumerator() => 
            this;

        IEnumerator<Vector3> IEnumerable<Vector3>.GetEnumerator() => 
            this;

        IEnumerator IEnumerable.GetEnumerator() => 
            this;
        [StructLayout(LayoutKind.Sequential)]
        private struct TwoVectors
        {
            public Vector3 Min;
            public Vector3 Max;
        }
    }
}

