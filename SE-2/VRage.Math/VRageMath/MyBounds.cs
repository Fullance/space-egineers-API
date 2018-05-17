namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyBounds
    {
        public float Min;
        public float Max;
        public float Default;
        public MyBounds(float min, float max, float def)
        {
            this.Min = min;
            this.Max = max;
            this.Default = def;
        }

        public float Normalize(float value) => 
            ((value - this.Min) / (this.Max - this.Min));

        public float Clamp(float value) => 
            MathHelper.Clamp(value, this.Min, this.Max);

        public override string ToString() => 
            $"Min={this.Min}, Max={this.Max}, Default={this.Default}";
    }
}

