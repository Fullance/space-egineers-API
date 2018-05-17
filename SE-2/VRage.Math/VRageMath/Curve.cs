namespace VRageMath
{
    using System;

    [Serializable]
    public class Curve
    {
        private CurveKeyCollection keys = new CurveKeyCollection();
        private CurveLoopType postLoop;
        private CurveLoopType preLoop;

        private float CalcCycle(float t)
        {
            float num = (t - this.keys[0].position) * this.keys.InvTimeRange;
            if (num < 0.0)
            {
                num--;
            }
            return (float) ((int) num);
        }

        public Curve Clone() => 
            new Curve { 
                preLoop = this.preLoop,
                postLoop = this.postLoop,
                keys = this.keys.Clone()
            };

        public void ComputeTangent(int keyIndex, CurveTangent tangentType)
        {
            this.ComputeTangent(keyIndex, tangentType, tangentType);
        }

        public void ComputeTangent(int keyIndex, CurveTangent tangentInType, CurveTangent tangentOutType)
        {
            double num;
            double num5;
            if ((this.keys.Count <= keyIndex) || (keyIndex < 0))
            {
                throw new ArgumentOutOfRangeException("keyIndex");
            }
            CurveKey key = this.Keys[keyIndex];
            float num2 = num = key.Position;
            float num3 = (float) num;
            float position = (float) num;
            float num6 = num5 = key.Value;
            float num7 = (float) num5;
            float num8 = (float) num5;
            if (keyIndex > 0)
            {
                position = this.Keys[keyIndex - 1].Position;
                num8 = this.Keys[keyIndex - 1].Value;
            }
            if ((keyIndex + 1) < this.keys.Count)
            {
                num2 = this.Keys[keyIndex + 1].Position;
                num6 = this.Keys[keyIndex + 1].Value;
            }
            if (tangentInType == CurveTangent.Smooth)
            {
                float num9 = num2 - position;
                float num10 = num6 - num8;
                key.TangentIn = (Math.Abs(num10) >= 1.19209289550781E-07) ? ((num10 * Math.Abs((float) (position - num3))) / num9) : 0f;
            }
            else
            {
                key.TangentIn = (tangentInType != CurveTangent.Linear) ? 0f : (num7 - num8);
            }
            if (tangentOutType == CurveTangent.Smooth)
            {
                float num11 = num2 - position;
                float num12 = num6 - num8;
                if (Math.Abs(num12) < 1.19209289550781E-07)
                {
                    key.TangentOut = 0f;
                }
                else
                {
                    key.TangentOut = (num12 * Math.Abs((float) (num2 - num3))) / num11;
                }
            }
            else if (tangentOutType == CurveTangent.Linear)
            {
                key.TangentOut = num6 - num7;
            }
            else
            {
                key.TangentOut = 0f;
            }
        }

        public void ComputeTangents(CurveTangent tangentType)
        {
            this.ComputeTangents(tangentType, tangentType);
        }

        public void ComputeTangents(CurveTangent tangentInType, CurveTangent tangentOutType)
        {
            for (int i = 0; i < this.Keys.Count; i++)
            {
                this.ComputeTangent(i, tangentInType, tangentOutType);
            }
        }

        public float Evaluate(float position)
        {
            if (this.keys.Count == 0)
            {
                return 0f;
            }
            if (this.keys.Count == 1)
            {
                return this.keys[0].internalValue;
            }
            CurveKey key = this.keys[0];
            CurveKey key2 = this.keys[this.keys.Count - 1];
            float t = position;
            float num2 = 0f;
            if (t < key.position)
            {
                if (this.preLoop == CurveLoopType.Constant)
                {
                    return key.internalValue;
                }
                if (this.preLoop == CurveLoopType.Linear)
                {
                    return (key.internalValue - (key.tangentIn * (key.position - t)));
                }
                if (!this.keys.IsCacheAvailable)
                {
                    this.keys.ComputeCacheValues();
                }
                float num3 = this.CalcCycle(t);
                float num4 = t - (key.position + (num3 * this.keys.TimeRange));
                if (this.preLoop == CurveLoopType.Cycle)
                {
                    t = key.position + num4;
                }
                else if (this.preLoop == CurveLoopType.CycleOffset)
                {
                    t = key.position + num4;
                    num2 = (key2.internalValue - key.internalValue) * num3;
                }
                else
                {
                    t = ((((int) num3) & 1) != 0) ? (key2.position - num4) : (key.position + num4);
                }
            }
            else if (key2.position < t)
            {
                if (this.postLoop == CurveLoopType.Constant)
                {
                    return key2.internalValue;
                }
                if (this.postLoop == CurveLoopType.Linear)
                {
                    return (key2.internalValue - (key2.tangentOut * (key2.position - t)));
                }
                if (!this.keys.IsCacheAvailable)
                {
                    this.keys.ComputeCacheValues();
                }
                float num5 = this.CalcCycle(t);
                float num6 = t - (key.position + (num5 * this.keys.TimeRange));
                if (this.postLoop == CurveLoopType.Cycle)
                {
                    t = key.position + num6;
                }
                else if (this.postLoop == CurveLoopType.CycleOffset)
                {
                    t = key.position + num6;
                    num2 = (key2.internalValue - key.internalValue) * num5;
                }
                else
                {
                    t = ((((int) num5) & 1) != 0) ? (key2.position - num6) : (key.position + num6);
                }
            }
            CurveKey key3 = null;
            CurveKey key4 = null;
            float num7 = this.FindSegment(t, ref key3, ref key4);
            return (num2 + Hermite(key3, key4, num7));
        }

        private float FindSegment(float t, ref CurveKey k0, ref CurveKey k1)
        {
            float num = t;
            k0 = this.keys[0];
            for (int i = 1; i < this.keys.Count; i++)
            {
                k1 = this.keys[i];
                if (k1.position >= t)
                {
                    double position = k0.position;
                    double num4 = k1.position;
                    double num5 = t;
                    double num6 = num4 - position;
                    num = 0f;
                    if (num6 > 0.0)
                    {
                        num = (float) ((num5 - position) / num6);
                    }
                    return num;
                }
                k0 = k1;
            }
            return num;
        }

        private static float Hermite(CurveKey k0, CurveKey k1, float t)
        {
            if (k0.Continuity == CurveContinuity.Step)
            {
                if (t >= 1.0)
                {
                    return k1.internalValue;
                }
                return k0.internalValue;
            }
            float num = t * t;
            float num2 = num * t;
            float internalValue = k0.internalValue;
            float num4 = k1.internalValue;
            float tangentOut = k0.tangentOut;
            float tangentIn = k1.tangentIn;
            return (((float) (((internalValue * (((2.0 * num2) - (3.0 * num)) + 1.0)) + (num4 * ((-2.0 * num2) + (3.0 * num)))) + (tangentOut * ((num2 - (2.0 * num)) + t)))) + (tangentIn * (num2 - num)));
        }

        public bool IsConstant =>
            (this.keys.Count <= 1);

        public CurveKeyCollection Keys =>
            this.keys;

        public CurveLoopType PostLoop
        {
            get => 
                this.postLoop;
            set
            {
                this.postLoop = value;
            }
        }

        public CurveLoopType PreLoop
        {
            get => 
                this.preLoop;
            set
            {
                this.preLoop = value;
            }
        }
    }
}

