namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using Unsharper;

    [Serializable, StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct BoundingBoxD : IEquatable<BoundingBoxD>
    {
        public const int CornerCount = 8;
        [ProtoMember(0x16)]
        public Vector3D Min;
        [ProtoMember(0x1b)]
        public Vector3D Max;
        public static readonly ComparerType Comparer;
        public BoundingBoxD(Vector3D min, Vector3D max)
        {
            this.Min = min;
            this.Max = max;
        }

        public static implicit operator BoundingBoxD(BoundingBoxI box) => 
            new BoundingBoxD((Vector3D) box.Min, (Vector3D) box.Max);

        public static implicit operator BoundingBoxD(BoundingBox box) => 
            new BoundingBoxD(box.Min, box.Max);

        public static bool operator ==(BoundingBoxD a, BoundingBoxD b) => 
            a.Equals(b);

        public static bool operator !=(BoundingBoxD a, BoundingBoxD b)
        {
            if (!(a.Min != b.Min))
            {
                return (a.Max != b.Max);
            }
            return true;
        }

        public static BoundingBoxD operator +(BoundingBoxD a, Vector3D b)
        {
            BoundingBoxD xd;
            xd.Max = a.Max + b;
            xd.Min = a.Min + b;
            return xd;
        }

        public Vector3D[] GetCorners() => 
            new Vector3D[] { new Vector3D(this.Min.X, this.Max.Y, this.Max.Z), new Vector3D(this.Max.X, this.Max.Y, this.Max.Z), new Vector3D(this.Max.X, this.Min.Y, this.Max.Z), new Vector3D(this.Min.X, this.Min.Y, this.Max.Z), new Vector3D(this.Min.X, this.Max.Y, this.Min.Z), new Vector3D(this.Max.X, this.Max.Y, this.Min.Z), new Vector3D(this.Max.X, this.Min.Y, this.Min.Z), new Vector3D(this.Min.X, this.Min.Y, this.Min.Z) };

        public void GetCorners(Vector3D[] corners)
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
        public unsafe void GetCornersUnsafe(Vector3D* corners)
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

        public bool Equals(BoundingBoxD other) => 
            ((this.Min == other.Min) && (this.Max == other.Max));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is BoundingBoxD)
            {
                flag = this.Equals((BoundingBoxD) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (this.Min.GetHashCode() + this.Max.GetHashCode());

        public override string ToString() => 
            string.Format(CultureInfo.CurrentCulture, "{{Min:{0} Max:{1}}}", new object[] { this.Min.ToString(), this.Max.ToString() });

        public static BoundingBoxD CreateMerged(BoundingBoxD original, BoundingBoxD additional)
        {
            BoundingBoxD xd;
            Vector3D.Min(ref original.Min, ref additional.Min, out xd.Min);
            Vector3D.Max(ref original.Max, ref additional.Max, out xd.Max);
            return xd;
        }

        public static void CreateMerged(ref BoundingBoxD original, ref BoundingBoxD additional, out BoundingBoxD result)
        {
            Vector3D vectord;
            Vector3D vectord2;
            Vector3D.Min(ref original.Min, ref additional.Min, out vectord);
            Vector3D.Max(ref original.Max, ref additional.Max, out vectord2);
            result.Min = vectord;
            result.Max = vectord2;
        }

        public static BoundingBoxD CreateFromSphere(BoundingSphereD sphere)
        {
            BoundingBoxD xd;
            xd.Min.X = sphere.Center.X - sphere.Radius;
            xd.Min.Y = sphere.Center.Y - sphere.Radius;
            xd.Min.Z = sphere.Center.Z - sphere.Radius;
            xd.Max.X = sphere.Center.X + sphere.Radius;
            xd.Max.Y = sphere.Center.Y + sphere.Radius;
            xd.Max.Z = sphere.Center.Z + sphere.Radius;
            return xd;
        }

        public static void CreateFromSphere(ref BoundingSphereD sphere, out BoundingBoxD result)
        {
            result.Min.X = sphere.Center.X - sphere.Radius;
            result.Min.Y = sphere.Center.Y - sphere.Radius;
            result.Min.Z = sphere.Center.Z - sphere.Radius;
            result.Max.X = sphere.Center.X + sphere.Radius;
            result.Max.Y = sphere.Center.Y + sphere.Radius;
            result.Max.Z = sphere.Center.Z + sphere.Radius;
        }

        public static BoundingBoxD CreateFromPoints(IEnumerable<Vector3D> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException();
            }
            bool flag = false;
            Vector3D vectord = new Vector3D(double.MaxValue);
            Vector3D vectord2 = new Vector3D(double.MinValue);
            foreach (Vector3D vectord3 in points)
            {
                Vector3D vectord4 = vectord3;
                Vector3D.Min(ref vectord, ref vectord4, out vectord);
                Vector3D.Max(ref vectord2, ref vectord4, out vectord2);
                flag = true;
            }
            if (!flag)
            {
                throw new ArgumentException();
            }
            return new BoundingBoxD(vectord, vectord2);
        }

        public BoundingBoxD Intersect(BoundingBoxD box)
        {
            BoundingBoxD xd;
            xd.Min.X = Math.Max(this.Min.X, box.Min.X);
            xd.Min.Y = Math.Max(this.Min.Y, box.Min.Y);
            xd.Min.Z = Math.Max(this.Min.Z, box.Min.Z);
            xd.Max.X = Math.Min(this.Max.X, box.Max.X);
            xd.Max.Y = Math.Min(this.Max.Y, box.Max.Y);
            xd.Max.Z = Math.Min(this.Max.Z, box.Max.Z);
            return xd;
        }

        public bool Intersects(BoundingBoxD box) => 
            this.Intersects(ref box);

        public bool Intersects(ref BoundingBoxD box)
        {
            if (((this.Max.X < box.Min.X) || (this.Min.X > box.Max.X)) || ((this.Max.Y < box.Min.Y) || (this.Min.Y > box.Max.Y)))
            {
                return false;
            }
            return ((this.Max.Z >= box.Min.Z) && (this.Min.Z <= box.Max.Z));
        }

        public void Intersects(ref BoundingBoxD box, out bool result)
        {
            result = false;
            if ((((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X)) && ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y))) && ((this.Max.Z >= box.Min.Z) && (this.Min.Z <= box.Max.Z)))
            {
                result = true;
            }
        }

        public void Intersects(ref BoundingBox box, out bool result)
        {
            result = false;
            if ((((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X)) && ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y))) && ((this.Max.Z >= box.Min.Z) && (this.Min.Z <= box.Max.Z)))
            {
                result = true;
            }
        }

        public bool IntersectsTriangle(Vector3D v0, Vector3D v1, Vector3D v2) => 
            this.IntersectsTriangle(ref v0, ref v1, ref v2);

        public bool IntersectsTriangle(ref Vector3D v0, ref Vector3D v1, ref Vector3D v2)
        {
            Vector3D vectord;
            Vector3D vectord2;
            Vector3D vectord5;
            double num;
            PlaneIntersectionType type;
            Vector3D.Min(ref v0, ref v1, out vectord);
            Vector3D.Min(ref vectord, ref v2, out vectord);
            Vector3D.Max(ref v0, ref v1, out vectord2);
            Vector3D.Max(ref vectord2, ref v2, out vectord2);
            if (vectord.X > this.Max.X)
            {
                return false;
            }
            if (vectord2.X < this.Min.X)
            {
                return false;
            }
            if (vectord.Y > this.Max.Y)
            {
                return false;
            }
            if (vectord2.Y < this.Min.Y)
            {
                return false;
            }
            if (vectord.Z > this.Max.Z)
            {
                return false;
            }
            if (vectord2.Z < this.Min.Z)
            {
                return false;
            }
            Vector3D vectord3 = v1 - v0;
            Vector3D vectord4 = v2 - v1;
            Vector3D.Cross(ref vectord3, ref vectord4, out vectord5);
            Vector3D.Dot(ref v0, ref vectord5, out num);
            PlaneD plane = new PlaneD(vectord5, -num);
            this.Intersects(ref plane, out type);
            switch (type)
            {
                case PlaneIntersectionType.Back:
                    return false;

                case PlaneIntersectionType.Front:
                    return false;
            }
            Vector3D center = this.Center;
            BoundingBoxD xd = new BoundingBoxD(this.Min - center, this.Max - center);
            Vector3D halfExtents = xd.HalfExtents;
            Vector3D vectord8 = v0 - v2;
            Vector3D vectord9 = v0 - center;
            Vector3D vectord10 = v1 - center;
            Vector3D vectord11 = v2 - center;
            double num2 = (halfExtents.Y * Math.Abs(vectord3.Z)) + (halfExtents.Z * Math.Abs(vectord3.Y));
            double num3 = (vectord9.Z * vectord10.Y) - (vectord9.Y * vectord10.Z);
            double num5 = (vectord11.Z * vectord3.Y) - (vectord11.Y * vectord3.Z);
            if ((Math.Min(num3, num5) > num2) || (Math.Max(num3, num5) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectord3.Z)) + (halfExtents.Z * Math.Abs(vectord3.X));
            num3 = (vectord9.X * vectord10.Z) - (vectord9.Z * vectord10.X);
            num5 = (vectord11.X * vectord3.Z) - (vectord11.Z * vectord3.X);
            if ((Math.Min(num3, num5) > num2) || (Math.Max(num3, num5) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectord3.Y)) + (halfExtents.Y * Math.Abs(vectord3.X));
            num3 = (vectord9.Y * vectord10.X) - (vectord9.X * vectord10.Y);
            num5 = (vectord11.Y * vectord3.X) - (vectord11.X * vectord3.Y);
            if ((Math.Min(num3, num5) > num2) || (Math.Max(num3, num5) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.Y * Math.Abs(vectord4.Z)) + (halfExtents.Z * Math.Abs(vectord4.Y));
            double num4 = (vectord10.Z * vectord11.Y) - (vectord10.Y * vectord11.Z);
            num3 = (vectord9.Z * vectord4.Y) - (vectord9.Y * vectord4.Z);
            if ((Math.Min(num4, num3) > num2) || (Math.Max(num4, num3) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectord4.Z)) + (halfExtents.Z * Math.Abs(vectord4.X));
            num4 = (vectord10.X * vectord11.Z) - (vectord10.Z * vectord11.X);
            num3 = (vectord9.X * vectord4.Z) - (vectord9.Z * vectord4.X);
            if ((Math.Min(num4, num3) > num2) || (Math.Max(num4, num3) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectord4.Y)) + (halfExtents.Y * Math.Abs(vectord4.X));
            num4 = (vectord10.Y * vectord11.X) - (vectord10.X * vectord11.Y);
            num3 = (vectord9.Y * vectord4.X) - (vectord9.X * vectord4.Y);
            if ((Math.Min(num4, num3) > num2) || (Math.Max(num4, num3) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.Y * Math.Abs(vectord8.Z)) + (halfExtents.Z * Math.Abs(vectord8.Y));
            num5 = (vectord11.Z * vectord9.Y) - (vectord11.Y * vectord9.Z);
            num4 = (vectord10.Z * vectord8.Y) - (vectord10.Y * vectord8.Z);
            if ((Math.Min(num5, num4) > num2) || (Math.Max(num5, num4) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectord8.Z)) + (halfExtents.Z * Math.Abs(vectord8.X));
            num5 = (vectord11.X * vectord9.Z) - (vectord11.Z * vectord9.X);
            num4 = (vectord10.X * vectord8.Z) - (vectord10.Z * vectord8.X);
            if ((Math.Min(num5, num4) > num2) || (Math.Max(num5, num4) < -num2))
            {
                return false;
            }
            num2 = (halfExtents.X * Math.Abs(vectord8.Y)) + (halfExtents.Y * Math.Abs(vectord8.X));
            num5 = (vectord11.Y * vectord9.X) - (vectord11.X * vectord9.Y);
            num4 = (vectord10.Y * vectord8.X) - (vectord10.X * vectord8.Y);
            return ((Math.Min(num5, num4) <= num2) && (Math.Max(num5, num4) >= -num2));
        }

        public Vector3D Center =>
            ((Vector3D) ((this.Min + this.Max) * 0.5));
        public Vector3D HalfExtents =>
            ((Vector3D) ((this.Max - this.Min) * 0.5));
        public Vector3D Extents =>
            (this.Max - this.Min);
        public bool Intersects(BoundingFrustumD frustum) => 
            frustum?.Intersects(this);

        public PlaneIntersectionType Intersects(PlaneD plane)
        {
            Vector3D vectord;
            Vector3D vectord2;
            vectord.X = (plane.Normal.X >= 0.0) ? this.Min.X : this.Max.X;
            vectord.Y = (plane.Normal.Y >= 0.0) ? this.Min.Y : this.Max.Y;
            vectord.Z = (plane.Normal.Z >= 0.0) ? this.Min.Z : this.Max.Z;
            if (((((plane.Normal.X * vectord.X) + (plane.Normal.Y * vectord.Y)) + (plane.Normal.Z * vectord.Z)) + plane.D) > 0.0)
            {
                return PlaneIntersectionType.Front;
            }
            vectord2.X = (plane.Normal.X >= 0.0) ? this.Max.X : this.Min.X;
            vectord2.Y = (plane.Normal.Y >= 0.0) ? this.Max.Y : this.Min.Y;
            vectord2.Z = (plane.Normal.Z >= 0.0) ? this.Max.Z : this.Min.Z;
            if (((((plane.Normal.X * vectord2.X) + (plane.Normal.Y * vectord2.Y)) + (plane.Normal.Z * vectord2.Z)) + plane.D) >= 0.0)
            {
                return PlaneIntersectionType.Intersecting;
            }
            return PlaneIntersectionType.Back;
        }

        public void Intersects(ref PlaneD plane, out PlaneIntersectionType result)
        {
            Vector3D vectord;
            Vector3D vectord2;
            vectord.X = (plane.Normal.X >= 0.0) ? this.Min.X : this.Max.X;
            vectord.Y = (plane.Normal.Y >= 0.0) ? this.Min.Y : this.Max.Y;
            vectord.Z = (plane.Normal.Z >= 0.0) ? this.Min.Z : this.Max.Z;
            vectord2.X = (plane.Normal.X >= 0.0) ? this.Max.X : this.Min.X;
            vectord2.Y = (plane.Normal.Y >= 0.0) ? this.Max.Y : this.Min.Y;
            vectord2.Z = (plane.Normal.Z >= 0.0) ? this.Max.Z : this.Min.Z;
            if (((((plane.Normal.X * vectord.X) + (plane.Normal.Y * vectord.Y)) + (plane.Normal.Z * vectord.Z)) + plane.D) > 0.0)
            {
                result = PlaneIntersectionType.Front;
            }
            else if (((((plane.Normal.X * vectord2.X) + (plane.Normal.Y * vectord2.Y)) + (plane.Normal.Z * vectord2.Z)) + plane.D) < 0.0)
            {
                result = PlaneIntersectionType.Back;
            }
            else
            {
                result = PlaneIntersectionType.Intersecting;
            }
        }

        public bool Intersects(ref LineD line)
        {
            double? nullable = this.Intersects(new RayD(line.From, line.Direction));
            if (!nullable.HasValue)
            {
                return false;
            }
            if (nullable.Value < 0.0)
            {
                return false;
            }
            if (nullable.Value > line.Length)
            {
                return false;
            }
            return true;
        }

        public bool Intersects(ref LineD line, out double distance)
        {
            distance = 0.0;
            double? nullable = this.Intersects(new RayD(line.From, line.Direction));
            if (!nullable.HasValue)
            {
                return false;
            }
            if (nullable.Value < 0.0)
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

        public double? Intersects(Ray ray)
        {
            RayD yd = new RayD(ray.Position, ray.Direction);
            return this.Intersects(yd);
        }

        public double? Intersects(RayD ray)
        {
            double num = 0.0;
            double maxValue = double.MaxValue;
            if (Math.Abs(ray.Direction.X) < 9.99999997475243E-07)
            {
                if ((ray.Position.X < this.Min.X) || (ray.Position.X > this.Max.X))
                {
                    return null;
                }
            }
            else
            {
                double num3 = 1.0 / ray.Direction.X;
                double num4 = (this.Min.X - ray.Position.X) * num3;
                double num5 = (this.Max.X - ray.Position.X) * num3;
                if (num4 > num5)
                {
                    double num6 = num4;
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
                double num7 = 1.0 / ray.Direction.Y;
                double num8 = (this.Min.Y - ray.Position.Y) * num7;
                double num9 = (this.Max.Y - ray.Position.Y) * num7;
                if (num8 > num9)
                {
                    double num10 = num8;
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
                double num11 = 1.0 / ray.Direction.Z;
                double num12 = (this.Min.Z - ray.Position.Z) * num11;
                double num13 = (this.Max.Z - ray.Position.Z) * num11;
                if (num12 > num13)
                {
                    double num14 = num12;
                    num12 = num13;
                    num13 = num14;
                }
                num = MathHelper.Max(num12, num);
                double num15 = MathHelper.Min(num13, maxValue);
                if (num > num15)
                {
                    return null;
                }
            }
            return new double?(num);
        }

        public void Intersects(ref RayD ray, out double? result)
        {
            result = 0;
            double num = 0.0;
            double maxValue = double.MaxValue;
            if (Math.Abs(ray.Direction.X) < 9.99999997475243E-07)
            {
                if ((ray.Position.X < this.Min.X) || (ray.Position.X > this.Max.X))
                {
                    return;
                }
            }
            else
            {
                double num3 = 1.0 / ray.Direction.X;
                double num4 = (this.Min.X - ray.Position.X) * num3;
                double num5 = (this.Max.X - ray.Position.X) * num3;
                if (num4 > num5)
                {
                    double num6 = num4;
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
                double num7 = 1.0 / ray.Direction.Y;
                double num8 = (this.Min.Y - ray.Position.Y) * num7;
                double num9 = (this.Max.Y - ray.Position.Y) * num7;
                if (num8 > num9)
                {
                    double num10 = num8;
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
                double num11 = 1.0 / ray.Direction.Z;
                double num12 = (this.Min.Z - ray.Position.Z) * num11;
                double num13 = (this.Max.Z - ray.Position.Z) * num11;
                if (num12 > num13)
                {
                    double num14 = num12;
                    num12 = num13;
                    num13 = num14;
                }
                num = MathHelper.Max(num12, num);
                double num15 = MathHelper.Min(num13, maxValue);
                if (num > num15)
                {
                    return;
                }
            }
            result = new double?(num);
        }

        public bool Intersect(ref LineD line, out LineD intersectedLine)
        {
            double num;
            double num2;
            RayD ray = new RayD(line.From, line.Direction);
            if (!this.Intersect(ref ray, out num, out num2))
            {
                intersectedLine = line;
                return false;
            }
            num = Math.Max(num, 0.0);
            num2 = Math.Min(num2, line.Length);
            intersectedLine.From = line.From + ((Vector3D) (line.Direction * num));
            intersectedLine.To = line.From + ((Vector3D) (line.Direction * num2));
            intersectedLine.Direction = line.Direction;
            intersectedLine.Length = num2 - num;
            return true;
        }

        public bool Intersect(ref LineD line, out double t1, out double t2)
        {
            RayD ray = new RayD(line.From, line.Direction);
            return this.Intersect(ref ray, out t1, out t2);
        }

        public bool Intersect(ref RayD ray, out double tmin, out double tmax)
        {
            double num = 1.0 / ray.Direction.X;
            double num2 = 1.0 / ray.Direction.Y;
            double num3 = 1.0 / ray.Direction.Z;
            double num4 = (this.Min.X - ray.Position.X) * num;
            double num5 = (this.Max.X - ray.Position.X) * num;
            double num6 = (this.Min.Y - ray.Position.Y) * num2;
            double num7 = (this.Max.Y - ray.Position.Y) * num2;
            double num8 = (this.Min.Z - ray.Position.Z) * num3;
            double num9 = (this.Max.Z - ray.Position.Z) * num3;
            tmin = Math.Max(Math.Max(Math.Min(num4, num5), Math.Min(num6, num7)), Math.Min(num8, num9));
            tmax = Math.Min(Math.Min(Math.Max(num4, num5), Math.Max(num6, num7)), Math.Max(num8, num9));
            if (tmax < 0.0)
            {
                return false;
            }
            if (tmin > tmax)
            {
                return false;
            }
            return true;
        }

        public bool Intersects(BoundingSphereD sphere) => 
            this.Intersects(ref sphere);

        public void Intersects(ref BoundingSphereD sphere, out bool result)
        {
            Vector3D vectord;
            double num;
            Vector3D.Clamp(ref sphere.Center, ref this.Min, ref this.Max, out vectord);
            Vector3D.DistanceSquared(ref sphere.Center, ref vectord, out num);
            result = num <= (sphere.Radius * sphere.Radius);
        }

        public bool Intersects(ref BoundingSphereD sphere)
        {
            Vector3D vectord;
            double num;
            Vector3D.Clamp(ref sphere.Center, ref this.Min, ref this.Max, out vectord);
            Vector3D.DistanceSquared(ref sphere.Center, ref vectord, out num);
            return (num <= (sphere.Radius * sphere.Radius));
        }

        public double Distance(Vector3D point)
        {
            if (this.Contains(point) == ContainmentType.Contains)
            {
                return 0.0;
            }
            return Vector3D.Distance(Vector3D.Clamp(point, this.Min, this.Max), point);
        }

        public double DistanceSquared(Vector3D point)
        {
            if (this.Contains(point) == ContainmentType.Contains)
            {
                return 0.0;
            }
            return Vector3D.DistanceSquared(Vector3D.Clamp(point, this.Min, this.Max), point);
        }

        public ContainmentType Contains(BoundingBoxD box)
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

        public void Contains(ref BoundingBoxD box, out ContainmentType result)
        {
            result = ContainmentType.Disjoint;
            if ((((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X)) && ((this.Max.Y >= box.Min.Y) && (this.Min.Y <= box.Max.Y))) && ((this.Max.Z >= box.Min.Z) && (this.Min.Z <= box.Max.Z)))
            {
                result = ((((this.Min.X > box.Min.X) || (box.Max.X > this.Max.X)) || ((this.Min.Y > box.Min.Y) || (box.Max.Y > this.Max.Y))) || ((this.Min.Z > box.Min.Z) || (box.Max.Z > this.Max.Z))) ? ContainmentType.Intersects : ContainmentType.Contains;
            }
        }

        public ContainmentType Contains(BoundingFrustumD frustum)
        {
            if (!frustum.Intersects(this))
            {
                return ContainmentType.Disjoint;
            }
            foreach (Vector3D vectord in frustum.cornerArray)
            {
                if (this.Contains(vectord) == ContainmentType.Disjoint)
                {
                    return ContainmentType.Intersects;
                }
            }
            return ContainmentType.Contains;
        }

        public ContainmentType Contains(Vector3D point)
        {
            if ((((this.Min.X <= point.X) && (point.X <= this.Max.X)) && ((this.Min.Y <= point.Y) && (point.Y <= this.Max.Y))) && ((this.Min.Z <= point.Z) && (point.Z <= this.Max.Z)))
            {
                return ContainmentType.Contains;
            }
            return ContainmentType.Disjoint;
        }

        public void Contains(ref Vector3D point, out ContainmentType result)
        {
            result = ((((this.Min.X > point.X) || (point.X > this.Max.X)) || ((this.Min.Y > point.Y) || (point.Y > this.Max.Y))) || ((this.Min.Z > point.Z) || (point.Z > this.Max.Z))) ? ContainmentType.Disjoint : ContainmentType.Contains;
        }

        public ContainmentType Contains(BoundingSphereD sphere)
        {
            Vector3D vectord;
            double num;
            Vector3D.Clamp(ref sphere.Center, ref this.Min, ref this.Max, out vectord);
            Vector3D.DistanceSquared(ref sphere.Center, ref vectord, out num);
            double radius = sphere.Radius;
            if (num > (radius * radius))
            {
                return ContainmentType.Disjoint;
            }
            if ((((((this.Min.X + radius) <= sphere.Center.X) && (sphere.Center.X <= (this.Max.X - radius))) && (((this.Max.X - this.Min.X) > radius) && ((this.Min.Y + radius) <= sphere.Center.Y))) && (((sphere.Center.Y <= (this.Max.Y - radius)) && ((this.Max.Y - this.Min.Y) > radius)) && (((this.Min.Z + radius) <= sphere.Center.Z) && (sphere.Center.Z <= (this.Max.Z - radius))))) && ((this.Max.X - this.Min.X) > radius))
            {
                return ContainmentType.Contains;
            }
            return ContainmentType.Intersects;
        }

        public void Contains(ref BoundingSphereD sphere, out ContainmentType result)
        {
            Vector3D vectord;
            double num;
            Vector3D.Clamp(ref sphere.Center, ref this.Min, ref this.Max, out vectord);
            Vector3D.DistanceSquared(ref sphere.Center, ref vectord, out num);
            double radius = sphere.Radius;
            if (num > (radius * radius))
            {
                result = ContainmentType.Disjoint;
            }
            else
            {
                result = ((((((this.Min.X + radius) > sphere.Center.X) || (sphere.Center.X > (this.Max.X - radius))) || (((this.Max.X - this.Min.X) <= radius) || ((this.Min.Y + radius) > sphere.Center.Y))) || (((sphere.Center.Y > (this.Max.Y - radius)) || ((this.Max.Y - this.Min.Y) <= radius)) || (((this.Min.Z + radius) > sphere.Center.Z) || (sphere.Center.Z > (this.Max.Z - radius))))) || ((this.Max.X - this.Min.X) <= radius)) ? ContainmentType.Intersects : ContainmentType.Contains;
            }
        }

        internal void SupportMapping(ref Vector3D v, out Vector3D result)
        {
            result.X = (v.X >= 0.0) ? this.Max.X : this.Min.X;
            result.Y = (v.Y >= 0.0) ? this.Max.Y : this.Min.Y;
            result.Z = (v.Z >= 0.0) ? this.Max.Z : this.Min.Z;
        }

        public BoundingBoxD Translate(MatrixD worldMatrix)
        {
            this.Min += worldMatrix.Translation;
            this.Max += worldMatrix.Translation;
            return this;
        }

        public BoundingBoxD Translate(Vector3D vctTranlsation)
        {
            this.Min += vctTranlsation;
            this.Max += vctTranlsation;
            return this;
        }

        public Vector3D Size =>
            (this.Max - this.Min);
        public MatrixD Matrix
        {
            get
            {
                MatrixD xd;
                Vector3D center = this.Center;
                Vector3D size = this.Size;
                MatrixD.CreateTranslation(ref center, out xd);
                MatrixD.Rescale(ref xd, ref size);
                return xd;
            }
        }
        public BoundingBoxD TransformSlow(MatrixD m) => 
            this.TransformSlow(ref m);

        public unsafe BoundingBoxD TransformSlow(ref MatrixD worldMatrix)
        {
            BoundingBoxD xd = CreateInvalid();
            Vector3D* corners = (Vector3D*) stackalloc byte[(((IntPtr) 8) * sizeof(Vector3D))];
            this.GetCornersUnsafe(corners);
            for (int i = 0; i < 8; i++)
            {
                Vector3D point = Vector3D.Transform(corners[i], (MatrixD) worldMatrix);
                xd = xd.Include(ref point);
            }
            return xd;
        }

        public BoundingBoxD TransformFast(MatrixD m)
        {
            BoundingBoxD bb = CreateInvalid();
            this.TransformFast(ref m, ref bb);
            return bb;
        }

        public BoundingBoxD TransformFast(ref MatrixD m)
        {
            BoundingBoxD bb = CreateInvalid();
            this.TransformFast(ref m, ref bb);
            return bb;
        }

        public void TransformFast(ref MatrixD m, ref BoundingBoxD bb)
        {
            bb.Min = bb.Max = m.Translation;
            Vector3D min = (Vector3D) (m.Right * this.Min.X);
            Vector3D max = (Vector3D) (m.Right * this.Max.X);
            Vector3D.MinMax(ref min, ref max);
            bb.Min += min;
            bb.Max += max;
            min = (Vector3D) (m.Up * this.Min.Y);
            max = (Vector3D) (m.Up * this.Max.Y);
            Vector3D.MinMax(ref min, ref max);
            bb.Min += min;
            bb.Max += max;
            min = (Vector3D) (m.Backward * this.Min.Z);
            max = (Vector3D) (m.Backward * this.Max.Z);
            Vector3D.MinMax(ref min, ref max);
            bb.Min += min;
            bb.Max += max;
        }

        public BoundingBoxD Include(ref Vector3D point)
        {
            this.Min.X = Math.Min(point.X, this.Min.X);
            this.Min.Y = Math.Min(point.Y, this.Min.Y);
            this.Min.Z = Math.Min(point.Z, this.Min.Z);
            this.Max.X = Math.Max(point.X, this.Max.X);
            this.Max.Y = Math.Max(point.Y, this.Max.Y);
            this.Max.Z = Math.Max(point.Z, this.Max.Z);
            return this;
        }

        public BoundingBoxD Include(Vector3D point) => 
            this.Include(ref point);

        public BoundingBoxD Include(Vector3D p0, Vector3D p1, Vector3D p2) => 
            this.Include(ref p0, ref p1, ref p2);

        public BoundingBoxD Include(ref Vector3D p0, ref Vector3D p1, ref Vector3D p2)
        {
            this.Include(ref p0);
            this.Include(ref p1);
            this.Include(ref p2);
            return this;
        }

        public BoundingBoxD Include(ref BoundingBoxD box)
        {
            this.Min = Vector3D.Min(this.Min, box.Min);
            this.Max = Vector3D.Max(this.Max, box.Max);
            return this;
        }

        public BoundingBoxD Include(BoundingBoxD box) => 
            this.Include(ref box);

        public void Include(ref LineD line)
        {
            this.Include(ref line.From);
            this.Include(ref line.To);
        }

        public BoundingBoxD Include(BoundingSphereD sphere) => 
            this.Include(ref sphere);

        public BoundingBoxD Include(ref BoundingSphereD sphere)
        {
            Vector3D vectord = new Vector3D(sphere.Radius);
            Vector3D center = sphere.Center;
            Vector3D vectord3 = sphere.Center;
            Vector3D.Subtract(ref center, ref vectord, out center);
            Vector3D.Add(ref vectord3, ref vectord, out vectord3);
            this.Include(ref center);
            this.Include(ref vectord3);
            return this;
        }

        public unsafe BoundingBoxD Include(ref BoundingFrustumD frustum)
        {
            Vector3D* corners = (Vector3D*) stackalloc byte[(((IntPtr) 8) * sizeof(Vector3D))];
            frustum.GetCornersUnsafe(corners);
            this.Include(ref (ref Vector3D) ((Vector3D) ref corners));
            this.Include(ref (ref Vector3D) ((Vector3D) ref (corners + 1)));
            this.Include(ref (ref Vector3D) ((Vector3D) ref (corners + 2)));
            this.Include(ref (ref Vector3D) ((Vector3D) ref (corners + 3)));
            this.Include(ref (ref Vector3D) ((Vector3D) ref (corners + 4)));
            this.Include(ref (ref Vector3D) ((Vector3D) ref (corners + 5)));
            this.Include(ref (ref Vector3D) ((Vector3D) ref (corners + 6)));
            this.Include(ref (ref Vector3D) ((Vector3D) ref (corners + 7)));
            return this;
        }

        public static BoundingBoxD CreateInvalid() => 
            new BoundingBoxD(new Vector3D(double.MaxValue), new Vector3D(double.MinValue));

        public double SurfaceArea
        {
            get
            {
                Vector3D vectord = this.Max - this.Min;
                return (2.0 * (((vectord.X * vectord.Y) + (vectord.X * vectord.Z)) + (vectord.Y * vectord.Z)));
            }
        }
        public double Volume
        {
            get
            {
                Vector3D vectord = this.Max - this.Min;
                return ((vectord.X * vectord.Y) * vectord.Z);
            }
        }
        public double ProjectedArea(Vector3D viewDir)
        {
            Vector3D vectord = this.Max - this.Min;
            Vector3D v = new Vector3D(vectord.Y, vectord.Z, vectord.X) * new Vector3D(vectord.Z, vectord.X, vectord.Y);
            return Vector3D.Abs(viewDir).Dot(v);
        }

        public double Perimeter
        {
            get
            {
                double num = this.Max.X - this.Min.X;
                double num2 = this.Max.Y - this.Min.Y;
                double num3 = this.Max.Z - this.Min.Z;
                return (4.0 * ((num + num2) + num3));
            }
        }
        public bool Valid =>
            ((this.Min != new Vector3D(double.MaxValue)) && (this.Max != new Vector3D(double.MinValue)));
        public BoundingBoxD Inflate(double size)
        {
            this.Max += new Vector3D(size);
            this.Min -= new Vector3D(size);
            return this;
        }

        public BoundingBoxD Inflate(Vector3 size)
        {
            this.Max += size;
            this.Min -= size;
            return this;
        }

        public BoundingBoxD GetInflated(double size)
        {
            BoundingBoxD xd = this;
            xd.Inflate(size);
            return xd;
        }

        public BoundingBoxD GetInflated(Vector3 size)
        {
            BoundingBoxD xd = this;
            xd.Inflate(size);
            return xd;
        }

        public static explicit operator BoundingBox(BoundingBoxD b) => 
            new BoundingBox((Vector3) b.Min, (Vector3) b.Max);

        public void InflateToMinimum(Vector3D minimumSize)
        {
            Vector3D center = this.Center;
            if (this.Size.X < minimumSize.X)
            {
                this.Min.X = center.X - (minimumSize.X * 0.5);
                this.Max.X = center.X + (minimumSize.X * 0.5);
            }
            if (this.Size.Y < minimumSize.Y)
            {
                this.Min.Y = center.Y - (minimumSize.Y * 0.5);
                this.Max.Y = center.Y + (minimumSize.Y * 0.5);
            }
            if (this.Size.Z < minimumSize.Z)
            {
                this.Min.Z = center.Z - (minimumSize.Z * 0.5);
                this.Max.Z = center.Z + (minimumSize.Z * 0.5);
            }
        }

        public void InflateToMinimum(double minimumSize)
        {
            Vector3D center = this.Center;
            if (this.Size.X < minimumSize)
            {
                this.Min.X = center.X - (minimumSize * 0.5);
                this.Max.X = center.X + (minimumSize * 0.5);
            }
            if (this.Size.Y < minimumSize)
            {
                this.Min.Y = center.Y - (minimumSize * 0.5);
                this.Max.Y = center.Y + (minimumSize * 0.5);
            }
            if (this.Size.Z < minimumSize)
            {
                this.Min.Z = center.Z - (minimumSize * 0.5);
                this.Max.Z = center.Z + (minimumSize * 0.5);
            }
        }

        [Conditional("DEBUG")]
        public void AssertIsValid()
        {
        }

        static BoundingBoxD()
        {
            Comparer = new ComparerType();
        }
        public class ComparerType : IEqualityComparer<BoundingBox>
        {
            public bool Equals(BoundingBox x, BoundingBox y) => 
                ((x.Min == y.Min) && (x.Max == y.Max));

            public int GetHashCode(BoundingBox obj) => 
                (obj.Min.GetHashCode() ^ obj.Max.GetHashCode());
        }
    }
}

