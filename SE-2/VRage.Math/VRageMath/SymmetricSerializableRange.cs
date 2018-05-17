namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;

    [StructLayout(LayoutKind.Sequential)]
    public struct SymmetricSerializableRange
    {
        [XmlAttribute(AttributeName="Min")]
        public float Min;
        [XmlAttribute(AttributeName="Max")]
        public float Max;
        private bool m_notMirror;
        [XmlAttribute(AttributeName="Mirror")]
        public bool Mirror
        {
            get => 
                !this.m_notMirror;
            set
            {
                this.m_notMirror = !value;
            }
        }
        public SymmetricSerializableRange(float min, float max, bool mirror = true)
        {
            this.Max = max;
            this.Min = min;
            this.m_notMirror = !mirror;
        }

        public bool ValueBetween(float value)
        {
            if (!this.m_notMirror)
            {
                value = Math.Abs(value);
            }
            return ((value >= this.Min) && (value <= this.Max));
        }

        public override string ToString() => 
            $"{(this.Mirror ? "MirroredRange" : "Range")}[{this.Min}, {this.Max}]";

        public SymmetricSerializableRange ConvertToCosine()
        {
            float max = this.Max;
            this.Max = (float) Math.Cos((this.Min * 3.1415926535897931) / 180.0);
            this.Min = (float) Math.Cos((max * 3.1415926535897931) / 180.0);
            return this;
        }

        public SymmetricSerializableRange ConvertToSine()
        {
            this.Max = (float) Math.Sin((this.Max * 3.1415926535897931) / 180.0);
            this.Min = (float) Math.Sin((this.Min * 3.1415926535897931) / 180.0);
            return this;
        }

        public SymmetricSerializableRange ConvertToCosineLongitude()
        {
            this.Max = CosineLongitude(this.Max);
            this.Min = CosineLongitude(this.Min);
            return this;
        }

        private static float CosineLongitude(float angle)
        {
            if (angle > 0f)
            {
                return (2f - ((float) Math.Cos((angle * 3.1415926535897931) / 180.0)));
            }
            return (float) Math.Cos((angle * 3.1415926535897931) / 180.0);
        }

        public string ToStringAsin() => 
            $"Range[{MathHelper.ToDegrees(Math.Asin((double) this.Min))}, {MathHelper.ToDegrees(Math.Asin((double) this.Max))}]";

        public string ToStringAcos() => 
            $"Range[{MathHelper.ToDegrees(Math.Acos((double) this.Min))}, {MathHelper.ToDegrees(Math.Acos((double) this.Max))}]";
    }
}

