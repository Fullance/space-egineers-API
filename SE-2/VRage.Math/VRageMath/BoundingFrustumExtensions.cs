namespace VRageMath
{
    using System;
    using System.Runtime.CompilerServices;

    public static class BoundingFrustumExtensions
    {
        public static BoundingSphere ToBoundingSphere(this BoundingFrustum frustum, Vector3[] corners)
        {
            float num;
            float num2;
            Vector3 vector;
            float num3;
            float num4;
            BoundingSphere sphere;
            Vector3 vector2;
            Vector3 vector3;
            Vector3 vector4;
            Vector3 vector5;
            Vector3 vector6;
            if (corners.Length < 8)
            {
                throw new ArgumentException("Corners length must be at least 8");
            }
            frustum.GetCorners(corners);
            Vector3 vector7 = vector2 = vector3 = vector4 = vector5 = vector6 = corners[0];
            for (int i = 0; i < corners.Length; i++)
            {
                Vector3 vector8 = corners[i];
                if (vector8.X < vector7.X)
                {
                    vector7 = vector8;
                }
                if (vector8.X > vector2.X)
                {
                    vector2 = vector8;
                }
                if (vector8.Y < vector3.Y)
                {
                    vector3 = vector8;
                }
                if (vector8.Y > vector4.Y)
                {
                    vector4 = vector8;
                }
                if (vector8.Z < vector5.Z)
                {
                    vector5 = vector8;
                }
                if (vector8.Z > vector6.Z)
                {
                    vector6 = vector8;
                }
            }
            Vector3.Distance(ref vector2, ref vector7, out num4);
            Vector3.Distance(ref vector4, ref vector3, out num3);
            Vector3.Distance(ref vector6, ref vector5, out num2);
            if (num4 > num3)
            {
                if (num4 > num2)
                {
                    Vector3.Lerp(ref vector2, ref vector7, 0.5f, out vector);
                    num = num4 * 0.5f;
                }
                else
                {
                    Vector3.Lerp(ref vector6, ref vector5, 0.5f, out vector);
                    num = num2 * 0.5f;
                }
            }
            else if (num3 > num2)
            {
                Vector3.Lerp(ref vector4, ref vector3, 0.5f, out vector);
                num = num3 * 0.5f;
            }
            else
            {
                Vector3.Lerp(ref vector6, ref vector5, 0.5f, out vector);
                num = num2 * 0.5f;
            }
            for (int j = 0; j < corners.Length; j++)
            {
                Vector3 vector10;
                Vector3 vector9 = corners[j];
                vector10.X = vector9.X - vector.X;
                vector10.Y = vector9.Y - vector.Y;
                vector10.Z = vector9.Z - vector.Z;
                float num7 = vector10.Length();
                if (num7 > num)
                {
                    num = (num + num7) * 0.5f;
                    vector += (Vector3) ((1f - (num / num7)) * vector10);
                }
            }
            sphere.Center = vector;
            sphere.Radius = num;
            return sphere;
        }
    }
}

