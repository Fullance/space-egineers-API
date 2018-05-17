namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct BoundingBox2D : IEquatable<BoundingBox2D>
    {
        public const int CornerCount = 8;
        [ProtoMember(20)]
        public Vector2D Min;
        [ProtoMember(0x19)]
        public Vector2D Max;
        public BoundingBox2D(Vector2D min, Vector2D max)
        {
            this.Min = min;
            this.Max = max;
        }

        public static bool operator ==(BoundingBox2D a, BoundingBox2D b) => 
            a.Equals(b);

        public static bool operator !=(BoundingBox2D a, BoundingBox2D b)
        {
            if (!(a.Min != b.Min))
            {
                return (a.Max != b.Max);
            }
            return true;
        }

        public Vector2D[] GetCorners() => 
            new Vector2D[] { new Vector2D(this.Min.X, this.Max.Y), new Vector2D(this.Max.X, this.Max.Y), new Vector2D(this.Max.X, this.Min.Y), new Vector2D(this.Min.X, this.Min.Y), new Vector2D(this.Min.X, this.Max.Y), new Vector2D(this.Max.X, this.Max.Y), new Vector2D(this.Max.X, this.Min.Y), new Vector2D(this.Min.X, this.Min.Y) };

        public void GetCorners(Vector2D[] corners)
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

        public unsafe void GetCornersUnsafe(Vector2D* corners)
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

        public bool Equals(BoundingBox2D other) => 
            ((this.Min == other.Min) && (this.Max == other.Max));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is BoundingBox2D)
            {
                flag = this.Equals((BoundingBox2D) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (this.Min.GetHashCode() + this.Max.GetHashCode());

        public override string ToString() => 
            $"Min:{this.Min} Max:{this.Max}";

        public static BoundingBox2D CreateMerged(BoundingBox2D original, BoundingBox2D additional)
        {
            BoundingBox2D boxd;
            Vector2D.Min(ref original.Min, ref additional.Min, out boxd.Min);
            Vector2D.Max(ref original.Max, ref additional.Max, out boxd.Max);
            return boxd;
        }

        public static void CreateMerged(ref BoundingBox2D original, ref BoundingBox2D additional, out BoundingBox2D result)
        {
            Vector2D vectord;
            Vector2D vectord2;
            Vector2D.Min(ref original.Min, ref additional.Min, out vectord);
            Vector2D.Max(ref original.Max, ref additional.Max, out vectord2);
            result.Min = vectord;
            result.Max = vectord2;
        }

        public static BoundingBox2D CreateFromPoints(IEnumerable<Vector2D> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException();
            }
            bool flag = false;
            Vector2D vectord = new Vector2D(double.MaxValue);
            Vector2D vectord2 = new Vector2D(double.MinValue);
            foreach (Vector2D vectord3 in points)
            {
                Vector2D vectord4 = vectord3;
                Vector2D.Min(ref vectord, ref vectord4, out vectord);
                Vector2D.Max(ref vectord2, ref vectord4, out vectord2);
                flag = true;
            }
            if (!flag)
            {
                throw new ArgumentException();
            }
            return new BoundingBox2D(vectord, vectord2);
        }

        public static BoundingBox2D CreateFromHalfExtent(Vector2D center, double halfExtent) => 
            CreateFromHalfExtent(center, new Vector2D(halfExtent));

        public static BoundingBox2D CreateFromHalfExtent(Vector2D center, Vector2D halfExtent) => 
            new BoundingBox2D(center - halfExtent, center + halfExtent);

        public BoundingBox2D Intersect(BoundingBox2D box)
        {
            BoundingBox2D boxd;
            boxd.Min.X = Math.Max(this.Min.X, box.Min.X);
            boxd.Min.Y = Math.Max(this.Min.Y, box.Min.Y);
            boxd.Max.X = Math.Min(this.Max.X, box.Max.X);
            boxd.Max.Y = Math.Min(this.Max.Y, box.Max.Y);
            return boxd;
        }

        public bool Intersects(BoundingBox2D box) => 
            this.Intersects(ref box);

        public bool Intersects(ref BoundingBox2D box)
        {
            if ((this.Max.X < box.Min.X) || (this.Min.X > box.Max.X))
            {
                return false;
            }
            return ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y));
        }

        public void Intersects(ref BoundingBox2D box, out bool result)
        {
            result = false;
            if (((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X)) && ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y)))
            {
                result = true;
            }
        }

        public Vector2D Center =>
            ((Vector2D) ((this.Min + this.Max) / 2.0));
        public Vector2D HalfExtents =>
            ((Vector2D) ((this.Max - this.Min) / 2.0));
        public Vector2D Extents =>
            (this.Max - this.Min);
        public double Width =>
            (this.Max.X - this.Min.X);
        public double Height =>
            (this.Max.Y - this.Min.Y);
        public double Distance(Vector2D point) => 
            Vector2D.Distance(Vector2D.Clamp(point, this.Min, this.Max), point);

        public ContainmentType Contains(BoundingBox2D box)
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

        public void Contains(ref BoundingBox2D box, out ContainmentType result)
        {
            result = ContainmentType.Disjoint;
            if (((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X)) && ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y)))
            {
                result = (((this.Min.X > box.Min.X) || (box.Max.X > this.Max.X)) || ((this.Min.Y > box.Min.Y) || (box.Max.Y > this.Max.Y))) ? ContainmentType.Intersects : ContainmentType.Contains;
            }
        }

        public ContainmentType Contains(Vector2D point)
        {
            if (((this.Min.X <= point.X) && (point.X <= this.Max.X)) && ((this.Min.Y <= point.Y) && (point.Y <= this.Max.Y)))
            {
                return ContainmentType.Contains;
            }
            return ContainmentType.Disjoint;
        }

        public void Contains(ref Vector2D point, out ContainmentType result)
        {
            result = (((this.Min.X > point.X) || (point.X > this.Max.X)) || ((this.Min.Y > point.Y) || (point.Y > this.Max.Y))) ? ContainmentType.Disjoint : ContainmentType.Contains;
        }

        internal void SupportMapping(ref Vector2D v, out Vector2D result)
        {
            result.X = (v.X >= 0.0) ? this.Max.X : this.Min.X;
            result.Y = (v.Y >= 0.0) ? this.Max.Y : this.Min.Y;
        }

        public BoundingBox2D Translate(Vector2D vctTranlsation)
        {
            this.Min += vctTranlsation;
            this.Max += vctTranlsation;
            return this;
        }

        public Vector2D Size =>
            (this.Max - this.Min);
        public BoundingBox2D Include(ref Vector2D point)
        {
            this.Min.X = Math.Min(point.X, this.Min.X);
            this.Min.Y = Math.Min(point.Y, this.Min.Y);
            this.Max.X = Math.Max(point.X, this.Max.X);
            this.Max.Y = Math.Max(point.Y, this.Max.Y);
            return this;
        }

        public BoundingBox2D GetIncluded(Vector2D point)
        {
            BoundingBox2D boxd = this;
            boxd.Include(point);
            return boxd;
        }

        public BoundingBox2D Include(Vector2D point) => 
            this.Include(ref point);

        public BoundingBox2D Include(Vector2D p0, Vector2D p1, Vector2D p2) => 
            this.Include(ref p0, ref p1, ref p2);

        public BoundingBox2D Include(ref Vector2D p0, ref Vector2D p1, ref Vector2D p2)
        {
            this.Include(ref p0);
            this.Include(ref p1);
            this.Include(ref p2);
            return this;
        }

        public BoundingBox2D Include(ref BoundingBox2D box)
        {
            this.Min = Vector2D.Min(this.Min, box.Min);
            this.Max = Vector2D.Max(this.Max, box.Max);
            return this;
        }

        public BoundingBox2D Include(BoundingBox2D box) => 
            this.Include(ref box);

        public static BoundingBox2D CreateInvalid()
        {
            BoundingBox2D boxd = new BoundingBox2D();
            Vector2D vectord = new Vector2D(double.MaxValue, double.MaxValue);
            Vector2D vectord2 = new Vector2D(double.MinValue, double.MinValue);
            boxd.Min = vectord;
            boxd.Max = vectord2;
            return boxd;
        }

        public double Perimeter()
        {
            Vector2D vectord = this.Max - this.Min;
            return (2.0 * (vectord.X = vectord.Y));
        }

        public double Area()
        {
            Vector2D vectord = this.Max - this.Min;
            return (vectord.X * vectord.Y);
        }

        public void Inflate(double size)
        {
            this.Max += new Vector2D(size);
            this.Min -= new Vector2D(size);
        }

        public void InflateToMinimum(Vector2D minimumSize)
        {
            Vector2D center = this.Center;
            if (this.Size.X < minimumSize.X)
            {
                this.Min.X = center.X - (minimumSize.X / 2.0);
                this.Max.X = center.X + (minimumSize.X / 2.0);
            }
            if (this.Size.Y < minimumSize.Y)
            {
                this.Min.Y = center.Y - (minimumSize.Y / 2.0);
                this.Max.Y = center.Y + (minimumSize.Y / 2.0);
            }
        }

        public void Scale(Vector2D scale)
        {
            Vector2D center = this.Center;
            Vector2D vectord2 = this.HalfExtents * scale;
            this.Min = center - vectord2;
            this.Max = center + vectord2;
        }
    }
}

