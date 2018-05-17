namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3I_RangeIterator
    {
        private Vector3I m_start;
        private Vector3I m_end;
        public Vector3I Current;
        public Vector3I_RangeIterator(ref Vector3I start, ref Vector3I end)
        {
            this.m_start = start;
            this.m_end = end;
            this.Current = this.m_start;
        }

        public bool IsValid() => 
            (((((this.Current.X >= this.m_start.X) && (this.Current.Y >= this.m_start.Y)) && ((this.Current.Z >= this.m_start.Z) && (this.Current.X <= this.m_end.X))) && (this.Current.Y <= this.m_end.Y)) && (this.Current.Z <= this.m_end.Z));

        public void GetNext(out Vector3I next)
        {
            this.MoveNext();
            next = this.Current;
        }

        public void MoveNext()
        {
            this.Current.X++;
            if (this.Current.X > this.m_end.X)
            {
                this.Current.X = this.m_start.X;
                this.Current.Y++;
                if (this.Current.Y > this.m_end.Y)
                {
                    this.Current.Y = this.m_start.Y;
                    this.Current.Z++;
                }
            }
        }
    }
}

