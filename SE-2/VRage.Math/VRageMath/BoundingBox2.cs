namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct BoundingBox2 : IEquatable<BoundingBox2>
    {
        public const int CornerCount = 8;
        [ProtoMember(20)]
        public Vector2 Min;
        [ProtoMember(0x19)]
        public Vector2 Max;
        public BoundingBox2(Vector2 min, Vector2 max)
        {
            this.Min = min;
            this.Max = max;
        }

        public static bool operator ==(BoundingBox2 a, BoundingBox2 b) => 
            a.Equals(b);

        public static bool operator !=(BoundingBox2 a, BoundingBox2 b)
        {
            if (!(a.Min != b.Min))
            {
                return (a.Max != b.Max);
            }
            return true;
        }

        public Vector2[] GetCorners() => 
            new Vector2[] { new Vector2(this.Min.X, this.Max.Y), new Vector2(this.Max.X, this.Max.Y), new Vector2(this.Max.X, this.Min.Y), new Vector2(this.Min.X, this.Min.Y), new Vector2(this.Min.X, this.Max.Y), new Vector2(this.Max.X, this.Max.Y), new Vector2(this.Max.X, this.Min.Y), new Vector2(this.Min.X, this.Min.Y) };

        public void GetCorners(Vector2[] corners)
        {
            corners[0].X = this.Min.X;
            corners[0].Y = this.Max.Y;
            corners[1].X = this.Max.X;
            corners[1].Y = this.Max.Y;
            corners[2].X = this.Max.X;
            corners[2].Y = this.Min.Y;
            corners[3].X = this.Min.X;
            corners[3].Y = this.Min.Y;
            corners[4].X = this.Min.X;
            corners[4].Y = this.Max.Y;
            corners[5].X = this.Max.X;
            corners[5].Y = this.Max.Y;
            corners[6].X = this.Max.X;
            corners[6].Y = this.Min.Y;
            corners[7].X = this.Min.X;
            corners[7].Y = this.Min.Y;
        }

        public unsafe void GetCornersUnsafe(Vector2* corners)
        {
            corners.X = this.Min.X;
            corners.Y = this.Max.Y;
            corners[1].X = this.Max.X;
            corners[1].Y = this.Max.Y;
            corners[2].X = this.Max.X;
            corners[2].Y = this.Min.Y;
            corners[3].X = this.Min.X;
            corners[3].Y = this.Min.Y;
            corners[4].X = this.Min.X;
            corners[4].Y = this.Max.Y;
            corners[5].X = this.Max.X;
            corners[5].Y = this.Max.Y;
            corners[6].X = this.Max.X;
            corners[6].Y = this.Min.Y;
            corners[7].X = this.Min.X;
            corners[7].Y = this.Min.Y;
        }

        public bool Equals(BoundingBox2 other) => 
            ((this.Min == other.Min) && (this.Max == other.Max));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is BoundingBox2)
            {
                flag = this.Equals((BoundingBox2) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (this.Min.GetHashCode() + this.Max.GetHashCode());

        public override string ToString() => 
            $"Min:{this.Min} Max:{this.Max}";

        public static BoundingBox2 CreateMerged(BoundingBox2 original, BoundingBox2 additional)
        {
            BoundingBox2 box;
            Vector2.Min(ref original.Min, ref additional.Min, out box.Min);
            Vector2.Max(ref original.Max, ref additional.Max, out box.Max);
            return box;
        }

        public static void CreateMerged(ref BoundingBox2 original, ref BoundingBox2 additional, out BoundingBox2 result)
        {
            Vector2 vector;
            Vector2 vector2;
            Vector2.Min(ref original.Min, ref additional.Min, out vector);
            Vector2.Max(ref original.Max, ref additional.Max, out vector2);
            result.Min = vector;
            result.Max = vector2;
        }

        public static BoundingBox2 CreateFromPoints(IEnumerable<Vector2> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException();
            }
            bool flag = false;
            Vector2 vector = new Vector2(float.MaxValue);
            Vector2 vector2 = new Vector2(float.MinValue);
            foreach (Vector2 vector3 in points)
            {
                Vector2 vector4 = vector3;
                Vector2.Min(ref vector, ref vector4, out vector);
                Vector2.Max(ref vector2, ref vector4, out vector2);
                flag = true;
            }
            if (!flag)
            {
                throw new ArgumentException();
            }
            return new BoundingBox2(vector, vector2);
        }

        public static BoundingBox2 CreateFromHalfExtent(Vector2 center, float halfExtent) => 
            CreateFromHalfExtent(center, new Vector2(halfExtent));

        public static BoundingBox2 CreateFromHalfExtent(Vector2 center, Vector2 halfExtent) => 
            new BoundingBox2(center - halfExtent, center + halfExtent);

        public BoundingBox2 Intersect(BoundingBox2 box)
        {
            BoundingBox2 box2;
            box2.Min.X = Math.Max(this.Min.X, box.Min.X);
            box2.Min.Y = Math.Max(this.Min.Y, box.Min.Y);
            box2.Max.X = Math.Min(this.Max.X, box.Max.X);
            box2.Max.Y = Math.Min(this.Max.Y, box.Max.Y);
            return box2;
        }

        public bool Intersects(BoundingBox2 box) => 
            this.Intersects(ref box);

        public bool Intersects(ref BoundingBox2 box)
        {
            if ((this.Max.X < box.Min.X) || (this.Min.X > box.Max.X))
            {
                return false;
            }
            return ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y));
        }

        public void Intersects(ref BoundingBox2 box, out bool result)
        {
            result = false;
            if (((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X)) && ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y)))
            {
                result = true;
            }
        }

        public Vector2 Center =>
            ((Vector2) ((this.Min + this.Max) / 2f));
        public Vector2 HalfExtents =>
            ((Vector2) ((this.Max - this.Min) / 2f));
        public Vector2 Extents =>
            (this.Max - this.Min);
        public float Width =>
            (this.Max.X - this.Min.X);
        public float Height =>
            (this.Max.Y - this.Min.Y);
        public float Distance(Vector2 point) => 
            Vector2.Distance(Vector2.Clamp(point, this.Min, this.Max), point);

        public ContainmentType Contains(BoundingBox2 box)
        {
            if (((this.Max.X < box.Min.X) || (this.Min.X > box.Max.X)) || ((this.Max.Y < box.Min.Y) || (this.Min.Y > box.Max.Y)))
            {
                return ContainmentType.Disjoint;
            }
            if (((this.Min.X <= box.Min.X) && (box.Max.X <= this.Max.X)) && ((this.Min.Y <= box.Min.Y) && (box.Max.Y <= this.Max.Y)))
            {
                return ContainmentType.Contains;
            }
            return ContainmentType.Intersects;
        }

        public void Contains(ref BoundingBox2 box, out ContainmentType result)
        {
            result = ContainmentType.Disjoint;
            if (((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X)) && ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y)))
            {
                result = (((this.Min.X > box.Min.X) || (box.Max.X > this.Max.X)) || ((this.Min.Y > box.Min.Y) || (box.Max.Y > this.Max.Y))) ? ContainmentType.Intersects : ContainmentType.Contains;
            }
        }

        public ContainmentType Contains(Vector2 point)
        {
            if (((this.Min.X <= point.X) && (point.X <= this.Max.X)) && ((this.Min.Y <= point.Y) && (point.Y <= this.Max.Y)))
            {
                return ContainmentType.Contains;
            }
            return ContainmentType.Disjoint;
        }

        public void Contains(ref Vector2 point, out ContainmentType result)
        {
            result = (((this.Min.X > point.X) || (point.X > this.Max.X)) || ((this.Min.Y > point.Y) || (point.Y > this.Max.Y))) ? ContainmentType.Disjoint : ContainmentType.Contains;
        }

        internal void SupportMapping(ref Vector2 v, out Vector2 result)
        {
            result.X = (v.X >= 0.0) ? this.Max.X : this.Min.X;
            result.Y = (v.Y >= 0.0) ? this.Max.Y : this.Min.Y;
        }

        public BoundingBox2 Translate(Vector2 vctTranlsation)
        {
            this.Min += vctTranlsation;
            this.Max += vctTranlsation;
            return this;
        }

        public Vector2 Size =>
            (this.Max - this.Min);
        public BoundingBox2 Include(ref Vector2 point)
        {
            this.Min.X = Math.Min(point.X, this.Min.X);
            this.Min.Y = Math.Min(point.Y, this.Min.Y);
            this.Max.X = Math.Max(point.X, this.Max.X);
            this.Max.Y = Math.Max(point.Y, this.Max.Y);
            return this;
        }

        public BoundingBox2 GetIncluded(Vector2 point)
        {
            BoundingBox2 box = this;
            box.Include(point);
            return box;
        }

        public BoundingBox2 Include(Vector2 point) => 
            this.Include(ref point);

        public BoundingBox2 Include(Vector2 p0, Vector2 p1, Vector2 p2) => 
            this.Include(ref p0, ref p1, ref p2);

        public BoundingBox2 Include(ref Vector2 p0, ref Vector2 p1, ref Vector2 p2)
        {
            this.Include(ref p0);
            this.Include(ref p1);
            this.Include(ref p2);
            return this;
        }

        public BoundingBox2 Include(ref BoundingBox2 box)
        {
            this.Min = Vector2.Min(this.Min, box.Min);
            this.Max = Vector2.Max(this.Max, box.Max);
            return this;
        }

        public BoundingBox2 Include(BoundingBox2 box) => 
            this.Include(ref box);

        public static BoundingBox2 CreateInvalid()
        {
            BoundingBox2 box = new BoundingBox2();
            Vector2 vector = new Vector2(float.MaxValue, float.MaxValue);
            Vector2 vector2 = new Vector2(float.MinValue, float.MinValue);
            box.Min = vector;
            box.Max = vector2;
            return box;
        }

        public float Perimeter()
        {
            Vector2 vector = this.Max - this.Min;
            return (2f * (vector.X = vector.Y));
        }

        public float Area()
        {
            Vector2 vector = this.Max - this.Min;
            return (vector.X * vector.Y);
        }

        public void Inflate(float size)
        {
            this.Max += new Vector2(size);
            this.Min -= new Vector2(size);
        }

        public void InflateToMinimum(Vector2 minimumSize)
        {
            Vector2 center = this.Center;
            if (this.Size.X < minimumSize.X)
            {
                this.Min.X = center.X - (minimumSize.X / 2f);
                this.Max.X = center.X + (minimumSize.X / 2f);
            }
            if (this.Size.Y < minimumSize.Y)
            {
                this.Min.Y = center.Y - (minimumSize.Y / 2f);
                this.Max.Y = center.Y + (minimumSize.Y / 2f);
            }
        }

        public void Scale(Vector2 scale)
        {
            Vector2 center = this.Center;
            Vector2 vector2 = this.HalfExtents * scale;
            this.Min = center - vector2;
            this.Max = center + vector2;
        }
    }
}

