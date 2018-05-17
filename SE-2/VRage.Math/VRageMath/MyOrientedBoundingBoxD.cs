namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyOrientedBoundingBoxD : IEquatable<MyOrientedBoundingBox>
    {
        public const int CornerCount = 8;
        private const float RAY_EPSILON = 1E-20f;
        public static readonly int[] StartVertices;
        public static readonly int[] EndVertices;
        public static readonly int[] StartXVertices;
        public static readonly int[] EndXVertices;
        public static readonly int[] StartYVertices;
        public static readonly int[] EndYVertices;
        public static readonly int[] StartZVertices;
        public static readonly int[] EndZVertices;
        public static readonly Vector3[] XNeighbourVectorsBack;
        public static readonly Vector3[] XNeighbourVectorsForw;
        public static readonly Vector3[] YNeighbourVectorsBack;
        public static readonly Vector3[] YNeighbourVectorsForw;
        public static readonly Vector3[] ZNeighbourVectorsBack;
        public static readonly Vector3[] ZNeighbourVectorsForw;
        public Vector3D Center;
        public Vector3D HalfExtent;
        public Quaternion Orientation;
        [ThreadStatic]
        private static Vector3D[] m_cornersTmp;
        public static bool GetNormalBetweenEdges(int axis, int edge0, int edge1, out Vector3 normal)
        {
            Vector3[] xNeighbourVectorsForw = null;
            Vector3[] xNeighbourVectorsBack = null;
            normal = Vector3.Zero;
            switch (axis)
            {
                case 0:
                {
                    int[] startXVertices = StartXVertices;
                    int[] endXVertices = EndXVertices;
                    xNeighbourVectorsForw = XNeighbourVectorsForw;
                    xNeighbourVectorsBack = XNeighbourVectorsBack;
                    break;
                }
                case 1:
                {
                    int[] startYVertices = StartYVertices;
                    int[] endYVertices = EndYVertices;
                    xNeighbourVectorsForw = YNeighbourVectorsForw;
                    xNeighbourVectorsBack = YNeighbourVectorsBack;
                    break;
                }
                case 2:
                {
                    int[] startZVertices = StartZVertices;
                    int[] endZVertices = EndZVertices;
                    xNeighbourVectorsForw = ZNeighbourVectorsForw;
                    xNeighbourVectorsBack = ZNeighbourVectorsBack;
                    break;
                }
                default:
                    return false;
            }
            if (edge0 == -1)
            {
                edge0 = 3;
            }
            if (edge0 == 4)
            {
                edge0 = 0;
            }
            if (edge1 == -1)
            {
                edge1 = 3;
            }
            if (edge1 == 4)
            {
                edge1 = 0;
            }
            if ((edge0 == 3) && (edge1 == 0))
            {
                normal = xNeighbourVectorsForw[3];
                return true;
            }
            if ((edge0 == 0) && (edge1 == 3))
            {
                normal = xNeighbourVectorsBack[3];
                return true;
            }
            if ((edge0 + 1) == edge1)
            {
                normal = xNeighbourVectorsForw[edge0];
                return true;
            }
            if (edge0 == (edge1 + 1))
            {
                normal = xNeighbourVectorsBack[edge1];
                return true;
            }
            return false;
        }

        public MyOrientedBoundingBoxD(MatrixD matrix)
        {
            this.Center = matrix.Translation;
            Vector3D vectord = new Vector3D(matrix.Right.Length(), matrix.Up.Length(), matrix.Forward.Length());
            this.HalfExtent = (Vector3D) (vectord / 2.0);
            matrix.Right = (Vector3D) (matrix.Right / vectord.X);
            matrix.Up = (Vector3D) (matrix.Up / vectord.Y);
            matrix.Forward = (Vector3D) (matrix.Forward / vectord.Z);
            Quaternion.CreateFromRotationMatrix(ref matrix, out this.Orientation);
        }

        public MyOrientedBoundingBoxD(Vector3D center, Vector3D halfExtents, Quaternion orientation)
        {
            this.Center = center;
            this.HalfExtent = halfExtents;
            this.Orientation = orientation;
        }

        public MyOrientedBoundingBoxD(BoundingBoxD box, MatrixD transform)
        {
            this.Center = (Vector3D) ((box.Min + box.Max) * 0.5);
            this.HalfExtent = (Vector3D) ((box.Max - box.Min) * 0.5);
            this.Center = Vector3D.Transform(this.Center, transform);
            this.Orientation = Quaternion.CreateFromRotationMatrix(transform);
        }

        public static MyOrientedBoundingBoxD CreateFromBoundingBox(BoundingBoxD box)
        {
            Vector3 center = (Vector3) ((box.Min + box.Max) * 0.5);
            return new MyOrientedBoundingBoxD(center, (Vector3) ((box.Max - box.Min) * 0.5), Quaternion.Identity);
        }

        public MyOrientedBoundingBoxD Transform(Quaternion rotation, Vector3D translation) => 
            new MyOrientedBoundingBoxD(Vector3D.Transform(this.Center, rotation) + translation, this.HalfExtent, this.Orientation * rotation);

        public MyOrientedBoundingBoxD Transform(float scale, Quaternion rotation, Vector3D translation) => 
            new MyOrientedBoundingBoxD(Vector3.Transform((Vector3) (this.Center * scale), rotation) + translation, (Vector3D) (this.HalfExtent * scale), this.Orientation * rotation);

        public void Transform(MatrixD matrix)
        {
            this.Center = Vector3D.Transform(this.Center, matrix);
            this.Orientation = Quaternion.CreateFromRotationMatrix(MatrixD.CreateFromQuaternion(this.Orientation) * matrix);
        }

        public bool Equals(MyOrientedBoundingBox other) => 
            (((this.Center == other.Center) && (this.HalfExtent == other.HalfExtent)) && (this.Orientation == other.Orientation));

        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is MyOrientedBoundingBox))
            {
                return false;
            }
            MyOrientedBoundingBox box = (MyOrientedBoundingBox) obj;
            return (((this.Center == box.Center) && (this.HalfExtent == box.HalfExtent)) && (this.Orientation == box.Orientation));
        }

        public override int GetHashCode() => 
            ((this.Center.GetHashCode() ^ this.HalfExtent.GetHashCode()) ^ this.Orientation.GetHashCode());

        public static bool operator ==(MyOrientedBoundingBoxD a, MyOrientedBoundingBoxD b) => 
            a.Equals(b);

        public static bool operator !=(MyOrientedBoundingBoxD a, MyOrientedBoundingBoxD b) => 
            !a.Equals(b);

        public override string ToString() => 
            ("{Center:" + this.Center.ToString() + " Extents:" + this.HalfExtent.ToString() + " Orientation:" + this.Orientation.ToString() + "}");

        public bool Intersects(ref BoundingBox box)
        {
            Vector3D vectord = (Vector3D) ((box.Max + box.Min) * 0.5f);
            Vector3D hA = (Vector3D) ((box.Max - box.Min) * 0.5f);
            MatrixD mB = MatrixD.CreateFromQuaternion(this.Orientation);
            mB.Translation = this.Center - vectord;
            return (ContainsRelativeBox(ref hA, ref this.HalfExtent, ref mB) != ContainmentType.Disjoint);
        }

        public bool Intersects(ref BoundingBoxD box)
        {
            Vector3D vectord = (Vector3D) ((box.Max + box.Min) * 0.5);
            Vector3D hA = (Vector3D) ((box.Max - box.Min) * 0.5);
            MatrixD mB = MatrixD.CreateFromQuaternion(this.Orientation);
            mB.Translation = this.Center - vectord;
            return (ContainsRelativeBox(ref hA, ref this.HalfExtent, ref mB) != ContainmentType.Disjoint);
        }

        public ContainmentType Contains(ref BoundingBox box)
        {
            BoundingBoxD xd = box;
            return this.Contains(ref xd);
        }

        public ContainmentType Contains(ref BoundingBoxD box)
        {
            Quaternion quaternion;
            Vector3D vectord = (Vector3D) ((box.Max + box.Min) * 0.5);
            Vector3D hB = (Vector3D) ((box.Max - box.Min) * 0.5);
            Quaternion.Conjugate(ref this.Orientation, out quaternion);
            MatrixD matrix = MatrixD.CreateFromQuaternion(quaternion);
            matrix.Translation = Vector3D.TransformNormal(vectord - this.Center, matrix);
            return ContainsRelativeBox(ref this.HalfExtent, ref hB, ref matrix);
        }

        public static ContainmentType Contains(ref BoundingBox boxA, ref MyOrientedBoundingBox oboxB)
        {
            Vector3 hA = (Vector3) ((boxA.Max - boxA.Min) * 0.5f);
            Vector3 vector2 = (Vector3) ((boxA.Max + boxA.Min) * 0.5f);
            Matrix mB = Matrix.CreateFromQuaternion(oboxB.Orientation);
            mB.Translation = oboxB.Center - vector2;
            return MyOrientedBoundingBox.ContainsRelativeBox(ref hA, ref oboxB.HalfExtent, ref mB);
        }

        public bool Intersects(ref MyOrientedBoundingBoxD other) => 
            (this.Contains(ref other) != ContainmentType.Disjoint);

        public ContainmentType Contains(ref MyOrientedBoundingBoxD other)
        {
            Quaternion quaternion;
            Quaternion quaternion2;
            Quaternion.Conjugate(ref this.Orientation, out quaternion);
            Quaternion.Multiply(ref quaternion, ref other.Orientation, out quaternion2);
            MatrixD mB = MatrixD.CreateFromQuaternion(quaternion2);
            mB.Translation = Vector3D.Transform(other.Center - this.Center, quaternion);
            return ContainsRelativeBox(ref this.HalfExtent, ref other.HalfExtent, ref mB);
        }

        public ContainmentType Contains(BoundingFrustumD frustum) => 
            this.ConvertToFrustum().Contains(frustum);

        public bool Intersects(BoundingFrustumD frustum) => 
            (this.Contains(frustum) != ContainmentType.Disjoint);

        public static ContainmentType Contains(BoundingFrustumD frustum, ref MyOrientedBoundingBoxD obox) => 
            frustum.Contains(obox.ConvertToFrustum());

        public ContainmentType Contains(ref BoundingSphereD sphere)
        {
            Quaternion rotation = Quaternion.Conjugate(this.Orientation);
            Vector3 vector = Vector3.Transform((Vector3) (sphere.Center - this.Center), rotation);
            double num = Math.Abs(vector.X) - this.HalfExtent.X;
            double num2 = Math.Abs(vector.Y) - this.HalfExtent.Y;
            double num3 = Math.Abs(vector.Z) - this.HalfExtent.Z;
            double radius = sphere.Radius;
            if (((num <= -radius) && (num2 <= -radius)) && (num3 <= -radius))
            {
                return ContainmentType.Contains;
            }
            num = Math.Max(num, 0.0);
            num2 = Math.Max(num2, 0.0);
            num3 = Math.Max(num3, 0.0);
            if ((((num * num) + (num2 * num2)) + (num3 * num3)) >= (radius * radius))
            {
                return ContainmentType.Disjoint;
            }
            return ContainmentType.Intersects;
        }

        public bool Intersects(ref BoundingSphereD sphere)
        {
            Quaternion rotation = Quaternion.Conjugate(this.Orientation);
            Vector3 vector = Vector3.Transform((Vector3) (sphere.Center - this.Center), rotation);
            double num = Math.Abs(vector.X) - this.HalfExtent.X;
            double num2 = Math.Abs(vector.Y) - this.HalfExtent.Y;
            double num3 = Math.Abs(vector.Z) - this.HalfExtent.Z;
            num = Math.Max(num, 0.0);
            num2 = Math.Max(num2, 0.0);
            num3 = Math.Max(num3, 0.0);
            double radius = sphere.Radius;
            return ((((num * num) + (num2 * num2)) + (num3 * num3)) < (radius * radius));
        }

        public static ContainmentType Contains(ref BoundingSphere sphere, ref MyOrientedBoundingBox box)
        {
            Quaternion rotation = Quaternion.Conjugate(box.Orientation);
            Vector3 vector = Vector3.Transform(sphere.Center - box.Center, rotation);
            vector.X = Math.Abs(vector.X);
            vector.Y = Math.Abs(vector.Y);
            vector.Z = Math.Abs(vector.Z);
            float num = sphere.Radius * sphere.Radius;
            Vector3 vector3 = vector + box.HalfExtent;
            if (vector3.LengthSquared() <= num)
            {
                return ContainmentType.Contains;
            }
            Vector3 vector2 = vector - box.HalfExtent;
            vector2.X = Math.Max(vector2.X, 0f);
            vector2.Y = Math.Max(vector2.Y, 0f);
            vector2.Z = Math.Max(vector2.Z, 0f);
            if (vector2.LengthSquared() >= num)
            {
                return ContainmentType.Disjoint;
            }
            return ContainmentType.Intersects;
        }

        public bool Contains(ref Vector3 point)
        {
            Quaternion rotation = Quaternion.Conjugate(this.Orientation);
            Vector3 vector = Vector3.Transform(point - this.Center, rotation);
            return (((Math.Abs(vector.X) <= this.HalfExtent.X) && (Math.Abs(vector.Y) <= this.HalfExtent.Y)) && (Math.Abs(vector.Z) <= this.HalfExtent.Z));
        }

        public bool Contains(ref Vector3D point)
        {
            Quaternion rotation = Quaternion.Conjugate(this.Orientation);
            Vector3D vectord = Vector3D.Transform(point - this.Center, rotation);
            return (((Math.Abs(vectord.X) <= this.HalfExtent.X) && (Math.Abs(vectord.Y) <= this.HalfExtent.Y)) && (Math.Abs(vectord.Z) <= this.HalfExtent.Z));
        }

        public double? Intersects(ref RayD ray)
        {
            MatrixD xd = Matrix.CreateFromQuaternion(this.Orientation);
            Vector3D vectord = this.Center - ray.Position;
            double minValue = double.MinValue;
            double maxValue = double.MaxValue;
            double num3 = Vector3D.Dot(xd.Right, vectord);
            double num4 = Vector3D.Dot(xd.Right, ray.Direction);
            if ((num4 >= -9.9999996826552254E-21) && (num4 <= 9.9999996826552254E-21))
            {
                if (((-num3 - this.HalfExtent.X) > 0.0) || ((-num3 + this.HalfExtent.X) < 0.0))
                {
                    return null;
                }
            }
            else
            {
                double num5 = (num3 - this.HalfExtent.X) / num4;
                double num6 = (num3 + this.HalfExtent.X) / num4;
                if (num5 > num6)
                {
                    double num7 = num5;
                    num5 = num6;
                    num6 = num7;
                }
                if (num5 > minValue)
                {
                    minValue = num5;
                }
                if (num6 < maxValue)
                {
                    maxValue = num6;
                }
                if ((maxValue < 0.0) || (minValue > maxValue))
                {
                    return null;
                }
            }
            num3 = Vector3.Dot((Vector3) xd.Up, (Vector3) vectord);
            num4 = Vector3.Dot((Vector3) xd.Up, (Vector3) ray.Direction);
            if ((num4 >= -9.9999996826552254E-21) && (num4 <= 9.9999996826552254E-21))
            {
                if (((-num3 - this.HalfExtent.Y) > 0.0) || ((-num3 + this.HalfExtent.Y) < 0.0))
                {
                    return null;
                }
            }
            else
            {
                double num8 = (num3 - this.HalfExtent.Y) / num4;
                double num9 = (num3 + this.HalfExtent.Y) / num4;
                if (num8 > num9)
                {
                    double num10 = num8;
                    num8 = num9;
                    num9 = num10;
                }
                if (num8 > minValue)
                {
                    minValue = num8;
                }
                if (num9 < maxValue)
                {
                    maxValue = num9;
                }
                if ((maxValue < 0.0) || (minValue > maxValue))
                {
                    return null;
                }
            }
            num3 = Vector3.Dot((Vector3) xd.Forward, (Vector3) vectord);
            num4 = Vector3.Dot((Vector3) xd.Forward, (Vector3) ray.Direction);
            if ((num4 >= -9.9999996826552254E-21) && (num4 <= 9.9999996826552254E-21))
            {
                if (((-num3 - this.HalfExtent.Z) > 0.0) || ((-num3 + this.HalfExtent.Z) < 0.0))
                {
                    return null;
                }
            }
            else
            {
                double num11 = (num3 - this.HalfExtent.Z) / num4;
                double num12 = (num3 + this.HalfExtent.Z) / num4;
                if (num11 > num12)
                {
                    double num13 = num11;
                    num11 = num12;
                    num12 = num13;
                }
                if (num11 > minValue)
                {
                    minValue = num11;
                }
                if (num12 < maxValue)
                {
                    maxValue = num12;
                }
                if ((maxValue < 0.0) || (minValue > maxValue))
                {
                    return null;
                }
            }
            return new double?(minValue);
        }

        public double? Intersects(ref LineD line)
        {
            if (this.Contains(ref line.From))
            {
                RayD yd = new RayD(line.To, -line.Direction);
                double? nullable = this.Intersects(ref yd);
                if (!nullable.HasValue)
                {
                    return null;
                }
                double num = line.Length - nullable.Value;
                if (num < 0.0)
                {
                    return null;
                }
                if (num > line.Length)
                {
                    return null;
                }
                return new double?(num);
            }
            RayD ray = new RayD(line.From, line.Direction);
            double? nullable2 = this.Intersects(ref ray);
            if (!nullable2.HasValue)
            {
                return null;
            }
            if (nullable2.Value < 0.0)
            {
                return null;
            }
            if (nullable2.Value > line.Length)
            {
                return null;
            }
            return new double?(nullable2.Value);
        }

        public PlaneIntersectionType Intersects(ref PlaneD plane)
        {
            double num = plane.DotCoordinate(this.Center);
            Vector3D vectord = Vector3D.Transform(plane.Normal, Quaternion.Conjugate(this.Orientation));
            double introduced3 = Math.Abs((double) (this.HalfExtent.X * vectord.X));
            double num2 = (introduced3 + Math.Abs((double) (this.HalfExtent.Y * vectord.Y))) + Math.Abs((double) (this.HalfExtent.Z * vectord.Z));
            if (num > num2)
            {
                return PlaneIntersectionType.Front;
            }
            if (num < -num2)
            {
                return PlaneIntersectionType.Back;
            }
            return PlaneIntersectionType.Intersecting;
        }

        public void GetCorners(Vector3D[] corners, int startIndex)
        {
            MatrixD xd = MatrixD.CreateFromQuaternion(this.Orientation);
            Vector3D vectord = (Vector3D) (xd.Left * this.HalfExtent.X);
            Vector3D vectord2 = (Vector3D) (xd.Up * this.HalfExtent.Y);
            Vector3D vectord3 = (Vector3D) (xd.Backward * this.HalfExtent.Z);
            int num = startIndex;
            corners[num++] = ((this.Center - vectord) + vectord2) + vectord3;
            corners[num++] = ((this.Center + vectord) + vectord2) + vectord3;
            corners[num++] = ((this.Center + vectord) - vectord2) + vectord3;
            corners[num++] = ((this.Center - vectord) - vectord2) + vectord3;
            corners[num++] = ((this.Center - vectord) + vectord2) - vectord3;
            corners[num++] = ((this.Center + vectord) + vectord2) - vectord3;
            corners[num++] = ((this.Center + vectord) - vectord2) - vectord3;
            corners[num++] = ((this.Center - vectord) - vectord2) - vectord3;
        }

        public static ContainmentType ContainsRelativeBox(ref Vector3D hA, ref Vector3D hB, ref MatrixD mB)
        {
            Vector3D translation = mB.Translation;
            double x = Math.Abs(translation.X);
            double y = Math.Abs(translation.Y);
            Vector3D vectord2 = new Vector3D(x, y, Math.Abs(translation.Z));
            Vector3D right = mB.Right;
            Vector3D up = mB.Up;
            Vector3D backward = mB.Backward;
            Vector3D vectord6 = (Vector3D) (right * hB.X);
            Vector3D vectord7 = (Vector3D) (up * hB.Y);
            Vector3D vectord8 = (Vector3D) (backward * hB.Z);
            double num = (Math.Abs(vectord6.X) + Math.Abs(vectord7.X)) + Math.Abs(vectord8.X);
            double num2 = (Math.Abs(vectord6.Y) + Math.Abs(vectord7.Y)) + Math.Abs(vectord8.Y);
            double num3 = (Math.Abs(vectord6.Z) + Math.Abs(vectord7.Z)) + Math.Abs(vectord8.Z);
            if ((((vectord2.X + num) <= hA.X) && ((vectord2.Y + num2) <= hA.Y)) && ((vectord2.Z + num3) <= hA.Z))
            {
                return ContainmentType.Contains;
            }
            if (vectord2.X > (((hA.X + Math.Abs(vectord6.X)) + Math.Abs(vectord7.X)) + Math.Abs(vectord8.X)))
            {
                return ContainmentType.Disjoint;
            }
            if (vectord2.Y > (((hA.Y + Math.Abs(vectord6.Y)) + Math.Abs(vectord7.Y)) + Math.Abs(vectord8.Y)))
            {
                return ContainmentType.Disjoint;
            }
            if (vectord2.Z > (((hA.Z + Math.Abs(vectord6.Z)) + Math.Abs(vectord7.Z)) + Math.Abs(vectord8.Z)))
            {
                return ContainmentType.Disjoint;
            }
            if (Math.Abs(Vector3.Dot((Vector3) translation, (Vector3) right)) > (((Math.Abs((double) (hA.X * right.X)) + Math.Abs((double) (hA.Y * right.Y))) + Math.Abs((double) (hA.Z * right.Z))) + hB.X))
            {
                return ContainmentType.Disjoint;
            }
            if (Math.Abs(Vector3.Dot((Vector3) translation, (Vector3) up)) > (((Math.Abs((double) (hA.X * up.X)) + Math.Abs((double) (hA.Y * up.Y))) + Math.Abs((double) (hA.Z * up.Z))) + hB.Y))
            {
                return ContainmentType.Disjoint;
            }
            if (Math.Abs(Vector3.Dot((Vector3) translation, (Vector3) backward)) > (((Math.Abs((double) (hA.X * backward.X)) + Math.Abs((double) (hA.Y * backward.Y))) + Math.Abs((double) (hA.Z * backward.Z))) + hB.Z))
            {
                return ContainmentType.Disjoint;
            }
            Vector3 vector = (Vector3) new Vector3D(0.0, -right.Z, right.Y);
            if (Math.Abs(Vector3.Dot((Vector3) translation, vector)) > (((Math.Abs((double) (hA.Y * vector.Y)) + Math.Abs((double) (hA.Z * vector.Z))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord7))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord8))))
            {
                return ContainmentType.Disjoint;
            }
            vector = (Vector3) new Vector3D(0.0, -up.Z, up.Y);
            if (Math.Abs(Vector3.Dot((Vector3) translation, vector)) > (((Math.Abs((double) (hA.Y * vector.Y)) + Math.Abs((double) (hA.Z * vector.Z))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord8))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord6))))
            {
                return ContainmentType.Disjoint;
            }
            vector = (Vector3) new Vector3D(0.0, -backward.Z, backward.Y);
            if (Math.Abs(Vector3.Dot((Vector3) translation, vector)) > (((Math.Abs((double) (hA.Y * vector.Y)) + Math.Abs((double) (hA.Z * vector.Z))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord6))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord7))))
            {
                return ContainmentType.Disjoint;
            }
            vector = (Vector3) new Vector3D(right.Z, 0.0, -right.X);
            if (Math.Abs(Vector3.Dot((Vector3) translation, vector)) > (((Math.Abs((double) (hA.Z * vector.Z)) + Math.Abs((double) (hA.X * vector.X))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord7))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord8))))
            {
                return ContainmentType.Disjoint;
            }
            vector = (Vector3) new Vector3D(up.Z, 0.0, -up.X);
            if (Math.Abs(Vector3.Dot((Vector3) translation, vector)) > (((Math.Abs((double) (hA.Z * vector.Z)) + Math.Abs((double) (hA.X * vector.X))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord8))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord6))))
            {
                return ContainmentType.Disjoint;
            }
            vector = (Vector3) new Vector3D(backward.Z, 0.0, -backward.X);
            if (Math.Abs(Vector3.Dot((Vector3) translation, vector)) > (((Math.Abs((double) (hA.Z * vector.Z)) + Math.Abs((double) (hA.X * vector.X))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord6))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord7))))
            {
                return ContainmentType.Disjoint;
            }
            vector = (Vector3) new Vector3D(-right.Y, right.X, 0.0);
            if (Math.Abs(Vector3.Dot((Vector3) translation, vector)) > (((Math.Abs((double) (hA.X * vector.X)) + Math.Abs((double) (hA.Y * vector.Y))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord7))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord8))))
            {
                return ContainmentType.Disjoint;
            }
            vector = (Vector3) new Vector3D(-up.Y, up.X, 0.0);
            if (Math.Abs(Vector3.Dot((Vector3) translation, vector)) > (((Math.Abs((double) (hA.X * vector.X)) + Math.Abs((double) (hA.Y * vector.Y))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord8))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord6))))
            {
                return ContainmentType.Disjoint;
            }
            vector = (Vector3) new Vector3D(-backward.Y, backward.X, 0.0);
            if (Math.Abs(Vector3.Dot((Vector3) translation, vector)) > (((Math.Abs((double) (hA.X * vector.X)) + Math.Abs((double) (hA.Y * vector.Y))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord6))) + Math.Abs(Vector3.Dot(vector, (Vector3) vectord7))))
            {
                return ContainmentType.Disjoint;
            }
            return ContainmentType.Intersects;
        }

        public BoundingFrustumD ConvertToFrustum()
        {
            Quaternion quaternion;
            MatrixD xd;
            Quaternion.Conjugate(ref this.Orientation, out quaternion);
            double num = 1.0 / this.HalfExtent.X;
            double num2 = 1.0 / this.HalfExtent.Y;
            double num3 = 0.5 / this.HalfExtent.Z;
            MatrixD.CreateFromQuaternion(ref quaternion, out xd);
            xd.M11 *= num;
            xd.M21 *= num;
            xd.M31 *= num;
            xd.M12 *= num2;
            xd.M22 *= num2;
            xd.M32 *= num2;
            xd.M13 *= num3;
            xd.M23 *= num3;
            xd.M33 *= num3;
            xd.Translation = ((Vector3D) (Vector3.UnitZ * 0.5f)) + Vector3D.TransformNormal(-this.Center, xd);
            return new BoundingFrustumD(xd);
        }

        public BoundingBoxD GetAABB()
        {
            if (m_cornersTmp == null)
            {
                m_cornersTmp = new Vector3D[8];
            }
            this.GetCorners(m_cornersTmp, 0);
            BoundingBoxD xd = BoundingBoxD.CreateInvalid();
            for (int i = 0; i < 8; i++)
            {
                xd.Include(m_cornersTmp[i]);
            }
            return xd;
        }

        public static MyOrientedBoundingBoxD Create(BoundingBoxD boundingBox, MatrixD matrix)
        {
            MyOrientedBoundingBoxD xd = new MyOrientedBoundingBoxD(boundingBox.Center, boundingBox.HalfExtents, Quaternion.Identity);
            xd.Transform(matrix);
            return xd;
        }

        static MyOrientedBoundingBoxD()
        {
            StartVertices = new int[] { 0, 1, 5, 4, 3, 2, 6, 7, 0, 1, 5, 4 };
            EndVertices = new int[] { 1, 5, 4, 0, 2, 6, 7, 3, 3, 2, 6, 7 };
            StartXVertices = new int[] { 0, 4, 7, 3 };
            EndXVertices = new int[] { 1, 5, 6, 2 };
            StartYVertices = new int[] { 0, 1, 5, 4 };
            EndYVertices = new int[] { 3, 2, 6, 7 };
            StartZVertices = new int[] { 0, 3, 2, 1 };
            EndZVertices = new int[] { 4, 7, 6, 5 };
            XNeighbourVectorsBack = new Vector3[] { new Vector3(0f, 0f, 1f), new Vector3(0f, 1f, 0f), new Vector3(0f, 0f, -1f), new Vector3(0f, -1f, 0f) };
            XNeighbourVectorsForw = new Vector3[] { new Vector3(0f, 0f, -1f), new Vector3(0f, -1f, 0f), new Vector3(0f, 0f, 1f), new Vector3(0f, 1f, 0f) };
            YNeighbourVectorsBack = new Vector3[] { new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 1f), new Vector3(-1f, 0f, 0f), new Vector3(0f, 0f, -1f) };
            YNeighbourVectorsForw = new Vector3[] { new Vector3(-1f, 0f, 0f), new Vector3(0f, 0f, -1f), new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 1f) };
            ZNeighbourVectorsBack = new Vector3[] { new Vector3(0f, 1f, 0f), new Vector3(1f, 0f, 0f), new Vector3(0f, -1f, 0f), new Vector3(-1f, 0f, 0f) };
            ZNeighbourVectorsForw = new Vector3[] { new Vector3(0f, -1f, 0f), new Vector3(-1f, 0f, 0f), new Vector3(0f, 1f, 0f), new Vector3(1f, 0f, 0f) };
        }
    }
}

