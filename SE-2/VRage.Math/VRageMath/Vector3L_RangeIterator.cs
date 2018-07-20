namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3L_RangeIterator
    {
        private Vector3L m_start;
        private Vector3L m_end;
        public Vector3L Current;
        public Vector3L_RangeIterator(ref Vector3L start, ref Vector3L end)
        {
            this.m_start = start;
            this.m_end = end;
            this.Current = this.m_start;
        }

        public bool IsValid() => 
            (((((this.Current.X >= this.m_start.X) && (this.Current.Y >= this.m_start.Y)) && ((this.Current.Z >= this.m_start.Z) && (this.Current.X <= this.m_end.X))) && (this.Current.Y <= this.m_end.Y)) && (this.Current.Z <= this.m_end.Z));

        public void GetNext(out Vector3L next)
        {
            this.MoveNext();
            next = this.Current;
        }

        public void MoveNext()
        {
            this.Current.X += 1L;
            if (this.Current.X > this.m_end.X)
            {
                this.Current.X = this.m_start.X;
                this.Current.Y += 1L;
                if (this.Current.Y > this.m_end.Y)
                {
                    this.Current.Y = this.m_start.Y;
                    this.Current.Z += 1L;
                }
            }
        }
    }
}

