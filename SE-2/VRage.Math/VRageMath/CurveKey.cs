namespace VRageMath
{
    using System;
    using System.ComponentModel;

    [Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
    public class CurveKey : IEquatable<CurveKey>, IComparable<CurveKey>
    {
        internal CurveContinuity continuity;
        internal float internalValue;
        internal float position;
        internal float tangentIn;
        internal float tangentOut;

        public CurveKey()
        {
        }

        public CurveKey(float position, float value)
        {
            this.position = position;
            this.internalValue = value;
        }

        public CurveKey(float position, float value, float tangentIn, float tangentOut)
        {
            this.position = position;
            this.internalValue = value;
            this.tangentIn = tangentIn;
            this.tangentOut = tangentOut;
        }

        public CurveKey(float position, float value, float tangentIn, float tangentOut, CurveContinuity continuity)
        {
            this.position = position;
            this.internalValue = value;
            this.tangentIn = tangentIn;
            this.tangentOut = tangentOut;
            this.continuity = continuity;
        }

        public CurveKey Clone() => 
            new CurveKey(this.position, this.internalValue, this.tangentIn, this.tangentOut, this.continuity);

        public int CompareTo(CurveKey other)
        {
            if (this.position == other.position)
            {
                return 0;
            }
            if (this.position < other.position)
            {
                return -1;
            }
            return 1;
        }

        public override bool Equals(object obj) => 
            this.Equals(obj as CurveKey);

        public bool Equals(CurveKey other) => 
            (((((other != null) && (other.position == this.position)) && ((other.internalValue == this.internalValue) && (other.tangentIn == this.tangentIn))) && (other.tangentOut == this.tangentOut)) && (other.continuity == this.continuity));

        public override int GetHashCode() => 
            ((((this.position.GetHashCode() + this.internalValue.GetHashCode()) + this.tangentIn.GetHashCode()) + this.tangentOut.GetHashCode()) + this.continuity.GetHashCode());

        public static bool operator ==(CurveKey a, CurveKey b)
        {
            bool flag = null == a;
            bool flag2 = null == b;
            if (!flag && !flag2)
            {
                return a.Equals(b);
            }
            return (flag == flag2);
        }

        public static bool operator !=(CurveKey a, CurveKey b)
        {
            bool flag = a == null;
            bool flag2 = b == null;
            if (flag || flag2)
            {
                return (flag != flag2);
            }
            if (((a.position == b.position) && (a.internalValue == b.internalValue)) && ((a.tangentIn == b.tangentIn) && (a.tangentOut == b.tangentOut)))
            {
                return (a.continuity != b.continuity);
            }
            return true;
        }

        public CurveContinuity Continuity
        {
            get => 
                this.continuity;
            set
            {
                this.continuity = value;
            }
        }

        public float Position =>
            this.position;

        public float TangentIn
        {
            get => 
                this.tangentIn;
            set
            {
                this.tangentIn = value;
            }
        }

        public float TangentOut
        {
            get => 
                this.tangentOut;
            set
            {
                this.tangentOut = value;
            }
        }

        public float Value
        {
            get => 
                this.internalValue;
            set
            {
                this.internalValue = value;
            }
        }
    }
}

