namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Serialization;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyTransformD
    {
        [Serialize(MyPrimitiveFlags.Normalized)]
        public Quaternion Rotation;
        public Vector3D Position;
        public MatrixD TransformMatrix
        {
            get
            {
                MatrixD xd = MatrixD.CreateFromQuaternion(this.Rotation);
                xd.Translation = this.Position;
                return xd;
            }
        }
        public MyTransformD(Vector3D position) : this(ref position)
        {
        }

        public MyTransformD(MatrixD matrix) : this(ref matrix)
        {
        }

        public MyTransformD(ref Vector3D position)
        {
            this.Rotation = Quaternion.Identity;
            this.Position = position;
        }

        public MyTransformD(ref MatrixD matrix)
        {
            Quaternion.CreateFromRotationMatrix(ref matrix, out this.Rotation);
            this.Position = matrix.Translation;
        }

        public static MyTransformD Transform(ref MyTransformD t1, ref MyTransformD t2)
        {
            MyTransformD md;
            Transform(ref t1, ref t2, out md);
            return md;
        }

        public static void Transform(ref MyTransformD t1, ref MyTransformD t2, out MyTransformD result)
        {
            Vector3D vectord;
            Quaternion quaternion;
            Vector3D.Transform(ref t1.Position, ref t2.Rotation, out vectord);
            vectord += t2.Position;
            Quaternion.Multiply(ref t1.Rotation, ref t2.Rotation, out quaternion);
            result.Position = vectord;
            result.Rotation = quaternion;
        }

        public static Vector3D Transform(ref Vector3D v, ref MyTransformD t2)
        {
            Vector3D vectord;
            Transform(ref v, ref t2, out vectord);
            return vectord;
        }

        public static void Transform(ref Vector3D v, ref MyTransformD t2, out Vector3D result)
        {
            Vector3D.Transform(ref v, ref t2.Rotation, out result);
            result += t2.Position;
        }
    }
}

