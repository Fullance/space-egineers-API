namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyOrientedBoundingBox : IEquatable<MyOrientedBoundingBox>
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
        public Vector3 Center;
        public Vector3 HalfExtent;
        public Quaternion Orientation;
        [ThreadStatic]
        private static Vector3[] m_cornersTmp;
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

        public MyOrientedBoundingBox(ref Matrix matrix)
        {
            this.Center = matrix.Translation;
            Vector3 vector = new Vector3(matrix.Right.Length(), matrix.Up.Length(), matrix.Forward.Length());
            this.HalfExtent = (Vector3) (vector / 2f);
            matrix.Right = (Vector3) (matrix.Right / vector.X);
            matrix.Up = (Vector3) (matrix.Up / vector.Y);
            matrix.Forward = (Vector3) (matrix.Forward / vector.Z);
            Quaternion.CreateFromRotationMatrix(ref matrix, out this.Orientation);
        }

        public MyOrientedBoundingBox(Vector3 center, Vector3 halfExtents, Quaternion orientation)
        {
            this.Center = center;
            this.HalfExtent = halfExtents;
            this.Orientation = orientation;
        }

        public static MyOrientedBoundingBox CreateFromBoundingBox(BoundingBox box)
        {
            Vector3 center = (Vector3) ((box.Min + box.Max) * 0.5f);
            return new MyOrientedBoundingBox(center, (Vector3) ((box.Max - box.Min) * 0.5f), Quaternion.Identity);
        }

        public MyOrientedBoundingBox Transform(Quaternion rotation, Vector3 translation) => 
            new MyOrientedBoundingBox(Vector3.Transform(this.Center, rotation) + translation, this.HalfExtent, this.Orientation * rotation);

        public MyOrientedBoundingBox Transform(float scale, Quaternion rotation, Vector3 translation) => 
            new MyOrientedBoundingBox(Vector3.Transform((Vector3) (this.Center * scale), rotation) + translation, (Vector3) (this.HalfExtent * scale), this.Orientation * rotation);

        public void Transform(Matrix matrix)
        {
            this.Center = Vector3.Transform(this.Center, matrix);
            this.Orientation = Quaternion.CreateFromRotationMatrix(Matrix.CreateFromQuaternion(this.Orientation) * matrix);
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

        public static bool operator ==(MyOrientedBoundingBox a, MyOrientedBoundingBox b) => 
            a.Equals(b);

        public static bool operator !=(MyOrientedBoundingBox a, MyOrientedBoundingBox b) => 
            !a.Equals(b);

        public override string ToString() => 
            ("{Center:" + this.Center.ToString() + " Extents:" + this.HalfExtent.ToString() + " Orientation:" + this.Orientation.ToString() + "}");

        public bool Intersects(ref BoundingBox box)
        {
            Vector3 vector = (Vector3) ((box.Max + box.Min) * 0.5f);
            Vector3 hA = (Vector3) ((box.Max - box.Min) * 0.5f);
            Matrix mB = Matrix.CreateFromQuaternion(this.Orientation);
            mB.Translation = this.Center - vector;
            return (ContainsRelativeBox(ref hA, ref this.HalfExtent, ref mB) != ContainmentType.Disjoint);
        }

        public ContainmentType Contains(ref BoundingBox box)
        {
            Quaternion quaternion;
            Vector3 vector = (Vector3) ((box.Max + box.Min) * 0.5f);
            Vector3 hB = (Vector3) ((box.Max - box.Min) * 0.5f);
            Quaternion.Conjugate(ref this.Orientation, out quaternion);
            Matrix matrix = Matrix.CreateFromQuaternion(quaternion);
            matrix.Translation = Vector3.TransformNormal(vector - this.Center, matrix);
            return ContainsRelativeBox(ref this.HalfExtent, ref hB, ref matrix);
        }

        public static ContainmentType Contains(ref BoundingBox boxA, ref MyOrientedBoundingBox oboxB)
        {
            Vector3 hA = (Vector3) ((boxA.Max - boxA.Min) * 0.5f);
            Vector3 vector2 = (Vector3) ((boxA.Max + boxA.Min) * 0.5f);
            Matrix mB = Matrix.CreateFromQuaternion(oboxB.Orientation);
            mB.Translation = oboxB.Center - vector2;
            return ContainsRelativeBox(ref hA, ref oboxB.HalfExtent, ref mB);
        }

        public bool Intersects(ref MyOrientedBoundingBox other) => 
            (this.Contains(ref other) != ContainmentType.Disjoint);

        public ContainmentType Contains(ref MyOrientedBoundingBox other)
        {
            Quaternion quaternion;
            Quaternion quaternion2;
            Quaternion.Conjugate(ref this.Orientation, out quaternion);
            Quaternion.Multiply(ref quaternion, ref other.Orientation, out quaternion2);
            Matrix mB = Matrix.CreateFromQuaternion(quaternion2);
            mB.Translation = Vector3.Transform(other.Center - this.Center, quaternion);
            return ContainsRelativeBox(ref this.HalfExtent, ref other.HalfExtent, ref mB);
        }

        public ContainmentType Contains(BoundingFrustum frustum) => 
            this.ConvertToFrustum().Contains(frustum);

        public bool Intersects(BoundingFrustum frustum) => 
            (this.Contains(frustum) != ContainmentType.Disjoint);

        public static ContainmentType Contains(BoundingFrustum frustum, ref MyOrientedBoundingBox obox) => 
            frustum.Contains(obox.ConvertToFrustum());

        public ContainmentType Contains(ref BoundingSphere sphere)
        {
            Quaternion rotation = Quaternion.Conjugate(this.Orientation);
            Vector3 vector = Vector3.Transform(sphere.Center - this.Center, rotation);
            float num = Math.Abs(vector.X) - this.HalfExtent.X;
            float num2 = Math.Abs(vector.Y) - this.HalfExtent.Y;
            float num3 = Math.Abs(vector.Z) - this.HalfExtent.Z;
            float radius = sphere.Radius;
            if (((num <= -radius) && (num2 <= -radius)) && (num3 <= -radius))
            {
                return ContainmentType.Contains;
            }
            num = Math.Max(num, 0f);
            num2 = Math.Max(num2, 0f);
            num3 = Math.Max(num3, 0f);
            if ((((num * num) + (num2 * num2)) + (num3 * num3)) >= (radius * radius))
            {
                return ContainmentType.Disjoint;
            }
            return ContainmentType.Intersects;
        }

        public bool Intersects(ref BoundingSphere sphere)
        {
            Quaternion rotation = Quaternion.Conjugate(this.Orientation);
            Vector3 vector = Vector3.Transform(sphere.Center - this.Center, rotation);
            float num = Math.Abs(vector.X) - this.HalfExtent.X;
            float num2 = Math.Abs(vector.Y) - this.HalfExtent.Y;
            float num3 = Math.Abs(vector.Z) - this.HalfExtent.Z;
            num = Math.Max(num, 0f);
            num2 = Math.Max(num2, 0f);
            num3 = Math.Max(num3, 0f);
            float radius = sphere.Radius;
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

        public float? Intersects(ref Ray ray)
        {
            Matrix matrix = Matrix.CreateFromQuaternion(this.Orientation);
            Vector3 vector = this.Center - ray.Position;
            float minValue = float.MinValue;
            float maxValue = float.MaxValue;
            float num3 = Vector3.Dot(matrix.Right, vector);
            float num4 = Vector3.Dot(matrix.Right, ray.Direction);
            if ((num4 >= -1E-20f) && (num4 <= 1E-20f))
            {
                if (((-num3 - this.HalfExtent.X) > 0.0) || ((-num3 + this.HalfExtent.X) < 0f))
                {
                    return null;
                }
            }
            else
            {
                float num5 = (num3 - this.HalfExtent.X) / num4;
                float num6 = (num3 + this.HalfExtent.X) / num4;
                if (num5 > num6)
                {
                    float num7 = num5;
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
                if ((maxValue < 0f) || (minValue > maxValue))
                {
                    return null;
                }
            }
            num3 = Vector3.Dot(matrix.Up, vector);
            num4 = Vector3.Dot(matrix.Up, ray.Direction);
            if ((num4 >= -1E-20f) && (num4 <= 1E-20f))
            {
                if (((-num3 - this.HalfExtent.Y) > 0.0) || ((-num3 + this.HalfExtent.Y) < 0f))
                {
                    return null;
                }
            }
            else
            {
                float num8 = (num3 - this.HalfExtent.Y) / num4;
                float num9 = (num3 + this.HalfExtent.Y) / num4;
                if (num8 > num9)
                {
                    float num10 = num8;
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
                if ((maxValue < 0f) || (minValue > maxValue))
                {
                    return null;
                }
            }
            num3 = Vector3.Dot(matrix.Forward, vector);
            num4 = Vector3.Dot(matrix.Forward, ray.Direction);
            if ((num4 >= -1E-20f) && (num4 <= 1E-20f))
            {
                if (((-num3 - this.HalfExtent.Z) > 0.0) || ((-num3 + this.HalfExtent.Z) < 0f))
                {
                    return null;
                }
            }
            else
            {
                float num11 = (num3 - this.HalfExtent.Z) / num4;
                float num12 = (num3 + this.HalfExtent.Z) / num4;
                if (num11 > num12)
                {
                    float num13 = num11;
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
                if ((maxValue < 0f) || (minValue > maxValue))
                {
                    return null;
                }
            }
            return new float?(minValue);
        }

        public float? Intersects(ref Line line)
        {
            if (this.Contains(ref line.From))
            {
                Ray ray = new Ray(line.To, -line.Direction);
                float? nullable = this.Intersects(ref ray);
                if (!nullable.HasValue)
                {
                    return null;
                }
                float num = line.Length - nullable.Value;
                if (num < 0f)
                {
                    return null;
                }
                if (num > line.Length)
                {
                    return null;
                }
                return new float?(num);
            }
            Ray ray2 = new Ray(line.From, line.Direction);
            float? nullable2 = this.Intersects(ref ray2);
            if (!nullable2.HasValue)
            {
                return null;
            }
            if (nullable2.Value < 0f)
            {
                return null;
            }
            if (nullable2.Value > line.Length)
            {
                return null;
            }
            return new float?(nullable2.Value);
        }

        public PlaneIntersectionType Intersects(ref Plane plane)
        {
            float num = plane.DotCoordinate(this.Center);
            Vector3 vector = Vector3.Transform(plane.Normal, Quaternion.Conjugate(this.Orientation));
            float introduced3 = Math.Abs((float) (this.HalfExtent.X * vector.X));
            float num2 = (introduced3 + Math.Abs((float) (this.HalfExtent.Y * vector.Y))) + Math.Abs((float) (this.HalfExtent.Z * vector.Z));
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

        public void GetCorners(Vector3[] corners, int startIndex)
        {
            Matrix matrix = Matrix.CreateFromQuaternion(this.Orientation);
            Vector3 vector = (Vector3) (matrix.Left * this.HalfExtent.X);
            Vector3 vector2 = (Vector3) (matrix.Up * this.HalfExtent.Y);
            Vector3 vector3 = (Vector3) (matrix.Backward * this.HalfExtent.Z);
            int num = startIndex;
            corners[num++] = ((this.Center - vector) + vector2) + vector3;
            corners[num++] = ((this.Center + vector) + vector2) + vector3;
            corners[num++] = ((this.Center + vector) - vector2) + vector3;
            corners[num++] = ((this.Center - vector) - vector2) + vector3;
            corners[num++] = ((this.Center - vector) + vector2) - vector3;
            corners[num++] = ((this.Center + vector) + vector2) - vector3;
            corners[num++] = ((this.Center + vector) - vector2) - vector3;
            corners[num++] = ((this.Center - vector) - vector2) - vector3;
        }

        public static ContainmentType ContainsRelativeBox(ref Vector3 hA, ref Vector3 hB, ref Matrix mB)
        {
            Vector3 translation = mB.Translation;
            float x = Math.Abs(translation.X);
            float y = Math.Abs(translation.Y);
            Vector3 vector2 = new Vector3(x, y, Math.Abs(translation.Z));
            Vector3 right = mB.Right;
            Vector3 up = mB.Up;
            Vector3 backward = mB.Backward;
            Vector3 vector6 = (Vector3) (right * hB.X);
            Vector3 vector7 = (Vector3) (up * hB.Y);
            Vector3 vector8 = (Vector3) (backward * hB.Z);
            float num = (Math.Abs(vector6.X) + Math.Abs(vector7.X)) + Math.Abs(vector8.X);
            float num2 = (Math.Abs(vector6.Y) + Math.Abs(vector7.Y)) + Math.Abs(vector8.Y);
            float num3 = (Math.Abs(vector6.Z) + Math.Abs(vector7.Z)) + Math.Abs(vector8.Z);
            if ((((vector2.X + num) <= hA.X) && ((vector2.Y + num2) <= hA.Y)) && ((vector2.Z + num3) <= hA.Z))
            {
                return ContainmentType.Contains;
            }
            if (vector2.X > (((hA.X + Math.Abs(vector6.X)) + Math.Abs(vector7.X)) + Math.Abs(vector8.X)))
            {
                return ContainmentType.Disjoint;
            }
            if (vector2.Y > (((hA.Y + Math.Abs(vector6.Y)) + Math.Abs(vector7.Y)) + Math.Abs(vector8.Y)))
            {
                return ContainmentType.Disjoint;
            }
            if (vector2.Z > (((hA.Z + Math.Abs(vector6.Z)) + Math.Abs(vector7.Z)) + Math.Abs(vector8.Z)))
            {
                return ContainmentType.Disjoint;
            }
            if (Math.Abs(Vector3.Dot(translation, right)) > (((Math.Abs((float) (hA.X * right.X)) + Math.Abs((float) (hA.Y * right.Y))) + Math.Abs((float) (hA.Z * right.Z))) + hB.X))
            {
                return ContainmentType.Disjoint;
            }
            if (Math.Abs(Vector3.Dot(translation, up)) > (((Math.Abs((float) (hA.X * up.X)) + Math.Abs((float) (hA.Y * up.Y))) + Math.Abs((float) (hA.Z * up.Z))) + hB.Y))
            {
                return ContainmentType.Disjoint;
            }
            if (Math.Abs(Vector3.Dot(translation, backward)) > (((Math.Abs((float) (hA.X * backward.X)) + Math.Abs((float) (hA.Y * backward.Y))) + Math.Abs((float) (hA.Z * backward.Z))) + hB.Z))
            {
                return ContainmentType.Disjoint;
            }
            Vector3 vector9 = new Vector3(0f, -right.Z, right.Y);
            if (Math.Abs(Vector3.Dot(translation, vector9)) > (((Math.Abs((float) (hA.Y * vector9.Y)) + Math.Abs((float) (hA.Z * vector9.Z))) + Math.Abs(Vector3.Dot(vector9, vector7))) + Math.Abs(Vector3.Dot(vector9, vector8))))
            {
                return ContainmentType.Disjoint;
            }
            vector9 = new Vector3(0f, -up.Z, up.Y);
            if (Math.Abs(Vector3.Dot(translation, vector9)) > (((Math.Abs((float) (hA.Y * vector9.Y)) + Math.Abs((float) (hA.Z * vector9.Z))) + Math.Abs(Vector3.Dot(vector9, vector8))) + Math.Abs(Vector3.Dot(vector9, vector6))))
            {
                return ContainmentType.Disjoint;
            }
            vector9 = new Vector3(0f, -backward.Z, backward.Y);
            if (Math.Abs(Vector3.Dot(translation, vector9)) > (((Math.Abs((float) (hA.Y * vector9.Y)) + Math.Abs((float) (hA.Z * vector9.Z))) + Math.Abs(Vector3.Dot(vector9, vector6))) + Math.Abs(Vector3.Dot(vector9, vector7))))
            {
                return ContainmentType.Disjoint;
            }
            vector9 = new Vector3(right.Z, 0f, -right.X);
            if (Math.Abs(Vector3.Dot(translation, vector9)) > (((Math.Abs((float) (hA.Z * vector9.Z)) + Math.Abs((float) (hA.X * vector9.X))) + Math.Abs(Vector3.Dot(vector9, vector7))) + Math.Abs(Vector3.Dot(vector9, vector8))))
            {
                return ContainmentType.Disjoint;
            }
            vector9 = new Vector3(up.Z, 0f, -up.X);
            if (Math.Abs(Vector3.Dot(translation, vector9)) > (((Math.Abs((float) (hA.Z * vector9.Z)) + Math.Abs((float) (hA.X * vector9.X))) + Math.Abs(Vector3.Dot(vector9, vector8))) + Math.Abs(Vector3.Dot(vector9, vector6))))
            {
                return ContainmentType.Disjoint;
            }
            vector9 = new Vector3(backward.Z, 0f, -backward.X);
            if (Math.Abs(Vector3.Dot(translation, vector9)) > (((Math.Abs((float) (hA.Z * vector9.Z)) + Math.Abs((float) (hA.X * vector9.X))) + Math.Abs(Vector3.Dot(vector9, vector6))) + Math.Abs(Vector3.Dot(vector9, vector7))))
            {
                return ContainmentType.Disjoint;
            }
            vector9 = new Vector3(-right.Y, right.X, 0f);
            if (Math.Abs(Vector3.Dot(translation, vector9)) > (((Math.Abs((float) (hA.X * vector9.X)) + Math.Abs((float) (hA.Y * vector9.Y))) + Math.Abs(Vector3.Dot(vector9, vector7))) + Math.Abs(Vector3.Dot(vector9, vector8))))
            {
                return ContainmentType.Disjoint;
            }
            vector9 = new Vector3(-up.Y, up.X, 0f);
            if (Math.Abs(Vector3.Dot(translation, vector9)) > (((Math.Abs((float) (hA.X * vector9.X)) + Math.Abs((float) (hA.Y * vector9.Y))) + Math.Abs(Vector3.Dot(vector9, vector8))) + Math.Abs(Vector3.Dot(vector9, vector6))))
            {
                return ContainmentType.Disjoint;
            }
            vector9 = new Vector3(-backward.Y, backward.X, 0f);
            if (Math.Abs(Vector3.Dot(translation, vector9)) > (((Math.Abs((float) (hA.X * vector9.X)) + Math.Abs((float) (hA.Y * vector9.Y))) + Math.Abs(Vector3.Dot(vector9, vector6))) + Math.Abs(Vector3.Dot(vector9, vector7))))
            {
                return ContainmentType.Disjoint;
            }
            return ContainmentType.Intersects;
        }

        public BoundingFrustum ConvertToFrustum()
        {
            Quaternion quaternion;
            Matrix matrix;
            Quaternion.Conjugate(ref this.Orientation, out quaternion);
            float num = 1f / this.HalfExtent.X;
            float num2 = 1f / this.HalfExtent.Y;
            float num3 = 0.5f / this.HalfExtent.Z;
            Matrix.CreateFromQuaternion(ref quaternion, out matrix);
            matrix.M11 *= num;
            matrix.M21 *= num;
            matrix.M31 *= num;
            matrix.M12 *= num2;
            matrix.M22 *= num2;
            matrix.M32 *= num2;
            matrix.M13 *= num3;
            matrix.M23 *= num3;
            matrix.M33 *= num3;
            matrix.Translation = ((Vector3) (Vector3.UnitZ * 0.5f)) + Vector3.TransformNormal(-this.Center, matrix);
            return new BoundingFrustum(matrix);
        }

        public BoundingBox GetAABB()
        {
            if (m_cornersTmp == null)
            {
                m_cornersTmp = new Vector3[8];
            }
            this.GetCorners(m_cornersTmp, 0);
            BoundingBox box = BoundingBox.CreateInvalid();
            for (int i = 0; i < 8; i++)
            {
                box.Include(m_cornersTmp[i]);
            }
            return box;
        }

        public static MyOrientedBoundingBox Create(BoundingBox boundingBox, Matrix matrix)
        {
            MyOrientedBoundingBox box = new MyOrientedBoundingBox(boundingBox.Center, boundingBox.HalfExtents, Quaternion.Identity);
            box.Transform(matrix);
            return box;
        }

        static MyOrientedBoundingBox()
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

