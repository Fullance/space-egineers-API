namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct CapsuleD
    {
        public Vector3D P0;
        public Vector3D P1;
        public float Radius;
        public CapsuleD(Vector3D p0, Vector3D p1, float radius)
        {
            this.P0 = p0;
            this.P1 = p1;
            this.Radius = radius;
        }

        public bool Intersect(RayD ray, ref Vector3D p1, ref Vector3D p2, ref Vector3 n1, ref Vector3 n2)
        {
            Vector3D v = this.P1 - this.P0;
            Vector3D vectord2 = ray.Position - this.P0;
            double num = v.Dot(ray.Direction);
            double num2 = v.Dot(vectord2);
            double num3 = v.Dot(v);
            double num4 = (num3 > 0.0) ? (num / num3) : 0.0;
            double num5 = (num3 > 0.0) ? (num2 / num3) : 0.0;
            Vector3D vectord3 = ray.Direction - ((Vector3D) (v * num4));
            Vector3D vectord4 = vectord2 - ((Vector3D) (v * num5));
            double num6 = vectord3.Dot(vectord3);
            double num7 = 2.0 * vectord3.Dot(vectord4);
            double num8 = vectord4.Dot(vectord4) - (this.Radius * this.Radius);
            if (num6 == 0.0)
            {
                BoundingSphereD ed;
                BoundingSphereD ed2;
                double num9;
                double num10;
                double num11;
                double num12;
                ed.Center = this.P0;
                ed.Radius = this.Radius;
                ed2.Center = this.P1;
                ed2.Radius = this.Radius;
                if (!ed.IntersectRaySphere(ray, out num9, out num10) || !ed2.IntersectRaySphere(ray, out num11, out num12))
                {
                    return false;
                }
                if (num9 < num11)
                {
                    p1 = ray.Position + ((Vector3D) (ray.Direction * num9));
                    n1 = (Vector3) (p1 - this.P0);
                    n1.Normalize();
                }
                else
                {
                    p1 = ray.Position + ((Vector3D) (ray.Direction * num11));
                    n1 = (Vector3) (p1 - this.P1);
                    n1.Normalize();
                }
                if (num10 > num12)
                {
                    p2 = ray.Position + ((Vector3D) (ray.Direction * num10));
                    n2 = (Vector3) (p2 - this.P0);
                    n2.Normalize();
                }
                else
                {
                    p2 = ray.Position + ((Vector3D) (ray.Direction * num12));
                    n2 = (Vector3) (p2 - this.P1);
                    n2.Normalize();
                }
                return true;
            }
            double d = (num7 * num7) - ((4.0 * num6) * num8);
            if (d < 0.0)
            {
                return false;
            }
            double num14 = (-num7 - Math.Sqrt(d)) / (2.0 * num6);
            double num15 = (-num7 + Math.Sqrt(d)) / (2.0 * num6);
            if (num14 > num15)
            {
                double num16 = num14;
                num14 = num15;
                num15 = num16;
            }
            double num17 = (num14 * num4) + num5;
            if (num17 < 0.0)
            {
                BoundingSphereD ed3;
                double num18;
                double num19;
                ed3.Center = this.P0;
                ed3.Radius = this.Radius;
                if (!ed3.IntersectRaySphere(ray, out num18, out num19))
                {
                    return false;
                }
                p1 = ray.Position + ((Vector3D) (ray.Direction * num18));
                n1 = (Vector3) (p1 - this.P0);
                n1.Normalize();
            }
            else if (num17 > 1.0)
            {
                BoundingSphereD ed4;
                double num20;
                double num21;
                ed4.Center = this.P1;
                ed4.Radius = this.Radius;
                if (!ed4.IntersectRaySphere(ray, out num20, out num21))
                {
                    return false;
                }
                p1 = ray.Position + ((Vector3D) (ray.Direction * num20));
                n1 = (Vector3) (p1 - this.P1);
                n1.Normalize();
            }
            else
            {
                p1 = ray.Position + ((Vector3D) (ray.Direction * num14));
                Vector3 vector = (Vector3) (this.P0 + (v * num17));
                n1 = ((Vector3) p1) - vector;
                n1.Normalize();
            }
            double num22 = (num15 * num4) + num5;
            if (num22 < 0.0)
            {
                BoundingSphereD ed5;
                double num23;
                double num24;
                ed5.Center = this.P0;
                ed5.Radius = this.Radius;
                if (!ed5.IntersectRaySphere(ray, out num23, out num24))
                {
                    return false;
                }
                p2 = ray.Position + ((Vector3D) (ray.Direction * num24));
                n2 = (Vector3) (p2 - this.P0);
                n2.Normalize();
            }
            else if (num22 > 1.0)
            {
                BoundingSphereD ed6;
                double num25;
                double num26;
                ed6.Center = this.P1;
                ed6.Radius = this.Radius;
                if (!ed6.IntersectRaySphere(ray, out num25, out num26))
                {
                    return false;
                }
                p2 = ray.Position + ((Vector3D) (ray.Direction * num26));
                n2 = (Vector3) (p2 - this.P1);
                n2.Normalize();
            }
            else
            {
                p2 = ray.Position + ((Vector3D) (ray.Direction * num15));
                Vector3D vectord5 = this.P0 + ((Vector3D) (v * num22));
                n2 = (Vector3) (p2 - vectord5);
                n2.Normalize();
            }
            return true;
        }

        public bool Intersect(LineD line, ref Vector3D p1, ref Vector3D p2, ref Vector3 n1, ref Vector3 n2)
        {
            RayD ray = new RayD(line.From, line.Direction);
            if (!this.Intersect(ray, ref p1, ref p2, ref n1, ref n2))
            {
                return false;
            }
            Vector3D vectord = p1 - line.From;
            Vector3D vectord2 = p2 - line.From;
            double num = vectord.Normalize();
            vectord2.Normalize();
            if (Vector3D.Dot(line.Direction, vectord) < 0.9)
            {
                return false;
            }
            if (Vector3D.Dot(line.Direction, vectord2) < 0.9)
            {
                return false;
            }
            if (line.Length < num)
            {
                return false;
            }
            return true;
        }
    }
}

