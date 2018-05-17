namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using Unsharper;

    [Serializable, StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct BoundingBoxI : IEquatable<BoundingBoxI>
    {
        public const int CornerCount = 8;
        [ProtoMember(0x17)]
        public Vector3I Min;
        [ProtoMember(0x1c)]
        public Vector3I Max;
        public BoundingBoxI(BoundingBox box)
        {
            this.Min = new Vector3I(box.Min);
            this.Max = new Vector3I(box.Max);
        }

        public BoundingBoxI(Vector3I min, Vector3I max)
        {
            this.Min = min;
            this.Max = max;
        }

        public BoundingBoxI(int min, int max)
        {
            this.Min = new Vector3I(min);
            this.Max = new Vector3I(max);
        }

        public static explicit operator BoundingBoxI(BoundingBoxD box) => 
            new BoundingBoxI((Vector3I) box.Min, (Vector3I) box.Max);

        public static explicit operator BoundingBoxI(BoundingBox box) => 
            new BoundingBoxI((Vector3I) box.Min, (Vector3I) box.Max);

        public static bool operator ==(BoundingBoxI a, BoundingBoxI b) => 
            a.Equals(b);

        public static bool operator !=(BoundingBoxI a, BoundingBoxI b)
        {
            if (!(a.Min != b.Min))
            {
                return (a.Max != b.Max);
            }
            return true;
        }

        public static implicit operator BoundingBox(BoundingBoxI box) => 
            new BoundingBox((Vector3) box.Min, (Vector3) box.Max);

        public static implicit operator BoundingBoxD(BoundingBoxI box) => 
            new BoundingBoxD((Vector3D) box.Min, (Vector3D) box.Max);

        public Vector3I[] GetCorners() => 
            new Vector3I[] { new Vector3I(this.Min.X, this.Max.Y, this.Max.Z), new Vector3I(this.Max.X, this.Max.Y, this.Max.Z), new Vector3I(this.Max.X, this.Min.Y, this.Max.Z), new Vector3I(this.Min.X, this.Min.Y, this.Max.Z), new Vector3I(this.Min.X, this.Max.Y, this.Min.Z), new Vector3I(this.Max.X, this.Max.Y, this.Min.Z), new Vector3I(this.Max.X, this.Min.Y, this.Min.Z), new Vector3I(this.Min.X, this.Min.Y, this.Min.Z) };

        public void GetCorners(Vector3I[] corners)
        {
            corners[0].X = this.Min.X;
            corners[0].Y = this.Max.Y;
            corners[0].Z = this.Max.Z;
            corners[1].X = this.Max.X;
            corners[1].Y = this.Max.Y;
            corners[1].Z = this.Max.Z;
            corners[2].X = this.Max.X;
            corners[2].Y = this.Min.Y;
            corners[2].Z = this.Max.Z;
            corners[3].X = this.Min.X;
            corners[3].Y = this.Min.Y;
            corners[3].Z = this.Max.Z;
            corners[4].X = this.Min.X;
            corners[4].Y = this.Max.Y;
            corners[4].Z = this.Min.Z;
            corners[5].X = this.Max.X;
            corners[5].Y = this.Max.Y;
            corners[5].Z = this.Min.Z;
            corners[6].X = this.Max.X;
            corners[6].Y = this.Min.Y;
            corners[6].Z = this.Min.Z;
            corners[7].X = this.Min.X;
            corners[7].Y = this.Min.Y;
            corners[7].Z = this.Min.Z;
        }

        [UnsharperDisableReflection]
        public unsafe void GetCornersUnsafe(Vector3I* corners)
        {
            corners.X = this.Min.X;
            corners.Y = this.Max.Y;
            corners.Z = this.Max.Z;
            corners[1].X = this.Max.X;
            corners[1].Y = this.Max.Y;
            corners[1].Z = this.Max.Z;
            corners[2].X = this.Max.X;
            corners[2].Y = this.Min.Y;
            corners[2].Z = this.Max.Z;
            corners[3].X = this.Min.X;
            corners[3].Y = this.Min.Y;
            corners[3].Z = this.Max.Z;
            corners[4].X = this.Min.X;
            corners[4].Y = this.Max.Y;
            corners[4].Z = this.Min.Z;
            corners[5].X = this.Max.X;
            corners[5].Y = this.Max.Y;
            corners[5].Z = this.Min.Z;
            corners[6].X = this.Max.X;
            corners[6].Y = this.Min.Y;
            corners[6].Z = this.Min.Z;
            corners[7].X = this.Min.X;
            corners[7].Y = this.Min.Y;
            corners[7].Z = this.Min.Z;
        }

        public bool Equals(BoundingBoxI other) => 
            ((this.Min == other.Min) && (this.Max == other.Max));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is BoundingBoxI)
            {
                flag = this.Equals((BoundingBoxI) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (this.Min.GetHashCode() + this.Max.GetHashCode());

        public override string ToString() => 
            string.Format(CultureInfo.CurrentCulture, "{{Min:{0} Max:{1}}}", new object[] { this.Min.ToString(), this.Max.ToString() });

        public static BoundingBoxI CreateMerged(BoundingBoxI original, BoundingBoxI additional)
        {
            BoundingBoxI xi;
            Vector3I.Min(ref original.Min, ref additional.Min, out xi.Min);
            Vector3I.Max(ref original.Max, ref additional.Max, out xi.Max);
            return xi;
        }

        public static void CreateMerged(ref BoundingBoxI original, ref BoundingBoxI additional, out BoundingBoxI result)
        {
            Vector3I vectori;
            Vector3I vectori2;
            Vector3I.Min(ref original.Min, ref additional.Min, out vectori);
            Vector3I.Max(ref original.Max, ref additional.Max, out vectori2);
            result.Min = vectori;
            result.Max = vectori2;
        }

        public static BoundingBoxI CreateFromSphere(BoundingSphere sphere)
        {
            BoundingBoxI xi;
            xi.Min.X = (int) (sphere.Center.X - sphere.Radius);
            xi.Min.Y = (int) (sphere.Center.Y - sphere.Radius);
            xi.Min.Z = (int) (sphere.Center.Z - sphere.Radius);
            xi.Max.X = (int) (sphere.Center.X + sphere.Radius);
            xi.Max.Y = (int) (sphere.Center.Y + sphere.Radius);
            xi.Max.Z = (int) (sphere.Center.Z + sphere.Radius);
            return xi;
        }

        public static void CreateFromSphere(ref BoundingSphere sphere, out BoundingBoxI result)
        {
            result.Min.X = (int) (sphere.Center.X - sphere.Radius);
            result.Min.Y = (int) (sphere.Center.Y - sphere.Radius);
            result.Min.Z = (int) (sphere.Center.Z - sphere.Radius);
            result.Max.X = (int) (sphere.Center.X + sphere.Radius);
            result.Max.Y = (int) (sphere.Center.Y + sphere.Radius);
            result.Max.Z = (int) (sphere.Center.Z + sphere.Radius);
        }

        public static BoundingBoxI CreateFromPoints(IEnumerable<Vector3I> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException();
            }
            bool flag = false;
            Vector3I vectori = new Vector3I(0x7fffffff);
            Vector3I vectori2 = new Vector3I(-2147483648);
            foreach (Vector3I vectori3 in points)
            {
                Vector3I vectori4 = vectori3;
                Vector3I.Min(ref vectori, ref vectori4, out vectori);
                Vector3I.Max(ref vectori2, ref vectori4, out vectori2);
                flag = true;
            }
            if (!flag)
            {
                throw new ArgumentException();
            }
            return new BoundingBoxI(vectori, vectori2);
        }

        public void IntersectWith(ref BoundingBoxI box)
        {
            this.Min.X = Math.Max(this.Min.X, box.Min.X);
            this.Min.Y = Math.Max(this.Min.Y, box.Min.Y);
            this.Min.Z = Math.Max(this.Min.Z, box.Min.Z);
            this.Max.X = Math.Min(this.Max.X, box.Max.X);
            this.Max.Y = Math.Min(this.Max.Y, box.Max.Y);
            this.Max.Z = Math.Min(this.Max.Z, box.Max.Z);
        }

        public BoundingBoxI Intersect(BoundingBoxI box)
        {
            BoundingBoxI xi;
            xi.Min.X = Math.Max(this.Min.X, box.Min.X);
            xi.Min.Y = Math.Max(this.Min.Y, box.Min.Y);
            xi.Min.Z = Math.Max(this.Min.Z, box.Min.Z);
            xi.Max.X = Math.Min(this.Max.X, box.Max.X);
            xi.Max.Y = Math.Min(this.Max.Y, box.Max.Y);
            xi.Max.Z = Math.Min(this.Max.Z, box.Max.Z);
            return xi;
        }

        public bool Intersects(BoundingBoxI box) => 
            this.Intersects(ref box);

        public bool Intersects(ref BoundingBoxI box)
        {
            if (((this.Max.X < box.Min.X) || (this.Min.X > box.Max.X)) || ((this.Max.Y < box.Min.Y) || (this.Min.Y > box.Max.Y)))
            {
                return false;
            }
            return ((this.Max.Z >= box.Min.Z) && (this.Min.Z <= box.Max.Z));
        }

        public void Intersects(ref BoundingBoxI box, out bool result)
        {
            result = false;
            if ((((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X)) && ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y))) && ((this.Max.Z >= box.Min.Z) && (this.Min.Z <= box.Max.Z)))
            {
                result = true;
            }
        }

        public bool IntersectsTriangle(Vector3I v0, Vector3I v1, Vector3I v2) => 
            this.IntersectsTriangle(ref v0, ref v1, ref v2);

        public bool IntersectsTriangle(ref Vector3I v0, ref Vector3I v1, ref Vector3I v2)
        {
            Vector3I vectori;
            Vector3I vectori2;
            Vector3I vectori5;
            int num;
            PlaneIntersectionType type;
            Vector3I.Min(ref v0, ref v1, out vectori);
            Vector3I.Min(ref vectori, ref v2, out vectori);
            Vector3I.Max(ref v0, ref v1, out vectori2);
            Vector3I.Max(ref vectori2, ref v2, out vectori2);
            if (vectori.X > this.Max.X)
            {
                return false;
            }
            if (vectori2.X < this.Min.X)
            {
                return false;
            }
            if (vectori.Y > this.Max.Y)
            {
                return false;
            }
            if (vectori2.Y < this.Min.Y)
            {
                return false;
            }
            if (vectori.Z > this.Max.Z)
            {
                return false;
            }
            if (vectori2.Z < this.Min.Z)
            {
                return false;
            }
            Vector3I vectori3 = v1 - v0;
            Vector3I vectori4 = v2 - v1;
            Vector3I.Cross(ref vectori3, ref vectori4, out vectori5);
            Vector3I.Dot(ref v0, ref vectori5, out num);
            Plane plane = new Plane((Vector3) vectori5, (float) -num);
            this.Intersects(ref plane, out type);
            switch (type)
            {
                case PlaneIntersectionType.Back:
                    return false;

                case PlaneIntersectionType.Front:
                    return false;
            }
            Vector3I center = this.Center;
            BoundingBoxI xi = new BoundingBoxI(this.Min - center, this.Max - center);
            Vector3I halfExtents = xi.HalfExtents;
            Vector3I vectori8 = v0 - v2;
            Vector3I vectori9 = v0 - center;
            Vector3I vectori10 = v1 - center;
            Vector3I vectori11 = v2 - center;
            float num2 = (halfExtents.Y * Math.Abs(vectori3.Z)) + (halfExtents.Z * Math.Abs(vectori3.Y));
            float num3 = (vectori9.Z * vectori10.Y) - (vectori9.Y * vectori10.Z);
            float num5 = (vectori11.Z * vectori3.Y) - (vectori11.Y * vectori3.Z);
            if ((Math.Min(num3, num5) > num2) || (Math.Max(num3, num5) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectori3.Z)) + (halfExtents.Z * Math.Abs(vectori3.X));
            num3 = (vectori9.X * vectori10.Z) - (vectori9.Z * vectori10.X);
            num5 = (vectori11.X * vectori3.Z) - (vectori11.Z * vectori3.X);
            if ((Math.Min(num3, num5) > num2) || (Math.Max(num3, num5) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectori3.Y)) + (halfExtents.Y * Math.Abs(vectori3.X));
            num3 = (vectori9.Y * vectori10.X) - (vectori9.X * vectori10.Y);
            num5 = (vectori11.Y * vectori3.X) - (vectori11.X * vectori3.Y);
            if ((Math.Min(num3, num5) > num2) || (Math.Max(num3, num5) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.Y * Math.Abs(vectori4.Z)) + (halfExtents.Z * Math.Abs(vectori4.Y));
            float num4 = (vectori10.Z * vectori11.Y) - (vectori10.Y * vectori11.Z);
            num3 = (vectori9.Z * vectori4.Y) - (vectori9.Y * vectori4.Z);
            if ((Math.Min(num4, num3) > num2) || (Math.Max(num4, num3) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectori4.Z)) + (halfExtents.Z * Math.Abs(vectori4.X));
            num4 = (vectori10.X * vectori11.Z) - (vectori10.Z * vectori11.X);
            num3 = (vectori9.X * vectori4.Z) - (vectori9.Z * vectori4.X);
            if ((Math.Min(num4, num3) > num2) || (Math.Max(num4, num3) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectori4.Y)) + (halfExtents.Y * Math.Abs(vectori4.X));
            num4 = (vectori10.Y * vectori11.X) - (vectori10.X * vectori11.Y);
            num3 = (vectori9.Y * vectori4.X) - (vectori9.X * vectori4.Y);
            if ((Math.Min(num4, num3) > num2) || (Math.Max(num4, num3) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.Y * Math.Abs(vectori8.Z)) + (halfExtents.Z * Math.Abs(vectori8.Y));
            num5 = (vectori11.Z * vectori9.Y) - (vectori11.Y * vectori9.Z);
            num4 = (vectori10.Z * vectori8.Y) - (vectori10.Y * vectori8.Z);
            if ((Math.Min(num5, num4) > num2) || (Math.Max(num5, num4) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectori8.Z)) + (halfExtents.Z * Math.Abs(vectori8.X));
            num5 = (vectori11.X * vectori9.Z) - (vectori11.Z * vectori9.X);
            num4 = (vectori10.X * vectori8.Z) - (vectori10.Z * vectori8.X);
            if ((Math.Min(num5, num4) > num2) || (Math.Max(num5, num4) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectori8.Y)) + (halfExtents.Y * Math.Abs(vectori8.X));
            num5 = (vectori11.Y * vectori9.X) - (vectori11.X * vectori9.Y);
            num4 = (vectori10.Y * vectori8.X) - (vectori10.X * vectori8.Y);
            return ((Math.Min(num5, num4) <= num2) && (Math.Max(num5, num4) >= -num2));
        }

        public Vector3I Center =>
            ((this.Min + this.Max) / 2);
        public Vector3I HalfExtents =>
            ((this.Max - this.Min) / 2);
        public PlaneIntersectionType Intersects(Plane plane)
        {
            Vector3I vectori;
            Vector3I vectori2;
            vectori.X = (plane.Normal.X >= 0.0) ? this.Min.X : this.Max.X;
            vectori.Y = (plane.Normal.Y >= 0.0) ? this.Min.Y : this.Max.Y;
            vectori.Z = (plane.Normal.Z >= 0.0) ? this.Min.Z : this.Max.Z;
            vectori2.X = (plane.Normal.X >= 0.0) ? this.Max.X : this.Min.X;
            vectori2.Y = (plane.Normal.Y >= 0.0) ? this.Max.Y : this.Min.Y;
            vectori2.Z = (plane.Normal.Z >= 0.0) ? this.Max.Z : this.Min.Z;
            if (((((plane.Normal.X * vectori.X) + (plane.Normal.Y * vectori.Y)) + (plane.Normal.Z * vectori.Z)) + plane.D) > 0.0)
            {
                return PlaneIntersectionType.Front;
            }
            if (((((plane.Normal.X * vectori2.X) + (plane.Normal.Y * vectori2.Y)) + (plane.Normal.Z * vectori2.Z)) + plane.D) >= 0.0)
            {
                return PlaneIntersectionType.Intersecting;
            }
            return PlaneIntersectionType.Back;
        }

        public void Intersects(ref Plane plane, out PlaneIntersectionType result)
        {
            Vector3I vectori;
            Vector3I vectori2;
            vectori.X = (plane.Normal.X >= 0.0) ? this.Min.X : this.Max.X;
            vectori.Y = (plane.Normal.Y >= 0.0) ? this.Min.Y : this.Max.Y;
            vectori.Z = (plane.Normal.Z >= 0.0) ? this.Min.Z : this.Max.Z;
            vectori2.X = (plane.Normal.X >= 0.0) ? this.Max.X : this.Min.X;
            vectori2.Y = (plane.Normal.Y >= 0.0) ? this.Max.Y : this.Min.Y;
            vectori2.Z = (plane.Normal.Z >= 0.0) ? this.Max.Z : this.Min.Z;
            if (((((plane.Normal.X * vectori.X) + (plane.Normal.Y * vectori.Y)) + (plane.Normal.Z * vectori.Z)) + plane.D) > 0.0)
            {
                result = PlaneIntersectionType.Front;
            }
            else if (((((plane.Normal.X * vectori2.X) + (plane.Normal.Y * vectori2.Y)) + (plane.Normal.Z * vectori2.Z)) + plane.D) < 0.0)
            {
                result = PlaneIntersectionType.Back;
            }
            else
            {
                result = PlaneIntersectionType.Intersecting;
            }
        }

        public bool Intersects(Line line, out float distance)
        {
            distance = 0f;
            float? nullable = this.Intersects(new Ray(line.From, line.Direction));
            if (!nullable.HasValue)
            {
                return false;
            }
            if (nullable.Value < 0f)
            {
                return false;
            }
            if (nullable.Value > line.Length)
            {
                return false;
            }
            distance = nullable.Value;
            return true;
        }

        public float? Intersects(Ray ray)
        {
            float num = 0f;
            float maxValue = float.MaxValue;
            if (Math.Abs(ray.Direction.X) < 9.99999997475243E-07)
            {
                if ((ray.Position.X < this.Min.X) || (ray.Position.X > this.Max.X))
                {
                    return null;
                }
            }
            else
            {
                float num3 = 1f / ray.Direction.X;
                float num4 = (this.Min.X - ray.Position.X) * num3;
                float num5 = (this.Max.X - ray.Position.X) * num3;
                if (num4 > num5)
                {
                    float num6 = num4;
                    num4 = num5;
                    num5 = num6;
                }
                num = MathHelper.Max(num4, num);
                maxValue = MathHelper.Min(num5, maxValue);
                if (num > maxValue)
                {
                    return null;
                }
            }
            if (Math.Abs(ray.Direction.Y) < 9.99999997475243E-07)
            {
                if ((ray.Position.Y < this.Min.Y) || (ray.Position.Y > this.Max.Y))
                {
                    return null;
                }
            }
            else
            {
                float num7 = 1f / ray.Direction.Y;
                float num8 = (this.Min.Y - ray.Position.Y) * num7;
                float num9 = (this.Max.Y - ray.Position.Y) * num7;
                if (num8 > num9)
                {
                    float num10 = num8;
                    num8 = num9;
                    num9 = num10;
                }
                num = MathHelper.Max(num8, num);
                maxValue = MathHelper.Min(num9, maxValue);
                if (num > maxValue)
                {
                    return null;
                }
            }
            if (Math.Abs(ray.Direction.Z) < 9.99999997475243E-07)
            {
                if ((ray.Position.Z < this.Min.Z) || (ray.Position.Z > this.Max.Z))
                {
                    return null;
                }
            }
            else
            {
                float num11 = 1f / ray.Direction.Z;
                float num12 = (this.Min.Z - ray.Position.Z) * num11;
                float num13 = (this.Max.Z - ray.Position.Z) * num11;
                if (num12 > num13)
                {
                    float num14 = num12;
                    num12 = num13;
                    num13 = num14;
                }
                num = MathHelper.Max(num12, num);
                float num15 = MathHelper.Min(num13, maxValue);
                if (num > num15)
                {
                    return null;
                }
            }
            return new float?(num);
        }

        public void Intersects(ref Ray ray, out float? result)
        {
            result = 0;
            float num = 0f;
            float maxValue = float.MaxValue;
            if (Math.Abs(ray.Direction.X) < 9.99999997475243E-07)
            {
                if ((ray.Position.X < this.Min.X) || (ray.Position.X > this.Max.X))
                {
                    return;
                }
            }
            else
            {
                float num3 = 1f / ray.Direction.X;
                float num4 = (this.Min.X - ray.Position.X) * num3;
                float num5 = (this.Max.X - ray.Position.X) * num3;
                if (num4 > num5)
                {
                    float num6 = num4;
                    num4 = num5;
                    num5 = num6;
                }
                num = MathHelper.Max(num4, num);
                maxValue = MathHelper.Min(num5, maxValue);
                if (num > maxValue)
                {
                    return;
                }
            }
            if (Math.Abs(ray.Direction.Y) < 9.99999997475243E-07)
            {
                if ((ray.Position.Y < this.Min.Y) || (ray.Position.Y > this.Max.Y))
                {
                    return;
                }
            }
            else
            {
                float num7 = 1f / ray.Direction.Y;
                float num8 = (this.Min.Y - ray.Position.Y) * num7;
                float num9 = (this.Max.Y - ray.Position.Y) * num7;
                if (num8 > num9)
                {
                    float num10 = num8;
                    num8 = num9;
                    num9 = num10;
                }
                num = MathHelper.Max(num8, num);
                maxValue = MathHelper.Min(num9, maxValue);
                if (num > maxValue)
                {
                    return;
                }
            }
            if (Math.Abs(ray.Direction.Z) < 9.99999997475243E-07)
            {
                if ((ray.Position.Z < this.Min.Z) || (ray.Position.Z > this.Max.Z))
                {
                    return;
                }
            }
            else
            {
                float num11 = 1f / ray.Direction.Z;
                float num12 = (this.Min.Z - ray.Position.Z) * num11;
                float num13 = (this.Max.Z - ray.Position.Z) * num11;
                if (num12 > num13)
                {
                    float num14 = num12;
                    num12 = num13;
                    num13 = num14;
                }
                num = MathHelper.Max(num12, num);
                float num15 = MathHelper.Min(num13, maxValue);
                if (num > num15)
                {
                    return;
                }
            }
            result = new float?(num);
        }

        public float Distance(Vector3I point)
        {
            Vector3I vectori2 = Vector3I.Clamp(point, this.Min, this.Max) - point;
            return (float) vectori2.Length();
        }

        public ContainmentType Contains(BoundingBoxI box)
        {
            if ((((this.Max.X < box.Min.X) || (this.Min.X > box.Max.X)) || ((this.Max.Y < box.Min.Y) || (this.Min.Y > box.Max.Y))) || ((this.Max.Z < box.Min.Z) || (this.Min.Z > box.Max.Z)))
            {
                return ContainmentType.Disjoint;
            }
            if ((((this.Min.X <= box.Min.X) && (box.Max.X <= this.Max.X)) && ((this.Min.Y <= box.Min.Y) && (box.Max.Y <= this.Max.Y))) && ((this.Min.Z <= box.Min.Z) && (box.Max.Z <= this.Max.Z)))
            {
                return ContainmentType.Contains;
            }
            return ContainmentType.Intersects;
        }

        public void Contains(ref BoundingBoxI box, out ContainmentType result)
        {
            result = ContainmentType.Disjoint;
            if ((((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X)) && ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y))) && ((this.Max.Z >= box.Min.Z) && (this.Min.Z <= box.Max.Z)))
            {
                result = ((((this.Min.X > box.Min.X) || (box.Max.X > this.Max.X)) || ((this.Min.Y > box.Min.Y) || (box.Max.Y > this.Max.Y))) || ((this.Min.Z > box.Min.Z) || (box.Max.Z > this.Max.Z))) ? ContainmentType.Intersects : ContainmentType.Contains;
            }
        }

        public ContainmentType Contains(Vector3I point)
        {
            if ((((this.Min.X <= point.X) && (point.X <= this.Max.X)) && ((this.Min.Y <= point.Y) && (point.Y <= this.Max.Y))) && ((this.Min.Z <= point.Z) && (point.Z <= this.Max.Z)))
            {
                return ContainmentType.Contains;
            }
            return ContainmentType.Disjoint;
        }

        public ContainmentType Contains(Vector3 point)
        {
            if ((((this.Min.X <= point.X) && (point.X <= this.Max.X)) && ((this.Min.Y <= point.Y) && (point.Y <= this.Max.Y))) && ((this.Min.Z <= point.Z) && (point.Z <= this.Max.Z)))
            {
                return ContainmentType.Contains;
            }
            return ContainmentType.Disjoint;
        }

        public void Contains(ref Vector3I point, out ContainmentType result)
        {
            result = ((((this.Min.X > point.X) || (point.X > this.Max.X)) || ((this.Min.Y > point.Y) || (point.Y > this.Max.Y))) || ((this.Min.Z > point.Z) || (point.Z > this.Max.Z))) ? ContainmentType.Disjoint : ContainmentType.Contains;
        }

        internal void SupportMapping(ref Vector3I v, out Vector3I result)
        {
            result.X = (v.X >= 0.0) ? this.Max.X : this.Min.X;
            result.Y = (v.Y >= 0.0) ? this.Max.Y : this.Min.Y;
            result.Z = (v.Z >= 0.0) ? this.Max.Z : this.Min.Z;
        }

        public BoundingBoxI Translate(Vector3I vctTranlsation)
        {
            this.Min += vctTranlsation;
            this.Max += vctTranlsation;
            return this;
        }

        public Vector3I Size =>
            (this.Max - this.Min);
        public BoundingBoxI Include(ref Vector3I point)
        {
            if (point.X < this.Min.X)
            {
                this.Min.X = point.X;
            }
            if (point.Y < this.Min.Y)
            {
                this.Min.Y = point.Y;
            }
            if (point.Z < this.Min.Z)
            {
                this.Min.Z = point.Z;
            }
            if (point.X > this.Max.X)
            {
                this.Max.X = point.X;
            }
            if (point.Y > this.Max.Y)
            {
                this.Max.Y = point.Y;
            }
            if (point.Z > this.Max.Z)
            {
                this.Max.Z = point.Z;
            }
            return this;
        }

        public BoundingBoxI GetIncluded(Vector3I point)
        {
            BoundingBoxI xi = this;
            xi.Include(point);
            return xi;
        }

        public BoundingBoxI Include(Vector3I point) => 
            this.Include(ref point);

        public BoundingBoxI Include(Vector3I p0, Vector3I p1, Vector3I p2) => 
            this.Include(ref p0, ref p1, ref p2);

        public BoundingBoxI Include(ref Vector3I p0, ref Vector3I p1, ref Vector3I p2)
        {
            this.Include(ref p0);
            this.Include(ref p1);
            this.Include(ref p2);
            return this;
        }

        public BoundingBoxI Include(ref BoundingBoxI box)
        {
            this.Min = Vector3I.Min(this.Min, box.Min);
            this.Max = Vector3I.Max(this.Max, box.Max);
            return this;
        }

        public BoundingBoxI Include(BoundingBoxI box) => 
            this.Include(ref box);

        public static BoundingBoxI CreateInvalid()
        {
            BoundingBoxI xi = new BoundingBoxI();
            Vector3I vectori = new Vector3I(0x7fffffff, 0x7fffffff, 0x7fffffff);
            Vector3I vectori2 = new Vector3I(-2147483648, -2147483648, -2147483648);
            xi.Min = vectori;
            xi.Max = vectori2;
            return xi;
        }

        public float SurfaceArea()
        {
            Vector3I vectori = this.Max - this.Min;
            return (float) (2 * (((vectori.X * vectori.Y) + (vectori.X * vectori.Z)) + (vectori.Y * vectori.Z)));
        }

        public float Volume()
        {
            Vector3I vectori = this.Max - this.Min;
            return (float) ((vectori.X * vectori.Y) * vectori.Z);
        }

        public float Perimeter
        {
            get
            {
                float num = this.Max.X - this.Min.X;
                float num2 = this.Max.Y - this.Min.Y;
                float num3 = this.Max.Z - this.Min.Z;
                return (4f * ((num + num2) + num3));
            }
        }
        public void Inflate(int size)
        {
            this.Max += new Vector3I(size);
            this.Min -= new Vector3I(size);
        }

        public void InflateToMinimum(Vector3I minimumSize)
        {
            Vector3I center = this.Center;
            if (this.Size.X < minimumSize.X)
            {
                this.Min.X = center.X - (minimumSize.X / 2);
                this.Max.X = center.X + (minimumSize.X / 2);
            }
            if (this.Size.Y < minimumSize.Y)
            {
                this.Min.Y = center.Y - (minimumSize.Y / 2);
                this.Max.Y = center.Y + (minimumSize.Y / 2);
            }
            if (this.Size.Z < minimumSize.Z)
            {
                this.Min.Z = center.Z - (minimumSize.Z / 2);
                this.Max.Z = center.Z + (minimumSize.Z / 2);
            }
        }

        public bool IsValid =>
            (((this.Min.X <= this.Max.X) && (this.Min.Y <= this.Max.Y)) && (this.Min.Z <= this.Max.Z));
        public static IEnumerable<Vector3I> IterateDifference(BoundingBoxI left, BoundingBoxI right)
        {
            Vector3I iteratorVariable0;
            Vector3I min = left.Min;
            int x = Math.Min(left.Max.X, right.Min.X);
            Vector3I max = new Vector3I(x, left.Max.Y, left.Max.Z);
            iteratorVariable0.X = min.X;
            while (iteratorVariable0.X < max.X)
            {
                iteratorVariable0.Y = min.Y;
                while (iteratorVariable0.Y < max.Y)
                {
                    iteratorVariable0.Z = min.Z;
                    while (iteratorVariable0.Z < max.Z)
                    {
                        yield return iteratorVariable0;
                        iteratorVariable0.Z++;
                    }
                    iteratorVariable0.Y++;
                }
                iteratorVariable0.X++;
            }
            int introduced2 = Math.Max(left.Min.X, right.Max.X);
            min = new Vector3I(introduced2, left.Min.Y, left.Min.Z);
            max = left.Max;
            iteratorVariable0.X = min.X;
            while (iteratorVariable0.X < max.X)
            {
                iteratorVariable0.Y = min.Y;
                while (iteratorVariable0.Y < max.Y)
                {
                    iteratorVariable0.Z = min.Z;
                    while (iteratorVariable0.Z < max.Z)
                    {
                        yield return iteratorVariable0;
                        iteratorVariable0.Z++;
                    }
                    iteratorVariable0.Y++;
                }
                iteratorVariable0.X++;
            }
            left.Min.X = Math.Max(left.Min.X, right.Min.X);
            left.Max.X = Math.Min(left.Max.X, right.Max.X);
            min = left.Min;
            int y = Math.Min(left.Max.Y, right.Min.Y);
            max = new Vector3I(left.Max.X, y, left.Max.Z);
            iteratorVariable0.Y = min.Y;
            while (iteratorVariable0.Y < max.Y)
            {
                iteratorVariable0.X = min.X;
                while (iteratorVariable0.X < max.X)
                {
                    iteratorVariable0.Z = min.Z;
                    while (iteratorVariable0.Z < max.Z)
                    {
                        yield return iteratorVariable0;
                        iteratorVariable0.Z++;
                    }
                    iteratorVariable0.X++;
                }
                iteratorVariable0.Y++;
            }
            int introduced4 = Math.Max(left.Min.Y, right.Max.Y);
            min = new Vector3I(left.Min.X, introduced4, left.Min.Z);
            max = left.Max;
            iteratorVariable0.Y = min.Y;
            while (iteratorVariable0.Y < max.Y)
            {
                iteratorVariable0.X = min.X;
                while (iteratorVariable0.X < max.X)
                {
                    iteratorVariable0.Z = min.Z;
                    while (iteratorVariable0.Z < max.Z)
                    {
                        yield return iteratorVariable0;
                        iteratorVariable0.Z++;
                    }
                    iteratorVariable0.X++;
                }
                iteratorVariable0.Y++;
            }
            left.Min.Y = Math.Max(left.Min.Y, right.Min.Y);
            left.Max.Y = Math.Min(left.Max.Y, right.Max.Y);
            min = left.Min;
            max = new Vector3I(left.Max.X, left.Max.Y, Math.Min(left.Max.Z, right.Min.Z));
            iteratorVariable0.Z = min.Z;
            while (iteratorVariable0.Z < max.Z)
            {
                iteratorVariable0.Y = min.Y;
                while (iteratorVariable0.Y < max.Y)
                {
                    iteratorVariable0.X = min.X;
                    while (iteratorVariable0.X < max.X)
                    {
                        yield return iteratorVariable0;
                        iteratorVariable0.X++;
                    }
                    iteratorVariable0.Y++;
                }
                iteratorVariable0.Z++;
            }
            min = new Vector3I(left.Min.X, left.Min.Y, Math.Max(left.Min.Z, right.Max.Z));
            max = left.Max;
            iteratorVariable0.Z = min.Z;
            while (iteratorVariable0.Z < max.Z)
            {
                iteratorVariable0.Y = min.Y;
                while (iteratorVariable0.Y < max.Y)
                {
                    iteratorVariable0.X = min.X;
                    while (iteratorVariable0.X < max.X)
                    {
                        yield return iteratorVariable0;
                        iteratorVariable0.X++;
                    }
                    iteratorVariable0.Y++;
                }
                iteratorVariable0.Z++;
            }
        }

        public static IEnumerable<Vector3I> EnumeratePoints(BoundingBoxI rangeInclusive)
        {
            Vector3I iteratorVariable0;
            iteratorVariable0.Z = rangeInclusive.Min.Z;
            while (iteratorVariable0.Z < rangeInclusive.Max.Z)
            {
                iteratorVariable0.Y = rangeInclusive.Min.Y;
                while (iteratorVariable0.Y < rangeInclusive.Max.Y)
                {
                    iteratorVariable0.X = rangeInclusive.Min.X;
                    while (iteratorVariable0.X < rangeInclusive.Max.X)
                    {
                        yield return iteratorVariable0;
                        iteratorVariable0.X++;
                    }
                    iteratorVariable0.Y++;
                }
                iteratorVariable0.Z++;
            }
        }

    }
}

