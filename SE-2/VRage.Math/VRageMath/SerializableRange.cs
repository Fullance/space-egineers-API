namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct SerializableRange
    {
        [ProtoMember(11), XmlAttribute(AttributeName="Min")]
        public float Min;
        [ProtoMember(14), XmlAttribute(AttributeName="Max")]
        public float Max;
        public SerializableRange(float min, float max)
        {
            this.Max = max;
            this.Min = min;
        }

        public bool ValueBetween(float value) => 
            ((value >= this.Min) && (value <= this.Max));

        public override string ToString() => 
            $"Range[{this.Min}, {this.Max}]";

        public SerializableRange ConvertToCosine()
        {
            float max = this.Max;
            this.Max = (float) Math.Cos((this.Min * 3.1415926535897931) / 180.0);
            this.Min = (float) Math.Cos((max * 3.1415926535897931) / 180.0);
            return this;
        }

        public SerializableRange ConvertToSine()
        {
            this.Max = (float) Math.Sin((this.Max * 3.1415926535897931) / 180.0);
            this.Min = (float) Math.Sin((this.Min * 3.1415926535897931) / 180.0);
            return this;
        }

        public SerializableRange ConvertToCosineLongitude()
        {
            this.Max = MathHelper.MonotonicCosine((float) ((this.Max * 3.1415926535897931) / 180.0));
            this.Min = MathHelper.MonotonicCosine((float) ((this.Min * 3.1415926535897931) / 180.0));
            return this;
        }

        public string ToStringAsin() => 
            $"Range[{MathHelper.ToDegrees(Math.Asin((double) this.Min))}, {MathHelper.ToDegrees(Math.Asin((double) this.Max))}]";

        public string ToStringAcos() => 
            $"Range[{MathHelper.ToDegrees(Math.Acos((double) this.Min))}, {MathHelper.ToDegrees(Math.Acos((double) this.Max))}]";

        public string ToStringLongitude() => 
            $"Range[{MathHelper.ToDegrees(MathHelper.MonotonicAcos(this.Min))}, {MathHelper.ToDegrees(MathHelper.MonotonicAcos(this.Max))}]";
    }
}

