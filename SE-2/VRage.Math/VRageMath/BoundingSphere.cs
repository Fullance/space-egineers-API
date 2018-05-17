namespace VRageMath
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct BoundingSphere : IEquatable<BoundingSphere>
    {
        public Vector3 Center;
        public float Radius;
        public BoundingSphere(Vector3 center, float radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public static bool operator ==(BoundingSphere a, BoundingSphere b) => 
            a.Equals(b);

        public static bool operator !=(BoundingSphere a, BoundingSphere b)
        {
            if (!(a.Center != b.Center))
            {
                return !(a.Radius == b.Radius);
            }
            return true;
        }

        public bool Equals(BoundingSphere other) => 
            ((this.Center == other.Center) && (this.Radius == other.Radius));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is BoundingSphere)
            {
                flag = this.Equals((BoundingSphere) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (this.Center.GetHashCode() + this.Radius.GetHashCode());

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{Center:{0} Radius:{1}}}", new object[] { this.Center.ToString(), this.Radius.ToString(currentCulture) });
        }

        public static BoundingSphere CreateMerged(BoundingSphere original, BoundingSphere additional)
        {
            Vector3 vector;
            BoundingSphere sphere;
            Vector3.Subtract(ref additional.Center, ref original.Center, out vector);
            float num = vector.Length();
            float radius = original.Radius;
            float num3 = additional.Radius;
            if ((radius + num3) >= num)
            {
                if ((radius - num3) >= num)
                {
                    return original;
                }
                if ((num3 - radius) >= num)
                {
                    return additional;
                }
            }
            Vector3 vector2 = (Vector3) (vector * (1f / num));
            float num4 = MathHelper.Min(-radius, num - num3);
            float num5 = (float) ((MathHelper.Max(radius, num + num3) - num4) * 0.5);
            sphere.Center = original.Center + ((Vector3) (vector2 * (num5 + num4)));
            sphere.Radius = num5;
            return sphere;
        }

        public static void CreateMerged(ref BoundingSphere original, ref BoundingSphere additional, out BoundingSphere result)
        {
            Vector3 vector;
            Vector3.Subtract(ref additional.Center, ref original.Center, out vector);
            float num = vector.Length();
            float radius = original.Radius;
            float num3 = additional.Radius;
            if ((radius + num3) >= num)
            {
                if ((radius - num3) >= num)
                {
                    result = original;
                    return;
                }
                if ((num3 - radius) >= num)
                {
                    result = additional;
                    return;
                }
            }
            Vector3 vector2 = (Vector3) (vector * (1f / num));
            float num4 = MathHelper.Min(-radius, num - num3);
            float num5 = (float) ((MathHelper.Max(radius, num + num3) - num4) * 0.5);
            result.Center = original.Center + ((Vector3) (vector2 * (num5 + num4)));
            result.Radius = num5;
        }

        public static BoundingSphere CreateFromBoundingBox(BoundingBox box)
        {
            BoundingSphere sphere;
            sphere.Center = (Vector3) ((box.Min + box.Max) * 0.5f);
            Vector3.Distance(ref sphere.Center, ref box.Max, out sphere.Radius);
            return sphere;
        }

        public static void CreateFromBoundingBox(ref BoundingBox box, out BoundingSphere result)
        {
            result.Center = (Vector3) ((box.Min + box.Max) * 0.5f);
            Vector3.Distance(ref result.Center, ref box.Max, out result.Radius);
        }

        public static BoundingSphere CreateFromPoints(IEnumerable<Vector3> points)
        {
            Vector3 vector;
            float num;
            float num2;
            float num3;
            Vector3 vector9;
            float num4;
            BoundingSphere sphere;
            IEnumerator<Vector3> enumerator = points.GetEnumerator();
            enumerator.MoveNext();
            Vector3 vector2 = vector = enumerator.Current;
            Vector3 vector3 = vector;
            Vector3 vector4 = vector;
            Vector3 vector5 = vector;
            Vector3 vector6 = vector;
            Vector3 vector7 = vector;
            foreach (Vector3 vector8 in points)
            {
                if (vector8.X < vector7.X)
                {
                    vector7 = vector8;
                }
                if (vector8.X > vector6.X)
                {
                    vector6 = vector8;
                }
                if (vector8.Y < vector5.Y)
                {
                    vector5 = vector8;
                }
                if (vector8.Y > vector4.Y)
                {
                    vector4 = vector8;
                }
                if (vector8.Z < vector3.Z)
                {
                    vector3 = vector8;
                }
                if (vector8.Z > vector2.Z)
                {
                    vector2 = vector8;
                }
            }
            Vector3.Distance(ref vector6, ref vector7, out num);
            Vector3.Distance(ref vector4, ref vector5, out num2);
            Vector3.Distance(ref vector2, ref vector3, out num3);
            if (num > num2)
            {
                if (num > num3)
                {
                    Vector3.Lerp(ref vector6, ref vector7, 0.5f, out vector9);
                    num4 = num * 0.5f;
                }
                else
                {
                    Vector3.Lerp(ref vector2, ref vector3, 0.5f, out vector9);
                    num4 = num3 * 0.5f;
                }
            }
            else if (num2 > num3)
            {
                Vector3.Lerp(ref vector4, ref vector5, 0.5f, out vector9);
                num4 = num2 * 0.5f;
            }
            else
            {
                Vector3.Lerp(ref vector2, ref vector3, 0.5f, out vector9);
                num4 = num3 * 0.5f;
            }
            foreach (Vector3 vector10 in points)
            {
                Vector3 vector11;
                vector11.X = vector10.X - vector9.X;
                vector11.Y = vector10.Y - vector9.Y;
                vector11.Z = vector10.Z - vector9.Z;
                float num5 = vector11.Length();
                if (num5 > num4)
                {
                    num4 = (float) ((num4 + num5) * 0.5);
                    vector9 += (Vector3) (((float) (1.0 - (((double) num4) / ((double) num5)))) * vector11);
                }
            }
            sphere.Center = vector9;
            sphere.Radius = num4;
            return sphere;
        }

        public static BoundingSphere CreateFromFrustum(BoundingFrustum frustum)
        {
            if (frustum == null)
            {
                throw new ArgumentNullException("frustum");
            }
            return CreateFromPoints((IEnumerable<Vector3>) frustum.cornerArray);
        }

        public bool Intersects(BoundingBox box)
        {
            Vector3 vector;
            float num;
            Vector3.Clamp(ref this.Center, ref box.Min, ref box.Max, out vector);
            Vector3.DistanceSquared(ref this.Center, ref vector, out num);
            return (num <= (this.Radius * this.Radius));
        }

        public void Intersects(ref BoundingBox box, out bool result)
        {
            Vector3 vector;
            float num;
            Vector3.Clamp(ref this.Center, ref box.Min, ref box.Max, out vector);
            Vector3.DistanceSquared(ref this.Center, ref vector, out num);
            result = num <= (this.Radius * this.Radius);
        }

        public bool Intersects(BoundingFrustum frustum)
        {
            bool flag;
            frustum.Intersects(ref this, out flag);
            return flag;
        }

        public PlaneIntersectionType Intersects(Plane plane) => 
            plane.Intersects(this);

        public void Intersects(ref Plane plane, out PlaneIntersectionType result)
        {
            plane.Intersects(ref this, out result);
        }

        public float? Intersects(Ray ray) => 
            ray.Intersects(this);

        public void Intersects(ref Ray ray, out float? result)
        {
            ray.Intersects(ref this, out result);
        }

        public bool Intersects(BoundingSphere sphere)
        {
            float num;
            Vector3.DistanceSquared(ref this.Center, ref sphere.Center, out num);
            float radius = this.Radius;
            float num3 = sphere.Radius;
            return ((((radius * radius) + ((2.0 * radius) * num3)) + (num3 * num3)) > num);
        }

        public void Intersects(ref BoundingSphere sphere, out bool result)
        {
            float num;
            Vector3.DistanceSquared(ref this.Center, ref sphere.Center, out num);
            float radius = this.Radius;
            float num3 = sphere.Radius;
            result = (((radius * radius) + ((2.0 * radius) * num3)) + (num3 * num3)) > num;
        }

        public ContainmentType Contains(BoundingBox box)
        {
            Vector3 vector;
            if (!box.Intersects(this))
            {
                return ContainmentType.Disjoint;
            }
            float num = this.Radius * this.Radius;
            vector.X = this.Center.X - box.Min.X;
            vector.Y = this.Center.Y - box.Max.Y;
            vector.Z = this.Center.Z - box.Max.Z;
            if (vector.LengthSquared() <= num)
            {
                vector.X = this.Center.X - box.Max.X;
                vector.Y = this.Center.Y - box.Max.Y;
                vector.Z = this.Center.Z - box.Max.Z;
                if (vector.LengthSquared() > num)
                {
                    return ContainmentType.Intersects;
                }
                vector.X = this.Center.X - box.Max.X;
                vector.Y = this.Center.Y - box.Min.Y;
                vector.Z = this.Center.Z - box.Max.Z;
                if (vector.LengthSquared() > num)
                {
                    return ContainmentType.Intersects;
                }
                vector.X = this.Center.X - box.Min.X;
                vector.Y = this.Center.Y - box.Min.Y;
                vector.Z = this.Center.Z - box.Max.Z;
                if (vector.LengthSquared() > num)
                {
                    return ContainmentType.Intersects;
                }
                vector.X = this.Center.X - box.Min.X;
                vector.Y = this.Center.Y - box.Max.Y;
                vector.Z = this.Center.Z - box.Min.Z;
                if (vector.LengthSquared() > num)
                {
                    return ContainmentType.Intersects;
                }
                vector.X = this.Center.X - box.Max.X;
                vector.Y = this.Center.Y - box.Max.Y;
                vector.Z = this.Center.Z - box.Min.Z;
                if (vector.LengthSquared() > num)
                {
                    return ContainmentType.Intersects;
                }
                vector.X = this.Center.X - box.Max.X;
                vector.Y = this.Center.Y - box.Min.Y;
                vector.Z = this.Center.Z - box.Min.Z;
                if (vector.LengthSquared() > num)
                {
                    return ContainmentType.Intersects;
                }
                vector.X = this.Center.X - box.Min.X;
                vector.Y = this.Center.Y - box.Min.Y;
                vector.Z = this.Center.Z - box.Min.Z;
                if (vector.LengthSquared() <= num)
                {
                    return ContainmentType.Contains;
                }
            }
            return ContainmentType.Intersects;
        }

        public void Contains(ref BoundingBox box, out ContainmentType result)
        {
            bool flag;
            box.Intersects(ref this, out flag);
            if (!flag)
            {
                result = ContainmentType.Disjoint;
            }
            else
            {
                Vector3 vector;
                float num = this.Radius * this.Radius;
                result = ContainmentType.Intersects;
                vector.X = this.Center.X - box.Min.X;
                vector.Y = this.Center.Y - box.Max.Y;
                vector.Z = this.Center.Z - box.Max.Z;
                if (vector.LengthSquared() <= num)
                {
                    vector.X = this.Center.X - box.Max.X;
                    vector.Y = this.Center.Y - box.Max.Y;
                    vector.Z = this.Center.Z - box.Max.Z;
                    if (vector.LengthSquared() <= num)
                    {
                        vector.X = this.Center.X - box.Max.X;
                        vector.Y = this.Center.Y - box.Min.Y;
                        vector.Z = this.Center.Z - box.Max.Z;
                        if (vector.LengthSquared() <= num)
                        {
                            vector.X = this.Center.X - box.Min.X;
                            vector.Y = this.Center.Y - box.Min.Y;
                            vector.Z = this.Center.Z - box.Max.Z;
                            if (vector.LengthSquared() <= num)
                            {
                                vector.X = this.Center.X - box.Min.X;
                                vector.Y = this.Center.Y - box.Max.Y;
                                vector.Z = this.Center.Z - box.Min.Z;
                                if (vector.LengthSquared() <= num)
                                {
                                    vector.X = this.Center.X - box.Max.X;
                                    vector.Y = this.Center.Y - box.Max.Y;
                                    vector.Z = this.Center.Z - box.Min.Z;
                                    if (vector.LengthSquared() <= num)
                                    {
                                        vector.X = this.Center.X - box.Max.X;
                                        vector.Y = this.Center.Y - box.Min.Y;
                                        vector.Z = this.Center.Z - box.Min.Z;
                                        if (vector.LengthSquared() <= num)
                                        {
                                            vector.X = this.Center.X - box.Min.X;
                                            vector.Y = this.Center.Y - box.Min.Y;
                                            vector.Z = this.Center.Z - box.Min.Z;
                                            if (vector.LengthSquared() <= num)
                                            {
                                                result = ContainmentType.Contains;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public ContainmentType Contains(BoundingFrustum frustum)
        {
            if (!frustum.Intersects(this))
            {
                return ContainmentType.Disjoint;
            }
            float num = this.Radius * this.Radius;
            foreach (Vector3 vector in frustum.cornerArray)
            {
                Vector3 vector2;
                vector2.X = vector.X - this.Center.X;
                vector2.Y = vector.Y - this.Center.Y;
                vector2.Z = vector.Z - this.Center.Z;
                if (vector2.LengthSquared() > num)
                {
                    return ContainmentType.Intersects;
                }
            }
            return ContainmentType.Contains;
        }

        public ContainmentType Contains(Vector3 point)
        {
            if (Vector3.DistanceSquared(point, this.Center) < (this.Radius * this.Radius))
            {
                return ContainmentType.Contains;
            }
            return ContainmentType.Disjoint;
        }

        public void Contains(ref Vector3 point, out ContainmentType result)
        {
            float num;
            Vector3.DistanceSquared(ref point, ref this.Center, out num);
            result = (num < (this.Radius * this.Radius)) ? ContainmentType.Contains : ContainmentType.Disjoint;
        }

        public ContainmentType Contains(BoundingSphere sphere)
        {
            float num;
            Vector3.Distance(ref this.Center, ref sphere.Center, out num);
            float radius = this.Radius;
            float num3 = sphere.Radius;
            if ((radius + num3) < num)
            {
                return ContainmentType.Disjoint;
            }
            if ((radius - num3) >= num)
            {
                return ContainmentType.Contains;
            }
            return ContainmentType.Intersects;
        }

        public void Contains(ref BoundingSphere sphere, out ContainmentType result)
        {
            float num;
            Vector3.Distance(ref this.Center, ref sphere.Center, out num);
            float radius = this.Radius;
            float num3 = sphere.Radius;
            result = ((radius + num3) >= num) ? (((radius - num3) >= num) ? ContainmentType.Contains : ContainmentType.Intersects) : ContainmentType.Disjoint;
        }

        internal void SupportMapping(ref Vector3 v, out Vector3 result)
        {
            float num = this.Radius / v.Length();
            result.X = this.Center.X + (v.X * num);
            result.Y = this.Center.Y + (v.Y * num);
            result.Z = this.Center.Z + (v.Z * num);
        }

        public BoundingSphere Transform(Matrix matrix)
        {
            BoundingSphere sphere = new BoundingSphere {
                Center = Vector3.Transform(this.Center, matrix)
            };
            float num = Math.Max(((matrix.M11 * matrix.M11) + (matrix.M12 * matrix.M12)) + (matrix.M13 * matrix.M13), Math.Max((float) (((matrix.M21 * matrix.M21) + (matrix.M22 * matrix.M22)) + (matrix.M23 * matrix.M23)), (float) (((matrix.M31 * matrix.M31) + (matrix.M32 * matrix.M32)) + (matrix.M33 * matrix.M33))));
            sphere.Radius = this.Radius * ((float) Math.Sqrt((double) num));
            return sphere;
        }

        public void Transform(ref Matrix matrix, out BoundingSphere result)
        {
            result.Center = Vector3.Transform(this.Center, (Matrix) matrix);
            float num = Math.Max(((matrix.M11 * matrix.M11) + (matrix.M12 * matrix.M12)) + (matrix.M13 * matrix.M13), Math.Max((float) (((matrix.M21 * matrix.M21) + (matrix.M22 * matrix.M22)) + (matrix.M23 * matrix.M23)), (float) (((matrix.M31 * matrix.M31) + (matrix.M32 * matrix.M32)) + (matrix.M33 * matrix.M33))));
            result.Radius = this.Radius * ((float) Math.Sqrt((double) num));
        }

        public bool IntersectRaySphere(Ray ray, out float tmin, out float tmax)
        {
            tmin = 0f;
            tmax = 0f;
            Vector3 v = ray.Position - this.Center;
            float num = ray.Direction.Dot(ray.Direction);
            float num2 = 2f * v.Dot(ray.Direction);
            float num3 = v.Dot(v) - (this.Radius * this.Radius);
            float num4 = (num2 * num2) - ((4f * num) * num3);
            if (num4 < 0f)
            {
                return false;
            }
            tmin = (-num2 - ((float) Math.Sqrt((double) num4))) / (2f * num);
            tmax = (-num2 + ((float) Math.Sqrt((double) num4))) / (2f * num);
            if (tmin > tmax)
            {
                float num5 = tmin;
                tmin = tmax;
                tmax = num5;
            }
            return true;
        }

        public BoundingSphere Include(BoundingSphere sphere)
        {
            Include(ref this, ref sphere);
            return this;
        }

        public static void Include(ref BoundingSphere sphere, ref BoundingSphere otherSphere)
        {
            if (sphere.Radius == float.MinValue)
            {
                sphere.Center = otherSphere.Center;
                sphere.Radius = otherSphere.Radius;
            }
            else
            {
                float num = Vector3.Distance(sphere.Center, otherSphere.Center);
                if ((num + otherSphere.Radius) > sphere.Radius)
                {
                    if ((num + sphere.Radius) <= otherSphere.Radius)
                    {
                        sphere = otherSphere;
                    }
                    else
                    {
                        float amount = ((num + otherSphere.Radius) - sphere.Radius) / (2f * num);
                        Vector3 vector = Vector3.Lerp(sphere.Center, otherSphere.Center, amount);
                        float num3 = ((num + sphere.Radius) + otherSphere.Radius) / 2f;
                        sphere.Center = vector;
                        sphere.Radius = num3;
                    }
                }
            }
        }

        public static BoundingSphere CreateInvalid() => 
            new BoundingSphere((Vector3) Vector3D.Zero, float.MinValue);
    }
}

