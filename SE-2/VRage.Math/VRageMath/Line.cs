namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Line
    {
        public Vector3 From;
        public Vector3 To;
        public Vector3 Direction;
        public float Length;
        public VRageMath.BoundingBox BoundingBox;
        public Line(Vector3 from, Vector3 to, bool calculateBoundingBox = true)
        {
            this.From = from;
            this.To = to;
            this.Direction = to - from;
            this.Length = this.Direction.Normalize();
            this.BoundingBox = VRageMath.BoundingBox.CreateInvalid();
            if (calculateBoundingBox)
            {
                this.BoundingBox = this.BoundingBox.Include(ref from);
                this.BoundingBox = this.BoundingBox.Include(ref to);
            }
        }

        public static float GetShortestDistanceSquared(Line line1, Line line2)
        {
            Vector3 vector;
            Vector3 vector2;
            Vector3 vector3 = GetShortestVector(ref line1, ref line2, out vector, out vector2);
            return Vector3.Dot(vector3, vector3);
        }

        public static Vector3 GetShortestVector(ref Line line1, ref Line line2, out Vector3 res1, out Vector3 res2)
        {
            float num8;
            float num9;
            float num11;
            float num12;
            float num = 1E-06f;
            Vector3 vector = new Vector3 {
                X = line1.To.X - line1.From.X,
                Y = line1.To.Y - line1.From.Y,
                Z = line1.To.Z - line1.From.Z
            };
            Vector3 vector2 = new Vector3 {
                X = line2.To.X - line2.From.X,
                Y = line2.To.Y - line2.From.Y,
                Z = line2.To.Z - line2.From.Z
            };
            Vector3 vector3 = new Vector3 {
                X = line1.From.X - line2.From.X,
                Y = line1.From.Y - line2.From.Y,
                Z = line1.From.Z - line2.From.Z
            };
            float num2 = Vector3.Dot(vector, vector);
            float num3 = Vector3.Dot(vector, vector2);
            float num4 = Vector3.Dot(vector2, vector2);
            float num5 = Vector3.Dot(vector, vector3);
            float num6 = Vector3.Dot(vector2, vector3);
            float num7 = (num2 * num4) - (num3 * num3);
            float num10 = num7;
            float num13 = num7;
            if (num7 < num)
            {
                num9 = 0f;
                num10 = 1f;
                num12 = num6;
                num13 = num4;
            }
            else
            {
                num9 = (num3 * num6) - (num4 * num5);
                num12 = (num2 * num6) - (num3 * num5);
                if (num9 < 0.0)
                {
                    num9 = 0f;
                    num12 = num6;
                    num13 = num4;
                }
                else if (num9 > num10)
                {
                    num9 = num10;
                    num12 = num6 + num3;
                    num13 = num4;
                }
            }
            if (num12 < 0.0)
            {
                num12 = 0f;
                if (-num5 < 0f)
                {
                    num9 = 0f;
                }
                else if (-num5 > num2)
                {
                    num9 = num10;
                }
                else
                {
                    num9 = -num5;
                    num10 = num2;
                }
            }
            else if (num12 > num13)
            {
                num12 = num13;
                if ((-num5 + num3) < 0.0)
                {
                    num9 = 0f;
                }
                else if ((-num5 + num3) > num2)
                {
                    num9 = num10;
                }
                else
                {
                    num9 = -num5 + num3;
                    num10 = num2;
                }
            }
            if (Math.Abs(num9) < num)
            {
                num8 = 0f;
            }
            else
            {
                num8 = num9 / num10;
            }
            if (Math.Abs(num12) < num)
            {
                num11 = 0f;
            }
            else
            {
                num11 = num12 / num13;
            }
            res1.X = num8 * vector.X;
            res1.Y = num8 * vector.Y;
            res1.Z = num8 * vector.Z;
            Vector3 vector4 = new Vector3 {
                X = (vector3.X - (num11 * vector2.X)) + res1.X,
                Y = (vector3.Y - (num11 * vector2.Y)) + res1.Y,
                Z = (vector3.Z - (num11 * vector2.Z)) + res1.Z
            };
            res2 = res1 - vector4;
            return vector4;
        }
    }
}

