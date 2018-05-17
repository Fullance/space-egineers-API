namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct BoundingBox2I : IEquatable<BoundingBox2I>
    {
        public const int CornerCount = 8;
        [ProtoMember(20)]
        public Vector2I Min;
        [ProtoMember(0x19)]
        public Vector2I Max;
        public BoundingBox2I(Vector2I min, Vector2I max)
        {
            this.Min = min;
            this.Max = max;
        }

        public static bool operator ==(BoundingBox2I a, BoundingBox2I b) => 
            a.Equals(b);

        public static bool operator !=(BoundingBox2I a, BoundingBox2I b)
        {
            if (!(a.Min != b.Min))
            {
                return (a.Max != b.Max);
            }
            return true;
        }

        public Vector2I[] GetCorners() => 
            new Vector2I[] { new Vector2I(this.Min.X, this.Max.Y), new Vector2I(this.Max.X, this.Max.Y), new Vector2I(this.Max.X, this.Min.Y), new Vector2I(this.Min.X, this.Min.Y), new Vector2I(this.Min.X, this.Max.Y), new Vector2I(this.Max.X, this.Max.Y), new Vector2I(this.Max.X, this.Min.Y), new Vector2I(this.Min.X, this.Min.Y) };

        public void GetCorners(Vector2I[] corners)
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

        public unsafe void GetCornersUnsafe(Vector2I* corners)
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

        public bool Equals(BoundingBox2I other) => 
            ((this.Min == other.Min) && (this.Max == other.Max));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is BoundingBox2I)
            {
                flag = this.Equals((BoundingBox2I) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (this.Min.GetHashCode() + this.Max.GetHashCode());

        public override string ToString() => 
            $"Min:{this.Min} Max:{this.Max}";

        public static BoundingBox2I CreateMerged(BoundingBox2I original, BoundingBox2I additional)
        {
            BoundingBox2I boxi;
            Vector2I.Min(ref original.Min, ref additional.Min, out boxi.Min);
            Vector2I.Max(ref original.Max, ref additional.Max, out boxi.Max);
            return boxi;
        }

        public static void CreateMerged(ref BoundingBox2I original, ref BoundingBox2I additional, out BoundingBox2I result)
        {
            Vector2I vectori;
            Vector2I vectori2;
            Vector2I.Min(ref original.Min, ref additional.Min, out vectori);
            Vector2I.Max(ref original.Max, ref additional.Max, out vectori2);
            result.Min = vectori;
            result.Max = vectori2;
        }

        public static BoundingBox2I CreateFromPoints(IEnumerable<Vector2I> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException();
            }
            bool flag = false;
            Vector2I vectori = new Vector2I(0x7fffffff);
            Vector2I vectori2 = new Vector2I(-2147483648);
            foreach (Vector2I vectori3 in points)
            {
                Vector2I vectori4 = vectori3;
                Vector2I.Min(ref vectori, ref vectori4, out vectori);
                Vector2I.Max(ref vectori2, ref vectori4, out vectori2);
                flag = true;
            }
            if (!flag)
            {
                throw new ArgumentException();
            }
            return new BoundingBox2I(vectori, vectori2);
        }

        public static BoundingBox2I CreateFromHalfExtent(Vector2I center, int halfExtent) => 
            CreateFromHalfExtent(center, new Vector2I(halfExtent));

        public static BoundingBox2I CreateFromHalfExtent(Vector2I center, Vector2I halfExtent) => 
            new BoundingBox2I(center - halfExtent, center + halfExtent);

        public BoundingBox2I Intersect(BoundingBox2I box)
        {
            BoundingBox2I boxi;
            boxi.Min.X = Math.Max(this.Min.X, box.Min.X);
            boxi.Min.Y = Math.Max(this.Min.Y, box.Min.Y);
            boxi.Max.X = Math.Min(this.Max.X, box.Max.X);
            boxi.Max.Y = Math.Min(this.Max.Y, box.Max.Y);
            return boxi;
        }

        public bool Intersects(BoundingBox2I box) => 
            this.Intersects(ref box);

        public bool Intersects(ref BoundingBox2I box)
        {
            if ((this.Max.X < box.Min.X) || (this.Min.X > box.Max.X))
            {
                return false;
            }
            return ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y));
        }

        public void Intersects(ref BoundingBox2I box, out bool result)
        {
            result = false;
            if (((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X)) && ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y)))
            {
                result = true;
            }
        }

        public Vector2I Center =>
            ((this.Min + this.Max) / 2);
        public Vector2I HalfExtents =>
            ((this.Max - this.Min) / 2);
        public Vector2I Extents =>
            (this.Max - this.Min);
        public float Width =>
            ((float) (this.Max.X - this.Min.X));
        public float Height =>
            ((float) (this.Max.Y - this.Min.Y));
        public ContainmentType Contains(BoundingBox2I box)
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

        public void Contains(ref BoundingBox2I box, out ContainmentType result)
        {
            result = ContainmentType.Disjoint;
            if (((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X)) && ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y)))
            {
                result = (((this.Min.X > box.Min.X) || (box.Max.X > this.Max.X)) || ((this.Min.Y > box.Min.Y) || (box.Max.Y > this.Max.Y))) ? ContainmentType.Intersects : ContainmentType.Contains;
            }
        }

        public ContainmentType Contains(Vector2I point)
        {
            if (((this.Min.X <= point.X) && (point.X <= this.Max.X)) && ((this.Min.Y <= point.Y) && (point.Y <= this.Max.Y)))
            {
                return ContainmentType.Contains;
            }
            return ContainmentType.Disjoint;
        }

        public void Contains(ref Vector2I point, out ContainmentType result)
        {
            result = (((this.Min.X > point.X) || (point.X > this.Max.X)) || ((this.Min.Y > point.Y) || (point.Y > this.Max.Y))) ? ContainmentType.Disjoint : ContainmentType.Contains;
        }

        internal void SupportMapping(ref Vector2I v, out Vector2I result)
        {
            result.X = (v.X >= 0.0) ? this.Max.X : this.Min.X;
            result.Y = (v.Y >= 0.0) ? this.Max.Y : this.Min.Y;
        }

        public BoundingBox2I Translate(Vector2I vctTranlsation)
        {
            this.Min += vctTranlsation;
            this.Max += vctTranlsation;
            return this;
        }

        public Vector2I Size =>
            (this.Max - this.Min);
        public BoundingBox2I Include(ref Vector2I point)
        {
            this.Min.X = Math.Min(point.X, this.Min.X);
            this.Min.Y = Math.Min(point.Y, this.Min.Y);
            this.Max.X = Math.Max(point.X, this.Max.X);
            this.Max.Y = Math.Max(point.Y, this.Max.Y);
            return this;
        }

        public BoundingBox2I GetIncluded(Vector2I point)
        {
            BoundingBox2I boxi = this;
            boxi.Include(point);
            return boxi;
        }

        public BoundingBox2I Include(Vector2I point) => 
            this.Include(ref point);

        public BoundingBox2I Include(Vector2I p0, Vector2I p1, Vector2I p2) => 
            this.Include(ref p0, ref p1, ref p2);

        public BoundingBox2I Include(ref Vector2I p0, ref Vector2I p1, ref Vector2I p2)
        {
            this.Include(ref p0);
            this.Include(ref p1);
            this.Include(ref p2);
            return this;
        }

        public BoundingBox2I Include(ref BoundingBox2I box)
        {
            this.Min = Vector2I.Min(this.Min, box.Min);
            this.Max = Vector2I.Max(this.Max, box.Max);
            return this;
        }

        public BoundingBox2I Include(BoundingBox2I box) => 
            this.Include(ref box);

        public static BoundingBox2I CreateInvalid()
        {
            BoundingBox2I boxi = new BoundingBox2I();
            Vector2I vectori = new Vector2I(0x7fffffff, 0x7fffffff);
            Vector2I vectori2 = new Vector2I(-2147483648, -2147483648);
            boxi.Min = vectori;
            boxi.Max = vectori2;
            return boxi;
        }

        public float Perimeter()
        {
            Vector2I vectori = this.Max - this.Min;
            return (float) (2 * (vectori.X = vectori.Y));
        }

        public float Area()
        {
            Vector2I vectori = this.Max - this.Min;
            return (float) (vectori.X * vectori.Y);
        }

        public void Inflate(int size)
        {
            this.Max += new Vector2I(size);
            this.Min -= new Vector2I(size);
        }

        public void InflateToMinimum(Vector2I minimumSize)
        {
            Vector2I center = this.Center;
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
        }

        public void Scale(Vector2I scale)
        {
            Vector2I center = this.Center;
            Vector2I halfExtents = this.HalfExtents;
            halfExtents.X *= scale.X;
            halfExtents.Y *= scale.Y;
            this.Min = center - halfExtents;
            this.Max = center + halfExtents;
        }
    }
}

