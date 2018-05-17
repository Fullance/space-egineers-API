namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using VRageMath.PackedVector;

    [Serializable, StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct CompressedPositionOrientation
    {
        public Vector3 Position;
        public HalfVector4 Orientation;
        public VRageMath.Matrix Matrix
        {
            get
            {
                VRageMath.Matrix matrix;
                this.ToMatrix(out matrix);
                return matrix;
            }
            set
            {
                this.FromMatrix(ref value);
            }
        }
        public CompressedPositionOrientation(ref VRageMath.Matrix matrix)
        {
            Quaternion quaternion;
            this.Position = matrix.Translation;
            Quaternion.CreateFromRotationMatrix(ref matrix, out quaternion);
            this.Orientation = new HalfVector4(quaternion.ToVector4());
        }

        public void FromMatrix(ref VRageMath.Matrix matrix)
        {
            Quaternion quaternion;
            this.Position = matrix.Translation;
            Quaternion.CreateFromRotationMatrix(ref matrix, out quaternion);
            this.Orientation = new HalfVector4(quaternion.ToVector4());
        }

        public void ToMatrix(out VRageMath.Matrix result)
        {
            VRageMath.Matrix.CreateFromQuaternion(ref Quaternion.FromVector4(this.Orientation.ToVector4()), out result);
            result.Translation = this.Position;
        }
    }
}

