namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Serialization;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyTransform
    {
        [Serialize(MyPrimitiveFlags.Normalized)]
        public Quaternion Rotation;
        public Vector3 Position;
        public Matrix TransformMatrix
        {
            get
            {
                Matrix matrix = Matrix.CreateFromQuaternion(this.Rotation);
                matrix.Translation = this.Position;
                return matrix;
            }
        }
        public MyTransform(Vector3 position) : this(ref position)
        {
        }

        public MyTransform(Matrix matrix) : this(ref matrix)
        {
        }

        public MyTransform(ref Vector3 position)
        {
            this.Rotation = Quaternion.Identity;
            this.Position = position;
        }

        public MyTransform(ref Matrix matrix)
        {
            Quaternion.CreateFromRotationMatrix(ref matrix, out this.Rotation);
            this.Position = matrix.Translation;
        }

        public static MyTransform Transform(ref MyTransform t1, ref MyTransform t2)
        {
            MyTransform transform;
            Transform(ref t1, ref t2, out transform);
            return transform;
        }

        public static void Transform(ref MyTransform t1, ref MyTransform t2, out MyTransform result)
        {
            Vector3 vector;
            Quaternion quaternion;
            Vector3.Transform(ref t1.Position, ref t2.Rotation, out vector);
            vector += t2.Position;
            Quaternion.Multiply(ref t1.Rotation, ref t2.Rotation, out quaternion);
            result.Position = vector;
            result.Rotation = quaternion;
        }

        public static Vector3 Transform(ref Vector3 v, ref MyTransform t2)
        {
            Vector3 vector;
            Transform(ref v, ref t2, out vector);
            return vector;
        }

        public static void Transform(ref Vector3 v, ref MyTransform t2, out Vector3 result)
        {
            Vector3.Transform(ref v, ref t2.Rotation, out result);
            result += t2.Position;
        }
    }
}

